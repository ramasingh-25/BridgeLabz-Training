using FundooApp.BusinessLayer.Interfaces;
using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Entities;
using FundooApp.ModelLayer.Exceptions;
using FundooApp.RepositoryLayer.Interfaces;

namespace FundooApp.BusinessLayer.Services
{
    public class NoteBusiness : INoteBusiness
    {
        private readonly INoteRepository _noteRepository;

        public NoteBusiness(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteResponseDTO> AddNoteAsync(NoteDTO noteDto, int userId)
        {
            var note = new Note
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
                Color = noteDto.Color,
                Reminder = noteDto.Reminder,
                UserId = userId
            };

            var created = await _noteRepository.AddAsync(note);
            return MapToResponseDto(created);
        }

        public async Task<IEnumerable<NoteResponseDTO>> GetAllNotesAsync(int userId)
        {
            var notes = await _noteRepository.GetAllByUserAsync(userId);
            return notes.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<NoteResponseDTO>> GetActiveNotesAsync(int userId)
        {
            var notes = await _noteRepository.GetActiveNotesAsync(userId);
            return notes.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<NoteResponseDTO>> GetArchivedNotesAsync(int userId)
        {
            var notes = await _noteRepository.GetArchivedNotesAsync(userId);
            return notes.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<NoteResponseDTO>> GetTrashedNotesAsync(int userId)
        {
            var notes = await _noteRepository.GetTrashedNotesAsync(userId);
            return notes.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<NoteResponseDTO>> SearchNotesAsync(int userId, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetActiveNotesAsync(userId);
            }

            var notes = await _noteRepository.SearchAsync(userId, searchTerm);
            return notes.Select(MapToResponseDto);
        }

        public async Task<NoteResponseDTO> UpdateNoteAsync(int noteId, NoteDTO noteDto, int userId)
        {
            var note = await GetOwnedNoteOrThrow(noteId, userId);

            note.Title = noteDto.Title;
            note.Description = noteDto.Description;
            note.Color = noteDto.Color;
            note.Reminder = noteDto.Reminder;

            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task<bool> DeleteNoteAsync(int noteId, int userId)
        {
            var deleted = await _noteRepository.DeleteAsync(noteId, userId);
            if (!deleted)
            {
                throw new NoteNotFoundException();
            }
            return true;
        }

        public async Task<NoteResponseDTO> TogglePinAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteOrThrow(noteId, userId);
            note.IsPin = !note.IsPin;
            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task<NoteResponseDTO> ToggleArchiveAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteOrThrow(noteId, userId);
            note.IsArchive = !note.IsArchive;
            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task<NoteResponseDTO> MoveToTrashAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteOrThrow(noteId, userId);
            note.IsTrash = true;
            note.IsPin = false; // a trashed note shouldn't stay pinned to the home view
            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task<NoteResponseDTO> RestoreFromTrashAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteOrThrow(noteId, userId);
            note.IsTrash = false;
            var updated = await _noteRepository.UpdateAsync(note);
            return MapToResponseDto(updated);
        }

        public async Task<NoteResponseDTO> AddLabelToNoteAsync(int noteId, int labelId, int userId)
        {
            var attached = await _noteRepository.AddLabelToNoteAsync(noteId, labelId, userId);
            if (!attached)
            {
                throw new NoteNotFoundException("Note or label not found for this user.");
            }

            var note = await GetOwnedNoteOrThrow(noteId, userId);
            return MapToResponseDto(note);
        }

        public async Task<NoteResponseDTO> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId)
        {
            var removed = await _noteRepository.RemoveLabelFromNoteAsync(noteId, labelId, userId);
            if (!removed)
            {
                throw new NoteNotFoundException("Note, label, or the association between them was not found.");
            }

            var note = await GetOwnedNoteOrThrow(noteId, userId);
            return MapToResponseDto(note);
        }

        public async Task<IEnumerable<NoteResponseDTO>> GetNotesByLabelAsync(int userId, int labelId)
        {
            var notes = await _noteRepository.GetByLabelAsync(userId, labelId);
            return notes.Select(MapToResponseDto);
        }

        private async Task<Note> GetOwnedNoteOrThrow(int noteId, int userId)
        {
            var note = await _noteRepository.GetByIdAsync(noteId, userId);
            if (note == null)
            {
                throw new NoteNotFoundException();
            }
            return note;
        }

        private static NoteResponseDTO MapToResponseDto(Note note)
        {
            return new NoteResponseDTO
            {
                NoteId = note.NoteId,
                Title = note.Title,
                Description = note.Description,
                Color = note.Color,
                IsArchive = note.IsArchive,
                IsTrash = note.IsTrash,
                IsPin = note.IsPin,
                Reminder = note.Reminder,
                CreatedAt = note.CreatedAt,
                Labels = note.Labels?.Select(l => l.Name).OrderBy(n => n).ToList() ?? new List<string>()
            };
        }
    }
}

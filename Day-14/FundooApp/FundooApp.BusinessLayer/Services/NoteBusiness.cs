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

        public async Task<NoteResponseDTO> UpdateNoteAsync(int noteId, NoteDTO noteDto, int userId)
        {
            var note = await _noteRepository.GetByIdAsync(noteId, userId);
            if (note == null)
            {
                throw new NoteNotFoundException();
            }

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
                CreatedAt = note.CreatedAt
            };
        }
    }
}

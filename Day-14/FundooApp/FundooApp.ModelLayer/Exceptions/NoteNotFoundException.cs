namespace FundooApp.ModelLayer.Exceptions
{
    public class NoteNotFoundException : Exception
    {
        public NoteNotFoundException() : base("Note not found.") { }

        public NoteNotFoundException(string message) : base(message) { }
    }
}

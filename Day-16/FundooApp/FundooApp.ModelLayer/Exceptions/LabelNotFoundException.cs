namespace FundooApp.ModelLayer.Exceptions
{
    public class LabelNotFoundException : Exception
    {
        public LabelNotFoundException() : base("Label not found.") { }

        public LabelNotFoundException(string message) : base(message) { }
    }
}

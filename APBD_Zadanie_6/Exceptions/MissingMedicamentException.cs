namespace APBD_Zadanie_6.Exceptions
{
    public class MissingMedicamentException : Exception
    {
        public MissingMedicamentException() { }
        public MissingMedicamentException(string message) : base(message) { }
    }
}

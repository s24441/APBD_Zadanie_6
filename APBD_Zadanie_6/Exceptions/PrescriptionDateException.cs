namespace APBD_Zadanie_6.Exceptions
{
    public class PrescriptionDateException : Exception
    {
        public PrescriptionDateException() { }
        public PrescriptionDateException(string message) : base(message) { }
    }
}

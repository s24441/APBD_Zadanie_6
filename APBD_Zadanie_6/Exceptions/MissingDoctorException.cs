namespace APBD_Zadanie_6.Exceptions
{
    public class MissingDoctorException : Exception
    {
        public MissingDoctorException() { }
        public MissingDoctorException(string message) : base(message) { }
    }
}

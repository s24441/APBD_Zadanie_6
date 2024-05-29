namespace APBD_Zadanie_6.Exceptions
{
    public class PrescriptionMedicamentsMaxRangeExceedException : Exception
    {
        public PrescriptionMedicamentsMaxRangeExceedException() { }
        public PrescriptionMedicamentsMaxRangeExceedException(string message) : base(message) { }
    }
}

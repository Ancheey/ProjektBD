namespace ProjektBD.Data.Entities
{
    public class Fee
    {
        public int Id { get; set; }
        public Rental Rental { get; set; }
        public FeeStatus Status { get; set; } = FeeStatus.Pending;
        public DateTime StatusDateChange { get; set; } = DateTime.Now;
        public enum FeeStatus
        {
            Pending,
            Waived,
            Paid
        }

        //1.20 pln per day
        public double GetDueAmount() => (DateTime.Today - Rental.DueDate).Hours * 0.05;
    }
}

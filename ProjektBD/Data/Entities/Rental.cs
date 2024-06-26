namespace ProjektBD.Data.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public Reader Renter { get; set; }
        public Book RentedBook { get; set; }
        public Employee Renting {  get; set; }
        public DateTime RentDate { get; set; } = DateTime.Today;
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(14);
        public bool Returned { get; set; } = false;
        public DateTime ReturnedDate { get; set; }

    }
}

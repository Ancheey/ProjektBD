namespace ProjektBD.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Unknown";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "Unknown";
        public BookGenre Genre { get; set; } = BookGenre.Unknown;
        public int PublicationYear { get; set; } = DateTime.Now.Year;

        public enum BookGenre
        {
            Unknown,
            Fantasy,
            Documentary,
            Thriller,
            Horror
        }
        public bool CurrentlyAvailable()
        {
            return !new PrimaryContext().Rentals.Any(r => !r.Returned && r.RentedBook == this);
        }
    }
}

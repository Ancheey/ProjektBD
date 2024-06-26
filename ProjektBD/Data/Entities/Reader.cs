namespace ProjektBD.Data.Entities
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Undisclosed";
        public string Surname { get; set; } = "Undisclosed";
        public string Email { get; set; } = "Unknown";
        public string Phone { get; set; } = "Unknown";
        public string Address { get; set; } = "Unknown";

        public bool ValidateEmail()
        {
            if (Email.Length < 6)
                return false;
            if (Email.Contains("..") || Email.StartsWith(".") || Email.EndsWith("."))
                return false;
            if (!Email.Contains('@') || Email.StartsWith("@") || Email.EndsWith("@"))
                return false;
            if (Email.IndexOf('@') > Email.LastIndexOf("."))
                return false;

            return true;
        }
    }
}

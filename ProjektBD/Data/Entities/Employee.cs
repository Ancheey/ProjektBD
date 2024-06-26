namespace ProjektBD.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Unknown";
        public string Surname { get; set; } = "Unknown";
        public string Position { get; set; } = "Unknown";
        public DateTime HireDate { get; set; }
        public string Email { get; set; } = "Unknown@NA.NA";
        public string Phone { get; set; } = string.Empty;

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

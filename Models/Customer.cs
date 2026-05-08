namespace ASP_Reservacii_3_pr.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }

        public List<Reservation> Reservations { get; set; } = new();
    }
}

namespace ASP_Reservacii_3_pr.Models
{
    public class DiningTable
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }

        public List<Reservation> Reservations { get; set; } = new();
    }
}

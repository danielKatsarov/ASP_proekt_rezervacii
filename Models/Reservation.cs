namespace ASP_Reservacii_3_pr.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int DiningTableId { get; set; }
        public DiningTable? DiningTable { get; set; }
    }
}

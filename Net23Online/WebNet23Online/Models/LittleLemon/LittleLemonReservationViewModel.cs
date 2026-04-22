namespace WebNet23Online.Models.LittleLemon
{
    public class LittleLemonReservationViewModel
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public int NumberOfGuests { get; set; }
        public string SeatingPreference { get; set; }
        public string AvailableTimesOnly { get; set; }
        public string ReservationDateOnly { get; set; }
        public string Occasion { get; set; }
        public string UserComments { get; set; }
    }
}

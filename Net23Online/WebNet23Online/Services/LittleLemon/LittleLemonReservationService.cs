
using WebNet23Online.Services.Interfaces.LittleLemon;
using WebNet23Online.Models.LittleLemon;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Data.Models;
namespace WebNet23Online.Services.LittleLemon
{
    public class LittleLemonReservationService: ILittleLemonReservationService
    {
        private ILittleLemonReservationRepository _reservationDataRepo;
        private ILittleLemonGuestRepository _guestDataRepo;

        public LittleLemonReservationService(
            ILittleLemonReservationRepository reservationDataRepo,
            ILittleLemonGuestRepository guestDataRepo)
        {
            _reservationDataRepo = reservationDataRepo;
            _guestDataRepo = guestDataRepo;
        }

        public int CreateGuest(string guestName)
        {
            var existingGuest = _guestDataRepo.GetAll()
                .FirstOrDefault(x => string.Equals(x.Name, guestName));

            if (existingGuest != null)
            {
                return existingGuest.Id;
            }

            var newGuest = new LittleLemonGuestData
            {
                Name = guestName
            };

            _guestDataRepo.Add(newGuest);
            return newGuest.Id;
        }

        public int CreateReservation(LittleLemonReservationViewModel viewModel)
        {


            var guest = _guestDataRepo.Get(viewModel.GuestId);
            

            var reservationData = new LittleLemonData
            {
                GuestId = guest.Id,
                NumberOfGuests = viewModel.NumberOfGuests,
                SeatingPreference = viewModel.SeatingPreference,
                AvailableTimesOnly = viewModel.AvailableTimesOnly,
                ReservationDateOnly = viewModel.ReservationDateOnly,
                Occasion = viewModel.Occasion,
                UserComments = viewModel.UserComments,
            };
            _reservationDataRepo.Add(reservationData);
            return reservationData.Id;
        }

        public LittleLemonReservationViewModel GetReservationViewModelById(int id)
        {
            var reservationDataById = _reservationDataRepo.Get(id);
            var guest = _guestDataRepo.Get(reservationDataById.GuestId);

            return new LittleLemonReservationViewModel
            {
                GuestId = reservationDataById.GuestId,
                GuestName = guest.Name,
                NumberOfGuests = reservationDataById.NumberOfGuests,
                SeatingPreference = reservationDataById.SeatingPreference,
                AvailableTimesOnly = reservationDataById.AvailableTimesOnly,
                ReservationDateOnly = reservationDataById.ReservationDateOnly,
                Occasion = reservationDataById.Occasion,
                UserComments = reservationDataById.UserComments,
            };
        }

        public bool LinkReservationToGuest(int reservationId, int guestId)
        {
            var reservation = _reservationDataRepo.Get(reservationId);
            var guest = _guestDataRepo.Get(guestId);

            if (reservation == null || guest == null)
            {
                return false;
            }

            reservation.GuestId = guestId;
            _reservationDataRepo.UpdateData(reservation);
            return true;
        }
    }
}

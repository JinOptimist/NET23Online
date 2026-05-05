
using WebNet23Online.Services.Interfaces.LittleLemon;
using WebNet23Online.Models.LittleLemon;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Data.Models;
namespace WebNet23Online.Services.LittleLemon
{
    public class LittleLemonReservationService: ILittleLemonReservationService
    {
        private ILittleLemonReservationRepository _reservationDataRepository;
        private ILittleLemonGuestRepository _guestDataRepository;

        public LittleLemonReservationService(
            ILittleLemonReservationRepository reservationDataRepository,
            ILittleLemonGuestRepository guestDataRepository)
        {
            _reservationDataRepository = reservationDataRepository;
            _guestDataRepository = guestDataRepository;
        }

        public int CreateGuest(string guestName)
        {
            var existingGuest = _guestDataRepository.GetAll()
                .FirstOrDefault(x => string.Equals(x.Name, guestName));

            if (existingGuest != null)
            {
                return existingGuest.Id;
            }

            var newGuest = new LittleLemonGuestData
            {
                Name = guestName
            };

            _guestDataRepository.Add(newGuest);
            return newGuest.Id;
        }

        public int CreateReservation(LittleLemonReservationViewModel viewModel)
        {

            var guestId = CreateGuest(viewModel.GuestName!);
            var guest = _guestDataRepository.Get(guestId);
            

            var reservationData = new LittleLemonData
            {
                GuestId = guest!.Id,
                NumberOfGuests = viewModel.NumberOfGuests,
                SeatingPreference = viewModel.SeatingPreference,
                AvailableTimesOnly = viewModel.AvailableTimesOnly,
                ReservationDateOnly = viewModel.ReservationDateOnly,
                Occasion = viewModel.Occasion,
                UserComments = viewModel.UserComments,
            };
            _reservationDataRepository.Add(reservationData);
            return reservationData.Id;
        }

        public LittleLemonReservationViewModel GetReservationViewModelById(int id)
        {
            var reservationDataById = _reservationDataRepository.Get(id);
            var guest = _guestDataRepository.Get(reservationDataById!.GuestId);

            return new LittleLemonReservationViewModel
            {
                GuestName = guest!.Name,
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
            var reservation = _reservationDataRepository.Get(reservationId);
            var guest = _guestDataRepository.Get(guestId);

            if (reservation == null || guest == null)
            {
                return false;
            }

            reservation.GuestId = guestId;
            _reservationDataRepository.Update(reservation);
            return true;
        }
    }
}

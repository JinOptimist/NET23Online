
using WebNet23Online.Services.Interfaces.LittleLemon;
using WebNet23Online.Models.LittleLemon;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Data.Models;
namespace WebNet23Online.Services.LittleLemon
{
    public class LittleLemonReservationService: ILittleLemonReservationService
    {
        private ILittleLemonReservationRepository _reservationDataRepo;

        public LittleLemonReservationService(ILittleLemonReservationRepository reservationDataRepo)
        {
            _reservationDataRepo = reservationDataRepo;
        }

        public int CreateReservation(LittleLemonReservationViewModel viewModel)
        {
            var reservationData = new LittleLemonData
            {
                NumberOfGuests = viewModel.NumberOfGuests,
                SeatingPreference = viewModel.SeatingPreference,
                AvailableTimesOnly = viewModel.AvailableTimesOnly,
                ReservationDateOnly = viewModel.ReservationDateOnly,
                Occasion = viewModel.Occasion,
                UserComments = viewModel.UserComments,
                UserName = viewModel.UserName,
            };
            _reservationDataRepo.Add(reservationData);
            return reservationData.Id;
        }

        public LittleLemonReservationViewModel GetReservationViewModelById(int id)
        {
            var reservationDataById = _reservationDataRepo.Get(id);
            
            return new LittleLemonReservationViewModel
            {
                NumberOfGuests = reservationDataById.NumberOfGuests,
                SeatingPreference = reservationDataById.SeatingPreference,
                AvailableTimesOnly = reservationDataById.AvailableTimesOnly,
                ReservationDateOnly = reservationDataById.ReservationDateOnly,
                Occasion = reservationDataById.Occasion,
                UserComments = reservationDataById.UserComments,
                UserName = reservationDataById.UserName,
            };
        }

       
    }
}

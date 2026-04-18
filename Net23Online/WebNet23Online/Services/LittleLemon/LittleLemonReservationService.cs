using WebNet23Online.Data;
using WebNet23Online.Services.Interfaces.LittleLemon;
using WebNet23Online.Data.Models;
using WebNet23Online.Models.LittleLemon;
namespace WebNet23Online.Services.LittleLemon
{
    public class LittleLemonReservationService: ILittleLemonReservationService
    {
        private WebContext _webContext;

        public LittleLemonReservationService(WebContext webContext)
        {
            _webContext = webContext;
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
            _webContext.LittleLemonDatas.Add(reservationData);
            _webContext.SaveChanges();
            return reservationData.Id;
        }

        public LittleLemonReservationViewModel GetReservationViewModelById(int id)
        {
            var reservationDataById = _webContext.LittleLemonDatas.Find(id);
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

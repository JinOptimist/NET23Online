using WebNet23Online.Models.LittleLemon;

namespace WebNet23Online.Services.Interfaces.LittleLemon
{
    public interface ILittleLemonReservationService
    {
        int CreateReservation(LittleLemonReservationViewModel viewModel);
        LittleLemonReservationViewModel GetReservationViewModelById(int id);
    }
}
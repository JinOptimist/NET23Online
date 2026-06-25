using Microsoft.AspNetCore.SignalR;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Hubs;
using WebNet23Online.Hubs.Interfaces;
using WebNet23Online.Services.Interfaces.LittleLemon;

namespace WebNet23Online.Services.BackgroundServices
{
    public class LittleLemonReminderBackgroundService : BackgroundService
    {
        public const int DELAY_BETWEEN_NOTIFICATION_CHECK = 30;
        private IServiceProvider _serviceProvider;

        public LittleLemonReminderBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var di = _serviceProvider.CreateScope();
            var reservationRepository = di.ServiceProvider.GetService<ILittleLemonReservationRepository>();
            var hub = di.ServiceProvider.GetService<IHubContext<LittleLemonHub, ILittleLemonHub>>();
            var chatService = di.ServiceProvider.GetService<ILittleLemonChatService>();

            while (true)
            {
                var now = DateTime.Now;
                var unsentReminders = reservationRepository.GetByUnsentReminders();
                var dueReminders = new List<LittleLemonData>();

                foreach (var reservation in unsentReminders)
                {
                    var reservationAt = DateTime.Parse(
                        $"{reservation.ReservationDateOnly} {reservation.AvailableTimesOnly}");

                    if (reservationAt <= now
                        || now < reservationAt.AddHours(-1))
                    {
                        continue;
                    }

                    var userGroup = chatService.GetUserGroupName(reservation.CreatedByUserId!.Value);

                    await hub.Clients.Group(userGroup).ReservationReminder(
                        reservation.Id,
                        reservation.Guest?.Name ?? string.Empty,
                        reservation.ReservationDateOnly,
                        reservation.AvailableTimesOnly,
                        reservation.NumberOfGuests);

                    reservation.IsReminderSent = true;
                    dueReminders.Add(reservation);
                }

                reservationRepository.Update(dueReminders);

                await Task.Delay(DELAY_BETWEEN_NOTIFICATION_CHECK * 1000);
            }
        }
    }
}

using WebNet23Online.Models.EventWorkshop;
using WebNet23Online.Services.EventWorkshop.Interfaces;

namespace WebNet23Online.Services.EventWorkshop
{
    public class EventWorkshopGenerator : IEventWorkshopGenerator
    {
        public List<EventInfoViewModel> GenerateList()
        {
            var eventList = new List<EventInfoViewModel>();
            eventList.Add(new EventInfoViewModel
            {
                Category = EventCategory.Creation,
                Url = "https://i.imgur.com/mCulpWu.jpeg",
                Title = "Музыкальная импровизация",
                Description = "Импровизация любителей музыки! Создайте шедевр со случайными людьми.",
                Date = new DateOnly(2026, 5, 29),
                Time = new TimeOnly(22, 0)
            });
            eventList.Add(new EventInfoViewModel
            {
                Category = EventCategory.Creation,
                Url = "https://i.imgur.com/yujdumm.jpeg",
                Title = "Чайная церемония",
                Description = "Примите участие в чайной церемонии! Знакомства, дружеское общение и многое другое.",
                //DateDay = "17 APR",
                //DateYear = "2026",
                //Time = "19:00"
            });
            eventList.Add(new EventInfoViewModel
            {
                Category = EventCategory.Creation,
                Url = "https://i.imgur.com/JrITbnD.jpeg",
                Title = "Книжные дебаты",
                Description = "Читаем, обсуждаем, спорим в поисках истины. Приглашаются все желающие!",
                //DateDay = "30 MAY",
                //DateYear = "2026",
                //Time = "08:00"
            });

            eventList.Add(new EventInfoViewModel
            {
                Category = EventCategory.Sport,
                Url = "https://i.imgur.com/YsbPP2S.jpeg",
                Title = "Велосипедный тур",
                Description = "Неспешно прокатитесь по велосипедным тропам, " +
                "погружаясь в атмосферу загородной природы, хорошей компании и полезного спорта! " +
                "Приглашаются все желающие.",
                //DateDay = "19 JUN",
                //DateYear = "2026",
                //Time = "15:00"
            });

            eventList.Add(new EventInfoViewModel
            {
                Category = EventCategory.Games,
                Url = "https://i.imgur.com/I1dbkqm.jpeg",
                Title = "D&D",
                Description = "Ограбьте бандитов, сожгите дракона, своруйте золото. " +
                "Почувствуйте себя гномом в атмосферном приключении мира Dungeon & Dragons! Еда за счёт мастера.",
                //DateDay = "14 JUL",
                //DateYear = "2026",
                //Time = "14:00"
            });

            return eventList;
        }
    }
}

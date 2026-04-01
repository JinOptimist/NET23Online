using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Models.EventWorkshop;
namespace WebNet23Online.Controllers
{
    public class EventWorkshopController : Controller
    {
        public IActionResult Index(string typeEvent) 
        {
            var selectedViewModels = new List<EventWorkshopEventInfoViewModel>();

            var isCreation = false;
            var isSport = false;
            var isGame = false;
            var isAllType = false;

            switch (typeEvent)
            {
                case "Creation":
                    {
                        isCreation = true; 
                        break;
                    }
                case "Sport":
                    {
                        isSport = true;
                        break;
                    }
                case "Games":
                    {
                        isGame = true;
                        break;
                    }
                default:
                    {
                        isAllType = true;
                        break;
                    }
            }

            if (isAllType)
            {
                selectedViewModels = GetHobbyViewModels()
                    .Concat(GetSportViewModels())
                    .Concat(GetGameViewModels())
                    .ToList();
            }
            else
            {
                if (isCreation)
                {
                    selectedViewModels?.AddRange(GetHobbyViewModels());
                }
                if (isSport)
                {
                    selectedViewModels?.AddRange(GetSportViewModels());
                }
                if (isGame)
                {
                    selectedViewModels?.AddRange(GetGameViewModels());
                }
            }
            selectedViewModels = selectedViewModels?.ToList();

            return View(selectedViewModels);
        }

        private List<EventWorkshopEventInfoViewModel> GetHobbyViewModels()
        {
            var hobbyViewModels = new List<EventWorkshopEventInfoViewModel>();
            hobbyViewModels.Add(new EventWorkshopEventInfoViewModel
            {
                Url = "/images/event-workshop/creation/creation1.jpg",
                Title = "Музыкальная импровизация",
                Description = "Импровизация любителей музыки! Создайте шедевр со случайными людьми.",
                Date = "29 JAN 2026",
                Time = "22:00"
            });
            hobbyViewModels.Add(new EventWorkshopEventInfoViewModel
            {
                Url = "/images/event-workshop/creation/creation2.jpg",
                Title = "Чайная церемония",
                Description = "Примите участие в чайной церемонии! Знакомства, дружеское общение и многое другое.",
                Date = "17 APR 2026",
                Time = "19:00"
            });
            hobbyViewModels.Add(new EventWorkshopEventInfoViewModel
            {
                Url = "/images/event-workshop/creation/creation3.jpg",
                Title = "Книжные дебаты",
                Description = "Читаем, обсуждаем, спорим в поисках истины. Приглашаются все желающие!",
                Date = "30 MAY 2026",
                Time = "08:00"
            });

            return hobbyViewModels;
        }

        private List<EventWorkshopEventInfoViewModel> GetSportViewModels()
        {
            var sportViewModels = new List<EventWorkshopEventInfoViewModel>();
            sportViewModels.Add(new EventWorkshopEventInfoViewModel
            {
                Url = "/images/event-workshop/sport/sport1.jpg",
                Title = "Велосипедный тур",
                Description = "Неспешно прокатитесь по велосипедным тропам, " +
                "погружаясь в атмосферу загородной природы, хорошей компании и полезного спорта! " +
                "Приглашаются все желающие.",
                Date = "19 JUN 2026",
                Time = "15:00"
            });

            return sportViewModels;
        }

        private List<EventWorkshopEventInfoViewModel> GetGameViewModels()
        {
            var gameViewModels = new List<EventWorkshopEventInfoViewModel>();
            gameViewModels.Add(new EventWorkshopEventInfoViewModel
            {
                Url = "/images/event-workshop/games/game1.jpg",
                Title = "D&D",
                Description = "Ограбьте бандитов, сожгите дракона, своруйте золото. " +
                "Почувствуйте себя гномом в атмосферном приключении мира Dungeon & Dragons! Еда за счёт мастера.",
                Date = "14 JUL 2026",
                Time = "14:00"
            });

            return gameViewModels;
        }
    }
}

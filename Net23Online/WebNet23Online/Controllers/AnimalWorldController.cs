using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.AnimalWorld;

namespace WebNet23Online.Controllers
{
    public class AnimalWorldController : Controller
    {
        private static List<StartPageBeastViewModel> _startPageAnimalViewModels = new List<StartPageBeastViewModel>
        {
            new StartPageBeastViewModel
            {
                BeastName = "Жираф",
                BriefDescription = "Жирафы — исключительно растительноядные животные. Строение тела и физиология позволяют им питаться листвой древесных крон — на высоте, где у них нет конкурентов."
            },
            //new StartPageAnimalViewModel{ AnimalName = "Медведь", BriefDescription = "Сравнительно с остальными семействами отряда хищных, медведи отличаются наибольшим однообразием внешнего вида, размеров, многих особенностей внутреннего строения. Это самые крупные из современных наземных хищников." },
            //new StartPageAnimalViewModel{ AnimalName = "Тигр", BriefDescription = "Тигр (лат. Panthera tigris) — хищное млекопитающее семейства кошачьих, один из пяти видов рода пантер, принадлежащего к подсемейству больших кошек. Среди представителей этого вида встречаются крупнейшие животные семейства кошачьих. Тигр является одним из крупнейших наземных хищников, уступая по массе лишь белому и бурому медведям." },
            //new StartPageAnimalViewModel{ AnimalName = "Енот", BriefDescription = "Ено́ты (лат. Procyon) — род хищных млекопитающих семейства енотовых. В России енота изначально знали по шкуркам, которые назывались «генеттовыми мехами», потому что зверёк с полосатым хвостом напоминает генету. Позднее это название превратилось в «генот» или енот." },
            //new StartPageAnimalViewModel{ AnimalName = "Орёл", BriefDescription = "Орлы́ (лат. Aquila) — род хищных птиц семейства ястребиных. Длина тела 75—88 см, хвост довольно короткий, крылья широкие, до 2,4 м в размахе, ноги оперены до пальцев." },
            //new StartPageAnimalViewModel{ AnimalName = "Собака", BriefDescription = "Соба́ка, или дома́шняя соба́ка (лат. Canis familiaris, или лат. Canis lupus familiaris), — домашнее животное, одно из наиболее популярных (наряду с кошкой) животных-компаньонов. С зоологической точки зрения, собака — плацентарное млекопитающее отряда хищных семейства псовых. Домашняя собака была описана как самостоятельный биологический вид Canis familiaris Линнеем в 1758 году; в настоящее время данное научное название признаётся организациями, такими как Американское общество маммологов. Некоторые источники (например, ITIS и MSW3) признают собаку подвидом волка (Canis lupus familiaris)." },
            //new StartPageAnimalViewModel{ AnimalName = "Утка", BriefDescription = "У́тка — представитель птиц из нескольких родов семейства утиных: пеганки, нырковые утки, савки, речные утки, утки-пароходы, мускусные утки и крохали; всего более 110 видов. Распространены утки широко, в России более 30 видов." },
            //new StartPageAnimalViewModel{ AnimalName = "Ёж", BriefDescription = "Обыкнове́нный ёж, или европе́йский ёж, или среднеру́сский ёж (лат. Erinaceus europaeus), — вид млекопитающих из рода евразийских ежей семейства ежовых. Обитает в широколиственных лесах Западной и Центральной Европы, в том числе на Британских островах и в южной Скандинавии, а также в северных и центральных районах европейской части России; интродуцирован в Новую Зеландию." },
            //new StartPageAnimalViewModel{ AnimalName = "Зебра", BriefDescription = "Зе́бры (лат. Hippotigris) — подрод рода лошади, включающий виды бурчеллова зебра (Equus quagga), зебра Греви (Equus grevyi) и горная зебра (Equus zebra). Гибридные формы между зебрами и домашними лошадьми называют зеброидами, между зебрами и ослами — зебрулами." },
        };
        public const int START_PAGE_COUNT_ANIMALS = 2;
        public const string CANT_FIND_ANIMAL = "Не получается найти такое животное. Попробуйте изменить запрос.";

        public IActionResult Index()
        {
            var copy = _startPageAnimalViewModels.ToArray();
            Random.Shared.Shuffle(copy);
            var startPageAnimalsList = copy.Take(START_PAGE_COUNT_ANIMALS).ToList();
            var startPageAnimals = new StartPageAnimalsViewModel
            {
                Animals = startPageAnimalsList,
                Beast = null,
            };
            return View(startPageAnimals);
        }

        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnimal(StartPageBeastViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.BeastName) || string.IsNullOrEmpty(viewModel.BriefDescription))
            {
                return View();
            }

            var beastSearch = _startPageAnimalViewModels.FirstOrDefault(animal => animal.BeastName.ToLower() == viewModel.BeastName.ToLower());
            if (beastSearch == null)
            {
                _startPageAnimalViewModels.Add(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AnimalSearch(StartPageBeastViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.BeastName))
            {
                return PartialView();
            }

            var beastSearch = _startPageAnimalViewModels.FirstOrDefault(animal => animal.BeastName.ToLower() == viewModel.BeastName.ToLower());
            if (beastSearch == null)
            {
                beastSearch = new StartPageBeastViewModel
                {
                    BriefDescription = CANT_FIND_ANIMAL
                };
            }

            return PartialView(beastSearch);
        }
    }
}

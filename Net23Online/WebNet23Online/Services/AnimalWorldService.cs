using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Models.AnimalWorld;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class AnimalWorldService : IAnimalWorldService
    {
        //private List<StartPageBeastViewModel> _startPageAnimalViewModels = new List<StartPageBeastViewModel>
        //{
        //    new StartPageBeastViewModel
        //    {
        //        BeastName = "Жираф",
        //        BriefDescription = "Жирафы — исключительно растительноядные животные. Строение тела и физиология позволяют им питаться листвой древесных крон — на высоте, где у них нет конкурентов."
        //    },
        //    //new StartPageAnimalViewModel{ AnimalName = "Медведь", BriefDescription = "Сравнительно с остальными семействами отряда хищных, медведи отличаются наибольшим однообразием внешнего вида, размеров, многих особенностей внутреннего строения. Это самые крупные из современных наземных хищников." },
        //    //new StartPageAnimalViewModel{ AnimalName = "Тигр", BriefDescription = "Тигр (лат. Panthera tigris) — хищное млекопитающее семейства кошачьих, один из пяти видов рода пантер, принадлежащего к подсемейству больших кошек. Среди представителей этого вида встречаются крупнейшие животные семейства кошачьих. Тигр является одним из крупнейших наземных хищников, уступая по массе лишь белому и бурому медведям." },
        //    //new StartPageAnimalViewModel{ AnimalName = "Енот", BriefDescription = "Ено́ты (лат. Procyon) — род хищных млекопитающих семейства енотовых. В России енота изначально знали по шкуркам, которые назывались «генеттовыми мехами», потому что зверёк с полосатым хвостом напоминает генету. Позднее это название превратилось в «генот» или енот." },
        //    //new StartPageAnimalViewModel{ AnimalName = "Орёл", BriefDescription = "Орлы́ (лат. Aquila) — род хищных птиц семейства ястребиных. Длина тела 75—88 см, хвост довольно короткий, крылья широкие, до 2,4 м в размахе, ноги оперены до пальцев." },
        //    //new StartPageAnimalViewModel{ AnimalName = "Собака", BriefDescription = "Соба́ка, или дома́шняя соба́ка (лат. Canis familiaris, или лат. Canis lupus familiaris), — домашнее животное, одно из наиболее популярных (наряду с кошкой) животных-компаньонов. С зоологической точки зрения, собака — плацентарное млекопитающее отряда хищных семейства псовых. Домашняя собака была описана как самостоятельный биологический вид Canis familiaris Линнеем в 1758 году; в настоящее время данное научное название признаётся организациями, такими как Американское общество маммологов. Некоторые источники (например, ITIS и MSW3) признают собаку подвидом волка (Canis lupus familiaris)." },
        //    //new StartPageAnimalViewModel{ AnimalName = "Утка", BriefDescription = "У́тка — представитель птиц из нескольких родов семейства утиных: пеганки, нырковые утки, савки, речные утки, утки-пароходы, мускусные утки и крохали; всего более 110 видов. Распространены утки широко, в России более 30 видов." },
        //    //new StartPageAnimalViewModel{ AnimalName = "Ёж", BriefDescription = "Обыкнове́нный ёж, или европе́йский ёж, или среднеру́сский ёж (лат. Erinaceus europaeus), — вид млекопитающих из рода евразийских ежей семейства ежовых. Обитает в широколиственных лесах Западной и Центральной Европы, в том числе на Британских островах и в южной Скандинавии, а также в северных и центральных районах европейской части России; интродуцирован в Новую Зеландию." },
        //    //new StartPageAnimalViewModel{ AnimalName = "Зебра", BriefDescription = "Зе́бры (лат. Hippotigris) — подрод рода лошади, включающий виды бурчеллова зебра (Equus quagga), зебра Греви (Equus grevyi) и горная зебра (Equus zebra). Гибридные формы между зебрами и домашними лошадьми называют зеброидами, между зебрами и ослами — зебрулами." },
        //};
        public const int START_PAGE_COUNT_ANIMALS = 2;
        public const string CANT_FIND_ANIMAL = "Не получается найти такое животное. Попробуйте изменить запрос.";
        private WebContext _webContext;

        public AnimalWorldService(WebContext webContext)
        {
            _webContext = webContext;
        }

        public StartPageAnimalsViewModel GetAllAnimals()
        {
            var animals = GetAllBeastsFromDatabase();
            var startPageAnimals = new StartPageAnimalsViewModel
            {
                Animals = animals,
                Beast = null,
            };
            return startPageAnimals;
        }

        public StartPageAnimalsViewModel GetRandomAnimals()
        {
            var animals = GetAllBeastsFromDatabase();
            var copy = animals.ToArray();
            Random.Shared.Shuffle(copy);
            var startPageAnimalsList = copy.Take(START_PAGE_COUNT_ANIMALS).ToList();
            var startPageAnimals = new StartPageAnimalsViewModel
            {
                Animals = startPageAnimalsList,
                Beast = null,
            };
            return startPageAnimals;
        }

        public bool AddAnimal(StartPageBeastViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.BeastName) || string.IsNullOrEmpty(viewModel.BriefDescription))
            {
                return false;
            }

            var beastSearch = _webContext.Beasts.FirstOrDefault(animal => animal.BeastName.ToLower() == viewModel.BeastName.ToLower());

            //var beastSearch = _startPageAnimalViewModels.FirstOrDefault(animal => animal.BeastName.ToLower() == viewModel.BeastName.ToLower());
            if (beastSearch == null)
            {
                BeastData beastData = new BeastData
                {
                    BeastName = viewModel.BeastName,
                    NativeRange = viewModel.NativeRange,
                    BriefDescription = viewModel.BriefDescription,
                    FullDescription = viewModel.FullDescription,
                };
                _webContext.Beasts.Add(beastData);
                _webContext.SaveChanges();
            }

            return true;
        }

        public StartPageBeastViewModel SearchAnimal(StartPageBeastViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.BeastName))
            {
                return null;
            }

            var beastSearch = new StartPageBeastViewModel();
            var beastDataSearch = _webContext.Beasts.FirstOrDefault(animal => animal.BeastName.ToLower() == viewModel.BeastName.ToLower());
            //var beastSearch = _startPageAnimalViewModels.FirstOrDefault(animal => animal.BeastName.ToLower() == viewModel.BeastName.ToLower());
            if (beastDataSearch == null)
            {
                beastSearch.NativeRange = CANT_FIND_ANIMAL;
                beastSearch.FullDescription = CANT_FIND_ANIMAL;
            }
            else
            {
                beastSearch.BeastName = beastDataSearch.BeastName;
                beastSearch.NativeRange = beastDataSearch.NativeRange;
                beastSearch.FullDescription = beastDataSearch.FullDescription;
            }

            return beastSearch;
        }

        private List<StartPageBeastViewModel> GetAllBeastsFromDatabase()
        {
            var beastsData = _webContext.Beasts.ToList();
            var beasts = beastsData.Select(animal => new StartPageBeastViewModel
            {
                BeastName = animal.BeastName,
                NativeRange = animal.NativeRange,
                BriefDescription = animal.BriefDescription,
                FullDescription = animal.FullDescription,
            });
            return beasts.ToList();
        }
    }
}

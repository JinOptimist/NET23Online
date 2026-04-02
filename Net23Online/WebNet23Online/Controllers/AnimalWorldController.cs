using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.AnimalWorld;

namespace WebNet23Online.Controllers
{
    public class AnimalWorldController : Controller
    {
        private List<StartPageAnimalViewModel> _startPageAnimalViewModels = new List<StartPageAnimalViewModel>
        {
            new StartPageAnimalViewModel{ Name = "Жираф", BriefDescription = "Жирафы — исключительно растительноядные животные. Строение тела и физиология позволяют им питаться листвой древесных крон — на высоте, где у них нет конкурентов." },
            new StartPageAnimalViewModel{ Name = "Медведь", BriefDescription = "Сравнительно с остальными семействами отряда хищных, медведи отличаются наибольшим однообразием внешнего вида, размеров, многих особенностей внутреннего строения. Это самые крупные из современных наземных хищников." },
            new StartPageAnimalViewModel{ Name = "Тигр", BriefDescription = "Тигр (лат. Panthera tigris) — хищное млекопитающее семейства кошачьих, один из пяти видов рода пантер, принадлежащего к подсемейству больших кошек. Среди представителей этого вида встречаются крупнейшие животные семейства кошачьих. Тигр является одним из крупнейших наземных хищников, уступая по массе лишь белому и бурому медведям." },
            new StartPageAnimalViewModel{ Name = "Енот", BriefDescription = "Ено́ты (лат. Procyon) — род хищных млекопитающих семейства енотовых. В России енота изначально знали по шкуркам, которые назывались «генеттовыми мехами», потому что зверёк с полосатым хвостом напоминает генету. Позднее это название превратилось в «генот» или енот." },
            new StartPageAnimalViewModel{ Name = "Орёл", BriefDescription = "Орлы́ (лат. Aquila) — род хищных птиц семейства ястребиных. Длина тела 75—88 см, хвост довольно короткий, крылья широкие, до 2,4 м в размахе, ноги оперены до пальцев." },
            new StartPageAnimalViewModel{ Name = "Собака", BriefDescription = "Соба́ка, или дома́шняя соба́ка (лат. Canis familiaris, или лат. Canis lupus familiaris), — домашнее животное, одно из наиболее популярных (наряду с кошкой) животных-компаньонов. С зоологической точки зрения, собака — плацентарное млекопитающее отряда хищных семейства псовых. Домашняя собака была описана как самостоятельный биологический вид Canis familiaris Линнеем в 1758 году; в настоящее время данное научное название признаётся организациями, такими как Американское общество маммологов. Некоторые источники (например, ITIS и MSW3) признают собаку подвидом волка (Canis lupus familiaris)." },
            new StartPageAnimalViewModel{ Name = "Утка", BriefDescription = "У́тка — представитель птиц из нескольких родов семейства утиных: пеганки, нырковые утки, савки, речные утки, утки-пароходы, мускусные утки и крохали; всего более 110 видов. Распространены утки широко, в России более 30 видов." },
            new StartPageAnimalViewModel{ Name = "Ёж", BriefDescription = "Обыкнове́нный ёж, или европе́йский ёж, или среднеру́сский ёж (лат. Erinaceus europaeus), — вид млекопитающих из рода евразийских ежей семейства ежовых. Обитает в широколиственных лесах Западной и Центральной Европы, в том числе на Британских островах и в южной Скандинавии, а также в северных и центральных районах европейской части России; интродуцирован в Новую Зеландию." },
            new StartPageAnimalViewModel{ Name = "Зебра", BriefDescription = "Зе́бры (лат. Hippotigris) — подрод рода лошади, включающий виды бурчеллова зебра (Equus quagga), зебра Греви (Equus grevyi) и горная зебра (Equus zebra). Гибридные формы между зебрами и домашними лошадьми называют зеброидами, между зебрами и ослами — зебрулами." },
        };
        private Random _random = new Random();

        public IActionResult Index()
        {
            var count = _startPageAnimalViewModels.Count();
            var indexFirstAnimal = _random.Next(0, count);
            var indexSecondAnimal = _random.Next(0, count);
            var startPageAnimals = new List<StartPageAnimalViewModel>
            {
                _startPageAnimalViewModels[indexFirstAnimal],
                _startPageAnimalViewModels[indexSecondAnimal]
            };
            return View(startPageAnimals);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}

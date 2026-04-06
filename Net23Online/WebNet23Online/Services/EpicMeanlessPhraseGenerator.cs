using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class EpicMeanlessPhraseGenerator : IEpicMeanlessPhraseGenerator
    {
        private IRandomBuilder _randomBuilder;
        private List<string> FirstWords = new List<string> { "Закат", "Рассвет" };
        private List<string> SecondWords = new List<string> { "Кровавый", "Нежный", "Наивный" };

        public EpicMeanlessPhraseGenerator(IRandomBuilder randomBuilder)
        {
            _randomBuilder = randomBuilder;
        }

        public string Generate()
        {
            var random = _randomBuilder.GetRandom();
            var firstIndex = random.Next(FirstWords.Count);
            var secondIndex = random.Next(SecondWords.Count);
            return $"{SecondWords[secondIndex]} {FirstWords[firstIndex]}";
        }
    }
}

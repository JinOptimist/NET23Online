using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class AnimeGirlGenerator : IAnimeGirlGenerator
    {
        private IEpicMeanlessPhraseGenerator _phraseGenerator;
        private IRandomBuilder _randomBuilder;

        public AnimeGirlGenerator(IEpicMeanlessPhraseGenerator epicMeanlessPhraseGenerator, 
            IRandomBuilder randomBuilder)
        {
            _phraseGenerator = epicMeanlessPhraseGenerator;
            _randomBuilder = randomBuilder;
        }

        public List<AnimeGirlImageInfoViewModel> GenerateList(int count)
        {
            var viewModels = new List<AnimeGirlImageInfoViewModel>();
            viewModels.Add(new AnimeGirlImageInfoViewModel
            {
                Url = "https://img.freepik.com/premium-photo/hand-drawn-cartoon-anime-girl-illustration-camouflage-uniform_561641-5662.jpg",
                Title = _phraseGenerator.Generate()
            });
            viewModels.Add(new AnimeGirlImageInfoViewModel
            {
                Url = "https://img.freepik.com/free-photo/anime-character-winter_23-2151843487.jpg?semt=ais_hybrid&amp;w=740",
                Title = _phraseGenerator.Generate()
            });
            viewModels.Add(new AnimeGirlImageInfoViewModel
            {
                Url = "https://i.pinimg.com/474x/ed/3a/e8/ed3ae86ab479861a1e10e8d0caaf04de.jpg?nii=t",
                Title = _phraseGenerator.Generate()
            });

            return viewModels
                .Take(count)
                .ToList();
        }

        public AnimeGirlImageInfoViewModel Generate()
        {
            return new AnimeGirlImageInfoViewModel
            {
                Url = "https://i.pinimg.com/474x/ed/3a/e8/ed3ae86ab479861a1e10e8d0caaf04de.jpg?nii=t",
                Title = _phraseGenerator.Generate()
            };
        }
    }
}

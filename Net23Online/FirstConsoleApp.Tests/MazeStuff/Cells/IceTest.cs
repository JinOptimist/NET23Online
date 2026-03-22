using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Moq;
using NUnit.Framework;

namespace FirstConsoleApp.Tests.MazeStuff.Cells
{

    public class IceTest
    {
        private Ice _ice;
        private Mock<IBaseCharacter> _baseCharacterMock;
        private Mock<IMaze> _mazeMock;
        [SetUp]
        public void Setup()
        {

            _mazeMock = new Mock<IMaze>();


            _mazeMock.Setup(x => x.Surface.Remove(It.IsAny<IBaseCell>()));
            _mazeMock.Setup(x => x.Surface.Add(It.IsAny<IBaseCell>()));
            _mazeMock.Setup(x => x.EventHistory.Add(It.IsAny<string>()));

            _baseCharacterMock = new Mock<IBaseCharacter>();
            _baseCharacterMock.SetupProperty(x => x.Hp, 50);
            _baseCharacterMock.SetupProperty(x => x.Speed, 5);

            _baseCharacterMock.Setup(x => x.HasHp(It.IsAny<int>()))
                .Returns<int>(cost => _baseCharacterMock.Object.Hp > cost);

            _baseCharacterMock.Setup(x => x.HasSpeeds(It.IsAny<int>()))
                .Returns<int>(cost => _baseCharacterMock.Object.Speed >= cost);

            _baseCharacterMock.Setup(x => x.SpendHp(It.IsAny<int>()))
                .Callback<int>(amount =>
                {
                    var initialHp = _baseCharacterMock.Object.Hp;
                    _baseCharacterMock.Object.Hp = Math.Max(0, initialHp - amount);
                });

            _baseCharacterMock.Setup(x => x.SpendSpeed(It.IsAny<int>()))
                .Callback<int>(amount =>
                {
                    var initialSpeed = _baseCharacterMock.Object.Speed;
                    _baseCharacterMock.Object.Speed = Math.Max(0, initialSpeed - amount);
                });

            _baseCharacterMock.Setup(x => x.GameOver());

            var maze = _mazeMock.Object;
            _ice = new Ice(maze);


        }


        [Test]
        [TestCase(100, 5, 99, 4)]
        [TestCase(50, 3, 49, 2)]
        [TestCase(10, 10, 9, 9)]
        public void Interaction_ShouldSpendHpAndSpeed(
        int initialHp,
        int initialSpeed,
        int resultHp,
        int resultSpeed)
        {

            var character = _baseCharacterMock.Object;
            character.Hp = initialHp;
            character.Speed = initialSpeed;


            _ice.Interaction(character);

            Assert.Multiple(() =>
            {
                Assert.That(character.Hp, Is.EqualTo(resultHp));
                Assert.That(character.Speed, Is.EqualTo(resultSpeed));
            });
        }




        [Test]
        [TestCase(1)]
        [TestCase(0)]
        public void Interaction_WithLastLife_ShouldGameOver(int initialHp)
        {

            var character = _baseCharacterMock.Object;
            character.Hp = initialHp;

            var result = _ice.Interaction(character);

            _mazeMock.Verify(
                x => x.EventHistory.Add("LAST LIFE LOST, It's An Ice"),
                Times.Once());
            Assert.That(result, Is.False);
        }


        [Test]
        public void Interaction_WithLowSpeed_ShouldAddFreezingEvent()
        {

            var character = _baseCharacterMock.Object;

            character.Speed = 0;


            _ice.Interaction(character);


            _mazeMock.Verify(
                x => x.EventHistory.Add("You are freezing!"),
                Times.Once());
        }
        [Test]
        public void Interaction_ShouldReplaceIceWithGround()
        {
            var character = _baseCharacterMock.Object;
            _ice.Interaction(character);

            _mazeMock.Verify(
                x => x.Surface.Remove(_ice),
                Times.Once());

            _mazeMock.Verify(
                x => x.Surface.Add(It.IsAny<Ground>()),
                Times.Once());
        }
        [Test]
        public void Interaction_WithEnoughResources_ShouldReturnTrue()
        {

            var character = _baseCharacterMock.Object;


            var result = _ice.Interaction(character);


            Assert.That(result, Is.True);
        }

    }
}

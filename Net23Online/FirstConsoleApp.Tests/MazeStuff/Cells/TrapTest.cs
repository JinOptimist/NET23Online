using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Moq;
using NUnit.Framework;

namespace FirstConsoleApp.Tests.MazeStuff.Cells
{
    internal class TrapTest
    {
        private Trap _trap;
        private Mock<IBaseCharacter> _baseCharacterMock;
        private Mock<IBaseCell> _baseCellMock;
        private Mock<IMaze> _mazeMock;

        [SetUp]
        public void TrapSetup()
        {
            _baseCharacterMock = new Mock<IBaseCharacter>();
            _baseCellMock = new Mock<IBaseCell>();
            _mazeMock = new Mock<IMaze>();

            var baseCell = _baseCellMock.Object;
            var maze = _mazeMock.Object;

            _baseCharacterMock.SetupProperty(character => character.Hp);
            _mazeMock.Setup(x => x.EventHistory.Add(It.IsAny<string>()));
            _mazeMock.Setup(x => x.Surface.Add(It.IsAny<IBaseCell>()));
            _mazeMock.Setup(x => x.Surface.Remove(It.IsAny<IBaseCell>()));

            //Переопределять soundPlayer.PlayMusic не нужно тк объект MazeSoundPlayer создвается внутри метода (MazeSoundPlayer soundPlayer = new MazeSoundPlayer();)?

            _trap = new Trap(maze);

        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(100, 99)]
        [TestCase(-2, -3)]
        public void Interaction_HPAreDecreases(int startHP, int resultHP)

        {
            // Prepare
            var baseCharacter = _baseCharacterMock.Object;
            baseCharacter.Hp = startHP;

            // Act
            _trap.Interaction(baseCharacter);  

            // Assert
            Assert.That(baseCharacter.Hp, Is.EqualTo(resultHP), $"HP start = {startHP} must decreases by 1. Result: {resultHP}");
        }

        [Test]
        public void Interaction_TrapWasReplacedByGround()
        {
            // Preapere

            //Act
            _trap.Interaction(_baseCharacterMock.Object);

            // Assert
            _mazeMock.Verify(x => x.Surface.Remove(_trap), Times.Once());
            _mazeMock.Verify(x => x.Surface.Add(It.IsAny<Ground>()), Times.Once());
        }

        public void Inetraction_CanStepOnTrap()
        {
            // Act
            var result = _trap.Interaction(_baseCharacterMock.Object);

            // Assert

            Assert.That(result, Is.EqualTo(true));
        }

        public void Interaction_IsMusicPlaying()
        {
            //Prepare

            var soundPlayerMock = new Mock<IMazeSoundPlayer>(); //У нас создается в методе Interaction создавался реальный объект
            _trap.soundPlayer = soundPlayerMock.Object;

            // Act
            _trap.Interaction(_baseCharacterMock.Object);

            // Assert

            soundPlayerMock.Verify(x => x.PlayMusic("trap_sound.wav", It.IsAny<float>(), It.IsAny<bool>()), Times.Once());

        }
    }
}

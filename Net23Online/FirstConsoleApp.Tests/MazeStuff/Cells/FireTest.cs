using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Moq;
using NUnit.Framework;
using FirstConsoleApp.MazeStuff;

namespace FirstConsoleApp.Tests.MazeStuff.Cells
{
    public class FireTest
    {
        private Fire _fire;
        private Mock<IBaseCharacter> _characterMock;
        private Mock<IMaze> _mazeMock;
        private Mock<IAudioPlayer> _audioMock;

        [SetUp]
        public void Setup()
        {
            _mazeMock = new Mock<IMaze>();

            _mazeMock.Setup(x => x.Surface.Remove(It.IsAny<BaseCell>()));
            _mazeMock.Setup(x => x.Surface.Add(It.IsAny<BaseCell>()));
            _mazeMock.Setup(x => x.EventHistory.Add(It.IsAny<string>()));

            var maze = _mazeMock.Object;

            _characterMock = new Mock<IBaseCharacter>();
            _characterMock.SetupProperty(x => x.Hp);

            _audioMock = new Mock<IAudioPlayer>();

            _fire = new Fire(maze);

            _fire.soundPlayerForCells = _audioMock.Object;
        }

        [Test]
        [TestCase(10, 9)]
        [TestCase(1, 0)]
        public void Interaction_ShouldDecreaseHp(int initialHp, int expectedHp)
        {
            // Arrange
            var character = _characterMock.Object;
            character.Hp = initialHp;

            // Act
            _fire.Interaction(character);

            // Assert
            Assert.That(character.Hp, Is.EqualTo(expectedHp));
        }

        [Test]
        public void Interaction_ShouldReturnTrue()
        {
            // Act
            var result = _fire.Interaction(_characterMock.Object);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Interaction_ShouldAddEventToHistory()
        {
            // Act
            _fire.Interaction(_characterMock.Object);

            // Assert
            _mazeMock.Verify(
                x => x.EventHistory.Add("You're on fire!"),
                Times.Once
            );
        }

        [Test]
        public void Interaction_ShouldRemoveFireFromMaze()
        {
            // Act
            _fire.Interaction(_characterMock.Object);

            // Assert
            _mazeMock.Verify(x => x.Surface.Remove(_fire), Times.Once);
        }

        [Test]
        public void Interaction_ShouldAddGroundToMaze()
        {
            // Act
            _fire.Interaction(_characterMock.Object);

            // Assert
            _mazeMock.Verify(
                x => x.Surface.Add(It.IsAny<Ground>()),
                Times.Once
            );
        }

        [Test]
        public void Interaction_ShouldPlayFireSound()
        {
            // Act
            _fire.Interaction(_characterMock.Object);

            // Assert
            _audioMock.Verify(
                x => x.Play("fire_sound.wav", 0.5f, It.IsAny<bool>()),
                Times.Once
            );
        }
    }
}
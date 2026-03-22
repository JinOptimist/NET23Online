using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Moq;
using NUnit.Framework;


namespace FirstConsoleApp.Tests.MazeStuff.Cells
{
    public class StrangerTest
    {
        private Stranger _stranger;
        private Mock<IBaseCharacter> _baseCharacterMock;
        private Mock<IMaze> _mazeMock;

        [SetUp]
        public void Setup()
        {
            _mazeMock = new Mock<IMaze>();
            _mazeMock
                .Setup(x => x.EventHistory.Add(It.IsAny<string>()));
            var maze = _mazeMock.Object;
            _stranger = new Stranger(maze);
            _baseCharacterMock = new Mock<IBaseCharacter>();
        }

        [Test]
        public void Iteraction_CanMeetStranger()
        {
            // Prepare

            // Act
            var result = _stranger.Interaction(_baseCharacterMock.Object);

            // Assert
            Assert.That(result, Is.EqualTo(true), $"You can iteract with Stranger");
        }

        [Test]
        public void Iteraction_CanStoreEventHistory()
        {

            // Prepare

            // Act
            _stranger.Interaction(_baseCharacterMock.Object);

            // Assert
            _mazeMock.Verify(x => x.EventHistory.Add(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}

using FirstConsoleApp.MazeStuff;
using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Moq;
using NUnit.Framework;

namespace FirstConsoleApp.Tests.MazeStuff.Cells
{
    internal class SecretRoomTest
    {
        private SecretRoom _secretRoom;
        private Mock<IMaze> _mazeMock;
        private Mock<IBaseCharacter> _baseCharacterMock;
        private Mock<IMazeController> _secretRoomControllerMock; //Это другой secretRoomControllerMock

        [SetUp]
        public void Setup()
        {
            _mazeMock = new Mock<IMaze>();
            _mazeMock.Setup(x => x.EventHistory.Add(It.IsAny<string>()));
            _mazeMock.Setup(x => x.Surface.Remove(It.IsAny<IBaseCell>()));
            _mazeMock.Setup(x => x.Surface.Add(It.IsAny<IBaseCell>()));

            _baseCharacterMock = new Mock<IBaseCharacter>();

            //Hero hero= (Hero)_baseCharacterMock.Object;
            _secretRoomControllerMock = new Mock<IMazeController>();
            _secretRoomControllerMock.Setup(x => x.Play(It.IsAny<int>(), It.IsAny<int>(), true, It.Is<Hero>(x => x != null)));

            _secretRoom = new SecretRoom(_mazeMock.Object);

        }

        // [Test]
        public void Inreacrtion_SecretRoomUsedReplce()
        {
            // Prepare
            var secretRoomMock = new Mock<SecretRoom>(_baseCharacterMock.Object);
            var secretRoom = secretRoomMock.Object;

            // Act
            _secretRoom.Interaction(_baseCharacterMock.Object);

            // Assert
            // secretRoomMock.Verify(x => x.Replace());
            // Проверяем сам вызов Replace в методе Inreacrtion. А на метод Replace отдельный тест
        }

        [Test]
        public void Replace_SecretRoomWasReplasedByGround()
        {
            // Act
            _secretRoom.Interaction(_baseCharacterMock.Object);

            // Assert
            _mazeMock.Verify(x => x.Surface.Remove(_secretRoom), Times.Once());
            _mazeMock.Verify(x => x.Surface.Add(It.IsAny<Ground>()), Times.Once());
        }

        [Test]
        public void Interaction_SecretRoomAddEventHistory()
        {
            // Act
            _secretRoom.Interaction(_baseCharacterMock.Object);

            // Assert
            _mazeMock.Verify(x => x.EventHistory.Add(It.IsAny<string>()), Times.Once());

        }

        [Test]
        public void Interaction_StartSecretMaze()
        {
            // Prepare
            //Сохраняет конструктор, не виртуальные методы переопределить нельзя
            //Mock<MazeController> secretRoomControllerMock = new Mock<MazeController>();

            var secretRoomController = _secretRoomControllerMock.Object;

            // Act
            _secretRoom.Interaction(_baseCharacterMock.Object);
            //Hero hero= (Hero)_baseCharacterMock.Object;

            // Assert
            _secretRoomControllerMock.Verify(x => x.Play(It.IsAny<int>(), It.IsAny<int>(), true, It.Is<Hero>(x => x != null)), Times.Once(),
                $"Optional parameters must be isSecretMaze=true and Hero=hero");

        }

        [Test]
        public void Interaction_CanStepOnSecretRoom()
        {
            // Prepare
            var baseCharacter = _baseCharacterMock.Object;

            // Act
            var actual = _secretRoom.Interaction(baseCharacter);

            // Assert
            Assert.That(actual, Is.EqualTo(true));

        }

    }
}

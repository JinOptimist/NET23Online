using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
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

            _baseCharacterMock.SetupProperty(character => character.Hp); //Настройка свойства (геттеры, сеттеры)
            _mazeMock.Setup(x => x.EventHistory.Add(It.IsAny<string>()));
            _mazeMock.Setup(x => x.Surface.Add(It.IsAny<IBaseCell>()));
            _mazeMock.Setup(x => x.Surface.Remove(It.IsAny<IBaseCell>()));

            //Переопределять soundPlayer.PlayMusic не нужно тк объект MazeSoundPlayer создвается внутри метода (MazeSoundPlayer soundPlayer = new MazeSoundPlayer();)

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

            //Act
            //- ХП меняется при взаимодействии с методом Interaction класса Trap => нам нужно этот метод вызвать
            _trap.Interaction(baseCharacter); //Метод выполнил какие-то свои действия. Результаты выполнения действий (или сам факт выполнения действий) мы проверяем в Assert.
                                              //baseCharacter.Hp уже должно поменяться на resultHP мы это и будем проверять.
                                              //Метод может выполнять действия, которые будут зависеть от других классов (их объектов), а у нас этих объектов
                                              //(т.е ссылка null) нужно переопределить эти методы, чтобы они не зависили от null
                                              //(Метод пытается положить вызвать Add для Event History в Maze, а у нас maze null)  

            //Assert
            Assert.That(baseCharacter.Hp, Is.EqualTo(resultHP), $"HP start = {startHP} must decreases by 1. Result: {resultHP}");
        }
    }
}

using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Moq;
using NUnit.Framework;

namespace FirstConsoleApp.Tests.MazeStuff.Cells;

public class PortalTest
{
    private Portal _portal;
    private Portal _linkedPortal;
    private Mock<IBaseCharacter> _baseCharacterMock;
    private Mock<IMaze> _mazeMock;
    private Mock<IInputReader> _inputReaderMock;

    [SetUp]
    public void Setup()
    {
        _mazeMock = new Mock<IMaze>();
        _mazeMock
            .Setup(x => x.EventHistory.Add(It.IsAny<string>()));
        _mazeMock
            .Setup(x => x.Surface.Add(It.IsAny<IBaseCell>()));
        _mazeMock
            .Setup(x => x.Surface.Remove(It.IsAny<IBaseCell>()));
        var maze = _mazeMock.Object;

        _baseCharacterMock = new Mock<IBaseCharacter>();
        _baseCharacterMock
            .SetupProperty(x => x.X);
        _baseCharacterMock
            .SetupProperty(y => y.Y);
        
        _inputReaderMock  = new Mock<IInputReader>();
        var inputReader = _inputReaderMock.Object;

        _portal = new Portal(maze, inputReader);
        _linkedPortal = new Portal(maze, inputReader);
        _portal.LinkedPortal = _linkedPortal;
    }
    
    [Test]
    [TestCase(0, 1, 5, 5)]
    public void Interaction_CharacterWasTeleported(int xOld, int yOld, int xNew, int yNew)
    {
        //Prepare
        _portal.X = xOld;
        _portal.Y = yOld;
        _linkedPortal.X = xNew;
        _linkedPortal.Y = yNew;
        
        _inputReaderMock
            .Setup(x => x.ReadKey()).Returns(ConsoleKey.Y);
        
        //Act
        //Как проверять Readkey?
        //Мой тест не работает так как ждет ввода с консоли
        var baseCharacter = _baseCharacterMock.Object;
        _portal.Interaction(baseCharacter);
        
        //Assert
        Assert.That(baseCharacter.X, Is.EqualTo(xNew));
        Assert.That(baseCharacter.Y, Is.EqualTo(yNew));
        
    }
}
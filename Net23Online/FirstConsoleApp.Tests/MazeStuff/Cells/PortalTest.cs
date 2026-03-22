using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstConsoleApp.Tests.MazeStuff.Cells
{
    internal class PortalTest
    {
        private Portal _portal;
        //private Mock<Portal> _linkedPortalMock;
        private Portal _linkedPortal;
        private Mock<IMaze> _mazeMock;
        private Mock<IBaseCharacter> _baseCharacterMock;

        [SetUp]
        public void Setup()
        {
            _mazeMock = new Mock<IMaze>();
            _mazeMock.Setup(x => x.EventHistory.Add(It.IsAny<string>()));
            _mazeMock.Setup(x => x.Surface.Remove(It.IsAny<IBaseCell>()));
            _mazeMock.Setup(x => x.Surface.Add(It.IsAny<IBaseCell>()));

            _baseCharacterMock = new Mock<IBaseCharacter>();
            _baseCharacterMock.SetupProperty(character => character.X);
            _baseCharacterMock.SetupProperty(character => character.Y);

            //_linkedPortalMock = new Mock<Portal>();
            //_linkedPortalMock.Setup(linkedPortal => linkedPortal.X).Returns(5);
            //_linkedPortalMock.Setup(linkedPortal => linkedPortal.Y).Returns(5);
            _linkedPortal = new Portal(_mazeMock.Object)
            {
                X = 5,
                Y = 5
            };

            _portal = new Portal(_mazeMock.Object)// real portal
            {
                //LinkedPortal = _linkedPortalMock.Object
                LinkedPortal = _linkedPortal
            };

            _mazeMock.Object.Surface.Add(_portal);
            _mazeMock.Object.Surface.Add(_linkedPortal);
        }

        [Test]
        public void Interaction_PortalIsNotUsed()
        {
            // Prepare

            Console.SetIn(new System.IO.StringReader("N"));

            // Act
            bool IsPortalUsed = _portal.Interaction(_baseCharacterMock.Object);

            // Assert
            Assert.That(IsPortalUsed, Is.EqualTo(true));
        }

        [Test]
        public void Interaction_PortalIsUsed()
        {
            // Prepare

            Console.SetIn(new System.IO.StringReader("Y"));

            // Act
            bool IsPortalUsed = _portal.Interaction(_baseCharacterMock.Object);

            // Assert
            Assert.That(IsPortalUsed, Is.EqualTo(false));
            Assert.That(_baseCharacterMock.Object.X, Is.EqualTo(5));
            Assert.That(_baseCharacterMock.Object.Y, Is.EqualTo(5));

        }

        [Test]
        public void Interaction_HeroCoordinatesChanged()
        {
            // Prepare
            Console.SetIn(new System.IO.StringReader("Y"));

            // Act
            _portal.Interaction(_baseCharacterMock.Object);

            // Assert
            Assert.That(_baseCharacterMock.Object.X, Is.EqualTo(5));
            Assert.That(_baseCharacterMock.Object.Y, Is.EqualTo(5));

        }

    }
}

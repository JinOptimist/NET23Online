using Moq;
using NUnit.Framework;
using FirstConsoleApp.MazeStuff;
using FirstConsoleApp.MazeStuff.Interfaces;
using NAudio.Wave;

namespace FirstConsoleApp.Tests.MazeStuff
{
    public class MazeSoundPlayerTests
    {
        private Mock<IAudioOutput> _outputMock;
        private Mock<IAudioFile> _audioFileMock;

        private MazeSoundPlayer _soundPlayer;

        [SetUp]
        public void Setup()
        {
            _outputMock = new Mock<IAudioOutput>();
            _audioFileMock = new Mock<IAudioFile>();
            _audioFileMock
                .Setup(x => x.GetWaveProvider())
                .Returns(Mock.Of<IWaveProvider>());

            _soundPlayer = new MazeSoundPlayer(
                _outputMock.Object,
                _ => _audioFileMock.Object
            );
        }
        [Test]
        [TestCase(0.5f, 0.5f)]
        [TestCase(-1f, 0f)]
        [TestCase(2f, 1f)]
        public void PlayShouldSetCorrectVolume(float input, float expected)
        {
            // Act
            _soundPlayer.Play("test.mp3", input, false);

            // Assert
            _audioFileMock.VerifySet(x => x.Volume = expected, Times.Once);
        }

        [Test]
        public void PlayShouldInitializeOutput()
        {
            // Act
            _soundPlayer.Play("test.mp3", 0.3f, false);

            // Assert
            _outputMock.Verify(
                x => x.Init(It.IsAny<IWaveProvider>()),
                Times.Once
            );
        }

        [Test]
        public void PlayShouldCallPlayOnOutput()
        {
            // Act
            _soundPlayer.Play("test.mp3", 0.3f, false);

            // Assert
            _outputMock.Verify(x => x.Play(), Times.Once);
        }

        [Test]
        public void PlayShouldCallAudioFactory()
        {
            bool factoryCalled = false;

            var player = new MazeSoundPlayer(
                _outputMock.Object,
                path =>
                {
                    factoryCalled = true;
                    return _audioFileMock.Object;
                });

            // Act
            player.Play("test.mp3", 0.3f, false);

            // Assert
            Assert.That(factoryCalled, Is.True);
        }

        [Test]
        public void PlayShouldPassCorrectPathToFactory()
        {
            string? receivedPath = null;

            var player = new MazeSoundPlayer(
                _outputMock.Object,
                path =>
                {
                    receivedPath = path;
                    return _audioFileMock.Object;
                });

            // Act
            player.Play("sound.mp3", 0.3f, false);

            // Assert
            Assert.That(receivedPath, Does.Contain("sound.mp3"));
        }
    }
}
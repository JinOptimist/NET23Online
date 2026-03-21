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

        private MazeSoundPlayer _player;

        [SetUp]
        public void Setup()
        {
            _outputMock = new Mock<IAudioOutput>();
            _audioFileMock = new Mock<IAudioFile>();

            // важно: возвращаем фейковый IWaveProvider
            _audioFileMock
                .Setup(x => x.GetWaveProvider())
                .Returns(Mock.Of<IWaveProvider>());

            _player = new MazeSoundPlayer(
                _outputMock.Object,
                _ => _audioFileMock.Object
            );
        }

        // ✅ 1. Проверка установки громкости
        [Test]
        [TestCase(0.5f, 0.5f)]
        [TestCase(-1f, 0f)]
        [TestCase(2f, 1f)]
        public void Play_ShouldSetCorrectVolume(float input, float expected)
        {
            // Act
            _player.Play("test.mp3", input, false);

            // Assert
            _audioFileMock.VerifySet(x => x.Volume = expected, Times.Once);
        }

        // ✅ 2. Проверка вызова Init
        [Test]
        public void Play_ShouldInitializeOutput()
        {
            // Act
            _player.Play("test.mp3", 0.3f, false);

            // Assert
            _outputMock.Verify(
                x => x.Init(It.IsAny<IWaveProvider>()),
                Times.Once
            );
        }

        // ✅ 3. Проверка вызова Play
        [Test]
        public void Play_ShouldCallPlayOnOutput()
        {
            // Act
            _player.Play("test.mp3", 0.3f, false);

            // Assert
            _outputMock.Verify(x => x.Play(), Times.Once);
        }

        // ✅ 4. Проверка, что создаётся аудиофайл через фабрику
        [Test]
        public void Play_ShouldCallAudioFactory()
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

        // ✅ 5. Проверка передачи корректного пути (дополнительно)
        [Test]
        public void Play_ShouldPassCorrectPathToFactory()
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
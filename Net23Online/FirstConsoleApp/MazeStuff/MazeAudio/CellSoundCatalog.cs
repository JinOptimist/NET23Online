using FirstConsoleApp.MazeStuff.Cells;

namespace FirstConsoleApp.MazeStuff.MazeAudio
{
    public record CellSoundCue(string FileName, float Volume, bool loop);

    public static class CellSoundCatalog
    {
        private const float DefaultVolume = 0.3f;
        private const bool DefaultLoop = false;

        private static readonly Dictionary<string, CellSoundCue> Cues = new()
        {
            [nameof(Coin)] = new CellSoundCue("coin_sound.mp3", DefaultVolume, DefaultLoop),
            [nameof(Ice)] = new CellSoundCue("ice_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(Key)] = new CellSoundCue("key_sound.wav", 0.6f, DefaultLoop),
            [nameof(Lava)] = new CellSoundCue("lava_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(Rest)] = new CellSoundCue("rest_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(Wall)] = new CellSoundCue("wall_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(Trap)] = new CellSoundCue("trap_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(SpeedPotions)] = new CellSoundCue("speedpotion_sound.flac", DefaultVolume, DefaultLoop),
            [nameof(SuperPower)] = new CellSoundCue("superpower_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(Doors)] = new CellSoundCue("door_sound.mp3", 0.7f, DefaultLoop),
            [nameof(SkipingMove)] = new CellSoundCue("pit_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(Mimic)] = new CellSoundCue("mimic_sound.mp3", DefaultVolume, DefaultLoop),
            [nameof(Portal)] = new CellSoundCue("portal_sound.wav", DefaultVolume, DefaultLoop),
            [nameof(MazeController)] = new CellSoundCue("maze_soundtrack.wav", 0.3f, true),
        };

        public static CellSoundCue GetCue(Type cellType)
        {
            if (cellType == null)
            {
                throw new ArgumentNullException(nameof(cellType));
            }

            if (Cues.TryGetValue(cellType.Name, out var cue))
            {
                return cue;
            }

            throw new KeyNotFoundException($"No sound configured for cell type '{cellType.Name}'.");
        }
    }
}

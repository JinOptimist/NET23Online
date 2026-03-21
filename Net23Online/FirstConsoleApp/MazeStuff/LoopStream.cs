using NAudio.Wave;

public class LoopStream : WaveStream
{
    private readonly WaveStream sourceStream;

    public LoopStream(WaveStream sourceStream)
    {
        this.sourceStream = sourceStream;
    }

    public override WaveFormat WaveFormat => sourceStream.WaveFormat;
    public override long Length => sourceStream.Length;

    public override long Position
    {
        get => sourceStream.Position;
        set => sourceStream.Position = value;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        var bytesRead = sourceStream.Read(buffer, offset, count);

        if (bytesRead == 0)
        {
            sourceStream.Position = 0;
            bytesRead = sourceStream.Read(buffer, offset, count);
        }

        return bytesRead;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            sourceStream?.Dispose();
        }
        base.Dispose(disposing);
    }
}
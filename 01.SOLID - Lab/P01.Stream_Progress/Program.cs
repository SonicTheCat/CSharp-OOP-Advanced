using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new File("e-book", 20, 10);
            Music song = new Music("Vesko M.", "unknown", 30, 20);
            Video video = new Video("Tarantino", 1_000_000, 190, 310);

            Calc(file);
            Calc(song);
            Calc(video);

        }

        static void Calc(IStreamProgressor file)
        {
            StreamProgressInfo stream = new StreamProgressInfo(file);
            Console.WriteLine(stream.CalculateCurrentPercent());
        }
    }
}

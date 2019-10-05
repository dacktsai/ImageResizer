using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");
            string writeLogPah = Path.Combine(Environment.CurrentDirectory, "runresult.txt");

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            sw.Stop();
            var showText = $"花費時間: {sw.ElapsedMilliseconds} ms";

            Console.WriteLine(showText);

            System.IO.StreamWriter logSW= new StreamWriter(writeLogPah, true);
            logSW.WriteLine(showText);
            logSW.Close();
            logSW.Dispose();
            Console.ReadKey();
        }
    }
}

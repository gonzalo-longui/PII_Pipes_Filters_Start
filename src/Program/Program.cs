using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PipeNull pipeNull = new PipeNull();
            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerial0 = new PipeSerial(filterNegative, pipeNull);
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerial1 = new PipeSerial(filterGreyscale, pipeSerial0);
            
            PictureProvider provider0 = new PictureProvider();
            IPicture picture = provider0.GetPicture("beer.jpg");

            PictureProvider provider1 = new PictureProvider();
            provider1.SavePicture(pipeSerial0.Send(picture), @"beer1.jpg");

            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(pipeSerial1.Send(picture), @"beer2.jpg");
        }
    }
}

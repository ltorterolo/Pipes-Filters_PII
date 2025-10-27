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
            PipeSerial pipeSerial2 = new PipeSerial(new FilterNegative(), pipeNull);
            PipeSerial pipeSerial1 = new PipeSerial(new FilterGreyscale(), pipeSerial2);

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../../../beer.jpg");
            
            //Acá va la serie de pipes
            var firstFilter = pipeSerial1.Send(picture);
            provider.SavePicture(firstFilter, @"../../../beer1.0.jpg");
            var secondFilter = pipeSerial2.Send(firstFilter);
            provider.SavePicture(secondFilter, @"../../../beer_final.jpg");
            var thirdFilter = pipeNull.Send(secondFilter);
        }
    }
}

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
            IPicture picture = provider.GetPicture(@"beer.jpg");
            
            //Acá va la serie de pipes
            var firstClone = picture.Clone();
            pipeSerial1.Send(firstClone);
            var secondClone = firstClone.Clone();
            pipeSerial2.Send(secondClone);
            var thirdClone = secondClone.Clone();
            pipeNull.Send(thirdClone);
            IPicture result = thirdClone.Clone();
            
            provider.SavePicture(result, @"beer1.jpg");
        }
    }
}

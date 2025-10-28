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
            PipeSerial pipeSerial3 = new PipeSerial(new FilterPersist(), pipeNull);
            PipeSerial pipeSerial4 = new PipeSerial(new FilterPersist(), pipeNull);
            PipeSerial pipeSerial1 = new PipeSerial(new FilterGreyscale(), pipeSerial2);
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../../../beer.jpg");
            
            //Acá va la serie de pipes
            var firstFilter = pipeSerial1.Send(picture);
            var savePicture = pipeSerial3.Send(firstFilter);
            var secondFilter = pipeSerial2.Send(firstFilter);
            var thirdFilter = pipeNull.Send(secondFilter);
            provider.SavePicture(thirdFilter, @"../../../beer_final.jpg");
            
            
            
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("text", @"PathToImage.png"));
        }
    }
}

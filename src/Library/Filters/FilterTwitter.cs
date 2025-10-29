using System;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters;

public class FilterTwitter : IFilter
{
    public void PublishToTwitter(string texto)
    {
        var twitter = new TwitterImage();
        Console.WriteLine(twitter.PublishToTwitter("text", @"PathToImage.png"));
    }
}

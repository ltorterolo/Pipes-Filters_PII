namespace CompAndDel.Filters;

public class FilterPersist : IFilter
{
    private PictureProvider _provider = new PictureProvider();
    private int n = 0;
    public IPicture Filter(IPicture image)
    {
        n++;
        _provider.SavePicture(image, $@"../../../beerV{n}.jpg");
        return image;
    }
}
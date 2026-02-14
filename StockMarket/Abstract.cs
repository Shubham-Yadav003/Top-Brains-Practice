public abstract class Product
{
    public string SKU {get; private set;}
    public string Name {get; private set;}
    public int Priority{get; private set;}

    private int stock;
    protected int threshold;

    public int Stock
    {
        get {return stock;}
        

    }
}
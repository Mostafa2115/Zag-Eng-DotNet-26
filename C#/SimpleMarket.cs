using System;
class Program
{
    static void Main(string[] args)
    {
        product product1 = new product("ice_cream", -50, category.Food);
        product1.getDetails();
    }
}

public enum category
{
    Food,
    Clothing,
    Electronics
}

class product
{
    private string name;
    private double price;
    private category Category;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public double Price
    {
        get { return price; }
        set { price = value > 0 ? value : 0; }
    }

    public struct Location
    {
        public int x;
        public int y;
    }

    public product(string name, double price, category category)
    {
        this.Name = name;
        this.Price = price;
        this.Category = category;
    }

    public void getDetails()
    {
        Console.WriteLine($"{this.Name} {this.Price} {this.Category}");
    }
}


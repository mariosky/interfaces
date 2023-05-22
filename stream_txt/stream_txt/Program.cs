
class Product
{
    public string code;
    public string description;
    public decimal price;

    public Product(string c, string d, decimal p)
    {
        code = c; description = d; price = p;
    }
}

class ProductDB
{
    public static void SaveProducts(List<Product> products)
    {
        StreamWriter txtOut = new StreamWriter(
                new FileStream("products.txt", FileMode.Create, FileAccess.Write));

        foreach (var p in products)
        {
            txtOut.WriteLine($"{p.code}|{p.description}|{p.price}");
        }

        txtOut.Close();

    }
}

class Program
{
    static void Main()
    {
        List<Product> productos = new();
        productos.Add(new Product("AAX", "Atari 2600", 190.99m));
        productos.Add(new Product("BBX", "NES", 290.99m));
        productos.Add(new Product("CCX", "Game Boy", 90.99m));

		ProductDB.SaveProducts(productos);

    }

}


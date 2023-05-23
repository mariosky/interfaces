using System.Text;

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

    public static void SaveProducts(List<Product> products)
    {
        FileStream fs = null;
        try {
            fs = new FileStream("products.txt", FileMode.Create, FileAccess.Write);
            using(StreamWriter txtOut = new StreamWriter(fs, Encoding.UTF8, 512))
            {
                foreach (var p in products)
                {
                    txtOut.WriteLine($"{p.code}|{p.description}|{p.price}");
                }
            }
        }
        finally {
            if (fs != null)
                fs.Dispose();
        }

    }

    public static void SaveProducts3(List<Product> products)
    {
            using(FileStream fs = new FileStream("products3.txt", FileMode.Create, FileAccess.Write))
            using(StreamWriter txtOut = new StreamWriter(fs, Encoding.UTF8, 512))
            {
                foreach (var p in products)
                {
                    txtOut.WriteLine($"{p.code}|{p.description}|{p.price}");
                }
            }

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

		ProductDB.SaveProducts3(productos);

    }

}


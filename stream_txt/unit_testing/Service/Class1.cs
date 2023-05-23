namespace Service;
using System.Text;

public class Product
{
    public string? code;
    public string? description;
    public decimal? price;
    public uint? likes;
    public uint? department;

    public Product(string? c, string? d, decimal? p, uint? l, uint? dep)
    {
        likes = l; 
        code = c; description = d; price = p; department = dep;
    }
}

public class ProductDB
{
    public static  List<Product> ReadProducts()
    {
        List<Product> prods = new();
        FileStream? fs = null;
        try {
            fs = new FileStream("products.txt", FileMode.Open, FileAccess.Read);
            using(StreamReader txtIn = new StreamReader(fs, Encoding.UTF8))
            {
                while (txtIn.Peek() != -1)
                {
                string? row = txtIn.ReadLine();
                if (row is not null)
                    {
                    string?[] cols = row.Split("|");
                    string? code = cols[0];
                    string? description = cols[1];
                    decimal? price = decimal.Parse(cols[2]!);
                    uint? likes = uint.Parse(cols[3]!);
                    uint? department = uint.Parse(cols[3]!);
                    prods.Add(new Product(code,description, price, likes, department));
                    }
                }
            }
        }
        finally {
            if (fs != null)
                fs.Dispose();
        }
        return prods;
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
                    txtOut.WriteLine($"{p.code}|{p.description}|{p.price}|{p.likes}|{p.department}");
                }
            }
        }
        finally {
            if (fs != null)
                fs.Dispose();
        }
    }
}


public class Product
{
    public string? code;
    public string? description;
    public decimal? price;
    public uint? likes;
    public uint? department;

    public Product(string? c, string? d, decimal? p, uint? l, uint? de)
    {
        code = c; description = d; price = p; 
        likes = l; department = de;
    }

    public override string ToString()
    {
        return String.Format($"{code} {description} {price}");
    }
}

public class UnitTest1
{

    [Fact]
    public void ReadProductsTxt()
    {
      List<Product> products = new();
      products.Add(new Product("AAA", "DescA", 12.22m, 12,  23));
      products.Add(new Product("BAA", "DescB", 12.22m, 12,  23));
      products.Add(new Product("CAA", "DescC", 12.22m, 12,  23));
    
      SaveProducts(products);

      List<Product> productsFF = new();
      productsFF = ProductDB.ReadProducts();
      Assert.Equal("AAA", productsFF[0].code);
      Assert.Equal("BAA", productsFF[1].code);
      Assert.Equal("CAA", productsFF[2].code);

      foreach(var p in productsFF)
          Console.WriteLine(p);
    }
    
    private static void SaveProducts(List<Product> products)
    {
        FileStream? fs = null;
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


namespace Service.Tests;
using System.Text;

public class UnitTest1
{
    [Fact]
    public void ProductClass()
    {
      Service.Product p = new Service.Product("AAA", "Desc", 12.22m, 12,  23);
      Assert.Equal("AAA",p.code);
    }

    [Fact]
    public void SaveProductsTxt()
    {
      List<Product> products = new();
      products.Add(new Service.Product("AAA", "DescA", 12.22m, 12,  23));
      products.Add(new Service.Product("BAA", "DescB", 12.22m, 12,  23));
      products.Add(new Service.Product("CAA", "DescC", 12.22m, 12,  23));
    
      ProductDB.SaveProducts(products);

      List<Product> productsFF = new();
      productsFF = ReadProducts();
      Assert.Equal("AAA", productsFF[0].code);
      Assert.Equal("BAA", productsFF[1].code);
      Assert.Equal("CAA", productsFF[2].code);
    }

    [Fact]
    public void ReadProductsTxt()
    {
      List<Product> products = new();
      products.Add(new Service.Product("AAA", "DescA", 12.22m, 12,  23));
      products.Add(new Service.Product("BAA", "DescB", 12.22m, 12,  23));
      products.Add(new Service.Product("CAA", "DescC", 12.22m, 12,  23));
    
      SaveProducts(products);

      List<Product> productsFF = new();
      productsFF = ProductDB.ReadProducts();
      Assert.Equal("AAA", productsFF[0].code);
      Assert.Equal("BAA", productsFF[1].code);
      Assert.Equal("CAA", productsFF[2].code);
    }
    
    private static List<Product> ReadProducts()
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
/*

    [Fact]
    public void PushStack()
    {
       Service.Stack<int> pila = new Service.Stack<int>(2);
       pila.Push(5);
       pila.Push(5);
       Action testCode = () => pila.Push(0);
       StackOverflowException exception = Assert.Throws<StackOverflowException>(testCode); 
       Assert.Equal("La pila está llena",exception.Message);
    }
    */
}

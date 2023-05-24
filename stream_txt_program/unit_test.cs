public class Product
{
    public string? code;
    public string? description;
    public decimal? price;
    // agrega el campo like
    // agrega el campo department
    // ambos son de tipo uint

    // modifica el constructor para inicializar los 
    // campos de like y department  
    public Product(string? c, string? d, decimal? p)
    {
        code = c; description = d; price = p; 
    }
}

public class UnitTest1
{
    [Fact]
    public void ProductClass()
    {
      Product p = new Product("AAA", "Desc", 12.22m, 12,  23);
      Assert.Equal("AAA",p.code);
    }

    [Fact]
    public void SaveProductsTxt()
    {
      List<Product> products = new();
      products.Add(new Product("AAA", "DescA", 12.22m, 12,  23));
      products.Add(new Product("BAA", "DescB", 12.22m, 12,  23));
      products.Add(new Product("CAA", "DescC", 12.22m, 12,  23));
    
      ProductDB.SaveProducts(products);

      List<Product> productsFF = new();
      productsFF = ReadProducts();
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
                Console.WriteLine(row);
                if (row is not null)
                    {
                    string?[] cols = row.Split("|");
                    string? code = cols[0];
                    string? description = cols[1];
                    decimal? price = decimal.Parse(cols[2]!);
                    uint? likes = uint.Parse(cols[3]!);
                    uint? department = uint.Parse(cols[4]!);
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

}

# interfaces
Actividades para el tema de Interfaces de la materia de Programación Orientada a Objetos

namespace Service;
using System.Text;

class Product
{
    public string code;
    public string description;
    public decimal price;
    public uint likes;
    public uint department;

    public Product(string c, string d, decimal p, uint dep)
    {
        likes = 0; 
        code = c; description = d; price = p; department = dep;
    }
}

class ProductDB
{
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

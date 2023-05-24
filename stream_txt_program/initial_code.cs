using System.Text;

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

public class ProductDB
{
    public static void SaveProducts(List<Product> products)
    {
        FileStream fs = null;
        try {
            // Crea el FileStream y asignalo a fs 
            // Vamos a crear el archivo y escribir 
            // fs = 
            using(StreamWriter txtOut = new StreamWriter(fs, Encoding.UTF8, 512))
            {
                foreach (var p in products)
                {
                    // Utiliza los métodos Write y WriteLine para 
                    // Agregar los productos al archivo
                    // Utiliza el caracter de barra vertical como separador
                }
            }
        }
        finally {
            if (fs != null)
                fs.Dispose();
        }
    }
}

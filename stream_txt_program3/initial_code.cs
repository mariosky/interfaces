using System.Text;

public class ProductDB
{
    public static  List<Product> ReadProducts()
    {
        // Lista que vamos a regresar
        List<Product> prods = new();
        // Creamos la referencia fs
        FileStream? fs = null;
        try {
            // Crea una instancia de FileStream
            // Completa las enumeracions FileMode y FileAccess
            
            fs = new FileStream("products.txt", FileMode. , FileAccess.);
            using(StreamReader txtIn = new StreamReader(fs, Encoding.UTF8))
            {
                while (txtIn.Peek() != -1)
                {
                string? row = txtIn.ReadLine();
                // leemos hasta el fin de archivo
                if (row is not null)
                    {
                    // Separa los campos de cada renglón
                    // en un arreglo llamado cols
                    // string?[] cols =  

                    string? code = cols[0];
                    string? description = cols[1];
                    decimal? price = decimal.Parse(cols[2]!);
                    // Agrega las variables que falten

                    // Agregamos un nuevo producto a la lista
                    // No modificar esta línea
                    prods.Add(new Product(code,description, price, 
                                likes, department));
                    }
                }
            }
        }
        finally {
            if (fs != null)
                fs.Dispose();
        }

        // REGRESA LA LISTA

    }
}

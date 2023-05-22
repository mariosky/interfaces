
Para escribir a un archivo de texto vamos a utilizar dos clases
complementarias: `FileStream` y `StreamWriter`, estas se utilizan para realizar
operaciones de escritura en archivos. Aunque ambas se pueden utilizar de manera independiente para
escribir en archivos, existen algunas diferencias clave entre ellas en términos
de funcionalidad.

### `FileStream`

1. Funcionalidad:
* FileStream: FileStream es una clase que se utiliza para leer y escribir
     bytes en un archivo. Proporciona métodos para realizar operaciones básicas
     de lectura y escritura a nivel de byte, como Read, Write, Seek y Close.
     FileStream se considera una clase de nivel inferior y trabaja a un nivel
     más bajo en términos de manipulación de bytes en un archivo.
* StreamWriter: StreamWriter es una clase que se utiliza para escribir texto
     en un archivo. Proporciona métodos para escribir cadenas y caracteres en
     un archivo, además de realizar tareas de codificación y formato.
     StreamWriter se considera una clase de nivel superior que se basa en
     FileStream y proporciona una interfaz más conveniente y fácil de usar para
     escribir texto en archivos.

2. Uso y sintaxis:

   - FileStream: Para utilizar FileStream, primero necesitas crear una instancia de la clase FileStream y especificar el archivo en el que deseas realizar operaciones de lectura o escritura. Luego, puedes utilizar los métodos disponibles en FileStream para leer o escribir bytes en el archivo. Aquí tienes un ejemplo de cómo se usa FileStream para escribir bytes en un archivo:

   ```csharp
   using (FileStream fs = new FileStream("archivo.txt", FileMode.Create))
   {
       byte[] data = Encoding.UTF8.GetBytes("Ejemplo de texto.");
       fs.Write(data, 0, data.Length);
   }
   ```

   - StreamWriter: Para utilizar StreamWriter, primero necesitas crear una instancia de la clase StreamWriter y especificar el archivo en el que deseas escribir el texto. Luego, puedes utilizar los métodos proporcionados por StreamWriter para escribir cadenas o caracteres en el archivo. Aquí tienes un ejemplo de cómo se usa StreamWriter para escribir texto en un archivo:
   ```csharp
   using (StreamWriter sw = new StreamWriter("archivo.txt"))
   {
       sw.WriteLine("Ejemplo de texto.");
   }
   ```

3. Características adicionales:
   - FileStream: Como FileStream trabaja a nivel de bytes, te permite realizar operaciones más avanzadas, como leer o escribir en ubicaciones específicas del archivo utilizando el método Seek.
   - StreamWriter: StreamWriter proporciona características adicionales específicas para escribir texto, como la capacidad de especificar el formato de codificación para el archivo, el uso de una memoria intermedia para almacenar datos antes de escribirlos en el archivo y la facilidad para escribir líneas completas de texto utilizando el método WriteLine.

En resumen, FileStream se utiliza principalmente para realizar operaciones de lectura y escritura a nivel de bytes, mientras que StreamWriter se utiliza para escribir texto en archivos de manera más conveniente. StreamWriter se basa en FileStream y proporciona una interfaz más fácil de usar para trabajar con texto.

### `StreamWriter`

La clase `StreamReader` nos permite leer archivos de texto. En el constructor
pasamos la ruta y nombre del archivo que vamos a leer. Podemos llamar
al método `ReadLine` para leer del archivo una línea de texto. En caso de
que lleguemos al fin del archivo, `ReadLine` nos regresará `null`.
En ejemplo siguiente, vemos como se utiliza la construcción `using` para 
desechar al objeto `sr` de manera implicita. 

```csharp
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
```

En las siguientes secciones veremos como leer y escribir el estado de los objetos
a archivos de texto y binarios.

#### Referencias

* Algunos partes son adaptadas del material de [dotnet/docs](https://github.com/dotnet/docs/) 
con licencia ***Attribution 4.0 International***, este material se comparte con la misma licencia. 

* Streams en [dotnet/docs](https://learn.microsoft.com/es-mx/dotnet/api/system.io.stream?view=net-7.0)


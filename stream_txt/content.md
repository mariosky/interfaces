### Cómo almacenar objetos a un archivo de texto

Para escribir a un archivo de texto vamos a utilizar dos clases
complementarias: `FileStream` y `StreamWriter`, estas se utilizan para realizar
operaciones de escritura en archivos en C#. Aunque ambas se pueden utilizar de
manera independiente, existen algunas diferencias clave entre ellas en
términos de su funcionalidad y manera de utilizarse:

1. Funcionalidad:
    * FileStream: es una clase que se utiliza para leer y escribir **bytes** en
      un archivo. Proporciona métodos para realizar operaciones de lectura y
      escritura a bajo nivel manipulando los bytes. Implementa los métodos Read,
      Write y Seek.

    * StreamWriter: proporciona métodos para escribir cadenas y caracteres a un
      archivo, realizando también tareas de codificación y formato. A
      `StreamWriter` se considera una clase de nivel superior, ya que no opera 
      en el ámbito de los bytes y por lo mismo es más fácil de utilizar.

2. Uso:
    - FileStream: Primero necesitamos crear una
         instancia de la clase `FileStream` y especificando como parámetro el archivo con el que 
         vamos a trabajar. Luego, podemos utilizar los
         métodos para leer o escribir bytes en el
         archivo. Vemos la operación a bajo nivel en el ejemplo a continuación. Cuando leemos, lo hacemos
         a un arreglo de bytes y al escribir 
         debemos especificar parámetros adicionales de posición y tamaño del arreglo. 

    ```csharp
    using (FileStream fs = new FileStream("archivo.txt", FileMode.Create))
    {
       byte[] data = Encoding.UTF8.GetBytes("Ejemplo");
       fs.Write(data, 0, data.Length);
    }
    ```

    - StreamWriter: Con `StreamWriter` simplemente utilizamos el método `WriteLine` y pasamos 
   directamente el objeto que deseamos almacenar. De manera similar a cuando escribimos en consola
   internamente se llama al método `ToString` para grabar el texto:

    ```csharp
    using (StreamWriter sw = new StreamWriter("archivo.txt"))
    {
        sw.WriteLine("Ejemplo de texto.");
    }
    ```

3. Características adicionales:
    - FileStream: Como `FileStream` trabaja a bajo nivel, nos permite realizar
     operaciones más avanzadas, como leer o escribir en ubicaciones específicas
     del archivo utilizando el método `Seek`.

    - StreamWriter: Nos proporciona métodos específicos para escribir texto, y
     podemos especificar el formato de codificación para el archivo, el uso de
     una memoria intermedia para almacenar datos antes de escribirlos en el
     archivo y podemos utilizar el método `WriteLine`.

#### Uso de `FileStream` y `StreamWriter`

Para este ejemplo vamos a utilizar `FileStream` y `StreamWriter` para almacenar en 
un archivo de texto objetos de la clase `Producto`:

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
```

La clase incluye dos campos públicos tipo `string` y un decimal. Vamos 
a crear una clase de utilería la cual llamaremos `ProductDB`, en ella 
vamos a agregar los métodos estáticos para guardar y leer instancias de `Producto`
a archivos de texto.

Para guardar el estado de los productos, utilizaremos una estrategia sencilla 
para separar los campos, vamos a utilizar un caracter especial como separador.
En este caso utilizaremos el caracter barra vertical `|`. Hay otras soluciones
estándar, por ejemplo, los archivos separados por coma, pero queremos una solución básica.

A continuación se muestra la implementación del método `SaveProducts`. Es un método
estático, y solo recibe como parámetro la lista con los productos que vamos a 
guardar al archivo. En esta primera prueba hemos dejado el nombre del archivo fijo (*hard-coded*) 
como `"products.txt"`, pero es mejor que este valor se reciba como parámetro (se dejará como ejercicio). 

```csharp
class ProductDB
{
   public static void SaveProducts(List<Product> products)
   {
    // Declaramos el FileStream fuera del bloque try 
    // para que sea visible en todo el bloque del método
    FileStream fs = null;
    try {
       // Instanciamos un objeto de FileStream
       // Vamos a crear el archivo y vamos a escribir en el
       fs = new FileStream("products.txt", FileMode.Create, 
                                                   FileAccess.Write);
       // Utilizamos 'using' para que se llame a Dispose implicitamente 
       using(StreamWriter txtOut = new StreamWriter(fs, Encoding.UTF8, 512))
       {
          foreach (var p in products)
          {
              // Escribimos una línea con los campos de cada objeto 
              // Separados por un '|'
              txtOut.WriteLine($"{p.code}|{p.description}|{p.price}");
          }
       }
   }
   // Optamos por llamar explicitamete al Dispose de fs, como ejemplo
   finally {
       // Solo se ejecuta si la referencia no es nula
      if (fs != null)
          fs.Dispose();
    }
  }
}
```
En el ejemplo utilizamos una instancia de `FileStream` para especificar el modo y tipo de acceso 
que utilizaremos al manipular el archivo. Esto lo especificamos utilzando las enumeraciones 
`FileMode` y `FileAccess`. 

Las opciones para el modo de apertura `FileMode` son: 

| Valor               | Descripción                                                                                                 |
|---------------------|-------------------------------------------------------------------------------------------------------------|
| `Append`            | Abre el archivo si existe y se posiciona al final de este. Si el archivo no existe, se crea uno nuevo.      |
| `Create`            | Crea un nuevo archivo. Si el archivo ya existe, se sobrescribe.                                             |
| `CreateNew`         | Crea un nuevo archivo. Si el archivo ya existe, se genera una excepción.                                    |
| `Open`              | Abre un archivo existente. Si el archivo no existe, se genera una excepción.                                |
| `OpenOrCreate`      | Abre el archivo si existe. Si no existe, se crea uno nuevo.                                                  |
| `Truncate`          | Abre un archivo existente y lo trunca a cero bytes. Si el archivo no existe, se genera una excepción.       |

Las opciones para el tipo de acceso son `FileAccess.Read`, `FileAccess.Write` y `FileAccess.ReadWrite`, 
indicando las operaciones que vamos a hacer en el archivo. 

A continuación se muestra otra versión donde se utiliza la construcción `using` para ambas instancias.

```csharp
public static void SaveProducts(List<Product> products)
{
  using(FileStream fs = new FileStream("products.txt", 
                                        FileMode.Create, FileAccess.Write))
  using(StreamWriter txtOut = new StreamWriter(fs, Encoding.UTF8, 512))
  {
    foreach (var p in products)
    {
      txtOut.WriteLine($"{p.code}|{p.description}|{p.price}");
    }
  }
}
```
Para probar nuestras clases vamos a crear una lista de productos y 
llamaremos el método `ProductDB.SaveProducts`.

```csharp
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

Al ejecutar el código deberíamos crear un archivo llamado `products.txt` que está
en la raíz del proyecto y tiene los siguientes datos:

```
AAX|Atari 2600|190.99
BBX|NES|290.99
CCX|Game Boy|90.99
```

#### Referencias

* Algunas partes son adaptadas del material de [dotnet/docs](https://github.com/dotnet/docs/) 
con licencia ***Attribution 4.0 International***, este material se comparte con la misma licencia. 

* Streams en [dotnet/docs](https://learn.microsoft.com/es-mx/dotnet/api/system.io.stream?view=net-7.0)


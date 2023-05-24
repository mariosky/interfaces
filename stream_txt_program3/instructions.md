### Lee objetos de la clase `Product` desde un archivo de texto

El archivo `"products.txt` contiene el estado 
de una colección de objetos de la clase `Product`:

```csharp
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
```

El archivo de texto tiene el siguiente formato:

```
AAA|DescA|12.22|12|23
BBB|De
```

Debes completar el método para que **regrese** una lista de tipo `List<Product>`
con los objetos que se haz leído del archivo.

Para hacer la lectura utilizaremos una instancia de `StreamReader`.

Puedes guardar tu código temporalmente en
<a href="https://gist.github.com/" target="_blank">GitHub Gist</a>

#### Notas:

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


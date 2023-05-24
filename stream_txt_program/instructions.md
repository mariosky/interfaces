### Guarda objetos de la clase Product a un archivo de texto

Sigue estos pasos para completar el programa:

1. Debes agregar dos nuevos campos a la clase producto,
   ambos deben ser enteros sin signo (`uint`) : `likes` y `department`.
   Es importante que los agregues a la clase en ese orden.

2. Debes crear una instancia de `FileStream` y asignarla `fs`.

3. El archivo que vamoa a crear se debe llamar `"products.txt`

4. Utilizando el separador de barra vertical `'|'` agrega una línea 
   por cada objeto, no se te olvide agregar el salto de línea. No
   debe haber espacio entre los campos, por ejemplo: 
   ```
   AAA|DescA|12.22|12|23
   BBB|DescB|32.99|123|23
   ```

Observa la manera en la que se desecha el archivo, esto 
es distinto a lo que vimos en clase.

Puedes guardar tu código temporalmente en
<a href="https://gist.github.com/" target="_blank">GitHub Gist</a>

---

#### Notas:

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


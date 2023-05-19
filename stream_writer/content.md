
## Objetos Peristentes

Un proceso es un programa en ejecución. El código fuente que escribimos en
algún lenguaje como C# o C++, se compila a código ejecutable, ya sea binario o
bytecode. Este código se ejecuta como un proceso y durante su ejecución se
crean y destruyen objetos. Cada objeto, requiere de cierto espacio de memoria y
existe por un determinado tiempo. No obstante, una vez que el proceso termina,
toda la memoria que tenía asignada el proceso, se libera para ser utilizada por
otros. Esto significa que todos los objetos creados por nuestro programa se
destruyen. Muchas veces necesitamos mantener el estado de nuestros objetos por
mucho tiempo, por ejemplo, en un sistema de control escolar o de comercio
electrónico es necesario contar siempre con la información de los alumnos y
nuestras compras. En estos casos necesitamos que nuestros objetos sean
persistentes.

En el modelo orientado a objetos, decimos que el estado de un objeto es
**persistente**, si su estado se mantiene aunque el proceso dónde se creó haya
terminado. Incluso, según la definción de Booch, un objeto persistente
trasciende el tiempo, ya que el objeto existe aún cuando la entidad que lo creó
haya dejado de existir. También se incluye como una propiedad de la
persistencia la capacidad de trascender el espacio, pues el objeto se puede
salir del espacio de memoria en el que se ha creado. 

Normalmente utilizamos sistemas de base de datos relacionales u orientadas a
objetos, para almacenar implementar la persistencia, ya que nos ofrecen una
solución escalable y la capacidad de mantener el estado consistente aun cuando
multiples procesos hagan modificaciones de manera concurrente. Este es un tema
que cae en otra materia, por lo que no lo abordaremos en este momento. 

Como una primera aproximación al tema, vamos utilizar archivos para almacenar
el estado de nuestros objetos. 

## Streams 

```csharp
interface IList
 {
  // Propiedad Count, con el número de elementos 
  // en la lista.
  int  Count { get; } 

  // Agrega un item a la lista, regresa la posición, o -1 si no 
  // fue posible agregar el elemento.
  int Add (object? value);

  // Borra un elemento  
  void Remove (object? value);

  // Regresa o modifica el elemento en el índice especificado
  object? this[int index] { get; set; }
  }
```


```csharp
using System.Collections;

public class Program 
{
    public static void Main() 
    {
    ArrayList objetos = new ArrayList();
    objetos.Add(5);
    objetos.Add(23.3m);
    objetos.Add("Hola");

    // No es posible convertir explicitamente de object a string
    // string? saludo = objetos[2];

    // Correcto: 
    string? saludo = (string?) objetos[2];
  
    // Warning: Unboxing de un posible valor nulo
    int z = 10 + (int) objetos[0];

    foreach(Object  o in objetos)
      Console.WriteLine(o);

    }
}
```

### Leer 

* [Programación Genérica](https://en.wikipedia.org/wiki/Generic_programming#Stepanov%E2%80%93Musser_and_other_generic_programming_paradigms)

#### Referencias

* Algunos partes son adaptadas del material de [dotnet/docs](https://github.com/dotnet/docs/) 
con licencia ***Attribution 4.0 International***, este material se comparte con la misma licencia. 




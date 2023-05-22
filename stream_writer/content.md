
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

Normalmente utilizamos sistemas de bases de datos relacionales u orientadas a
objetos, para gestionar la persistencia. Los sistemas de bases datos nos
ofrecen una solución escalable y la capacidad de mantener el estado de nuestros
objetos consistente aun cuando multiples procesos hagan modificaciones al mismo
tiempo. Este es un tema que cae en otra materia, por lo que no lo abordaremos
en este momento. Como una primera aproximación al tema, vamos utilizar archivos
para almacenar el estado de nuestros objetos. 

Para leer o escribir a un archivo, primero debemeos familarizarnos con los 
conceptos de flujos (streams en íngles) y buffers, ya que esto nos permitira entender mejor
el funcionamiento de las clases `StreamReader` y `StreamWriter` que veremos
a continuación.

## Streams 

En computación, un flujo  (en inglés *stream*), es una secuencia continua de
datos que se transmiten o procesan de manera progresiva. Al igual los articulos
que viajan en una banda transportadora, los datos de un stream son procesados
uno por uno. Actualmente los servicios de streaming de videos como Netflix, en
lugar de enviarnos el archivo completo de la película que queremos ver (lo cual
podría tardar mucho tiempo), utilizan precisamente streams para enviarnos la
película. Para esto, se divide primero el archivo en trozos (o paquetes), los
cuales se envían a nuestro dispositivo secuencialmente, uno tras otro, y los
vamos consumiendo a medida que llegan. El uso de streams, nos perimte procesar
potencialmente un número ilimitado de datos, ya que no estamos limitados por la
cantidad de memoria disponible localmente.

Nuestros programas utilizan esta misma estrategia para enviar o recibir datos a
otras entidades que están fuera del proceso, por ejemplo, archivos, servidores
remotos, la terminal o  el teclado.  

Los streams pueden ser de entrada o de salida, dependiendo de la dirección del
flujo de datos. Por ejemplo, un stream de entrada podría representar los datos
que se están leyendo de un archivo o se están recibiendo desde un dispositivo
de entrada, mientras que un stream de salida podría representar los datos que
se están escribiendo en un archivo o se están enviando a un dispositivo de
salida. 

## Buffers


## System.IO

La clase abstracta `Stream` y sus derivadas, no brindan un mecanismo abstracto 
para leer y escribir a múltiples entidades sin preocuparnos por los detalles de 
bajo nivel específicos al sistema operativo o los dispositivos subyacentes.  

Podemos realizar tres operaciones fundamentales utilizando streams:

* Podemos leer de un stream. Le llamamos lectura a transferir datos del stream 
a una estructura dentro de nuestro programa como una lista o un arreglo.

* Podemos escribir a un stream. Escribir es transferir datos de un arreglo en 
nuestro programa a un stream. 

* Podemos buscar (seek en inglés) en ciertos streams. La búsqueda hace referencia a la
  consulta y modificación de la posición actual dentro de un stream. La
  funcionalidad seek depende del tipo de memoria auxiliar con la que cuenta el stream.
  Por ejemplo, los flujos de red no tienen ningún concepto unificado
  de una posición actual y, por lo tanto, normalmente no admiten la búsqueda.


Para saber con que capacidades cuenta el stream que estemos utilizando el momento
dado, podemos consular las siguientes propiedades de la clase `Stream`: `CanRead`, 
`CanWrite` y `CanSeek` respectivamente.

Para realizar las operaciones descritas arriba, utilizaremos los métodos `Read` y `Write`. 
Por otro lado, para la búsqueda utilizaremos los métodos `Seek` y `SetLength` para  




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

* Streams en [dotnet/docs](https://learn.microsoft.com/es-mx/dotnet/api/system.io.stream?view=net-7.0)


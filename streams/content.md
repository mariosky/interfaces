
## Objetos Peristentes

Un proceso es un programa en ejecución. El código fuente que escribimos en
algún lenguaje como C# o C++, se compila a código ejecutable, ya sea binario o
bytecode. Este código se ejecuta como un proceso y durante su ejecución se
crean y destruyen objetos. Cada objeto requiere de cierto espacio de memoria y
existe por un determinado tiempo. No obstante, una vez que el proceso termina,
toda la memoria que tenía asignada el proceso, se libera para ser utilizada por
otros. Esto significa que todos los objetos creados por nuestro programa se
destruyen. Muchas veces necesitamos mantener el estado de nuestros objetos por
mucho tiempo, por ejemplo, en un sistema de control escolar o de comercio
electrónico es necesario contar siempre con la información de los alumnos y
nuestras compras. En estos casos necesitamos que nuestros objetos sean
persistentes.

En el modelo orientado a objetos, decimos que el estado de un objeto es
**persistente**, si su estado se mantiene, aunque el proceso dónde se creó haya
terminado. Incluso, según la definición de Booch, un objeto persistente
trasciende el tiempo, ya que el objeto existe aun cuando la entidad que lo creó
haya dejado de existir. También se incluye como una propiedad de la
persistencia la capacidad de trascender el espacio, pues el objeto se puede
salir del espacio de memoria en el que se ha creado. 

Normalmente, utilizamos sistemas de bases de datos relacionales u orientadas a
objetos, para gestionar la persistencia. Los sistemas de bases datos nos
ofrecen una solución escalable y la capacidad de mantener el estado de nuestros
objetos consistente aun cuando múltiples procesos hagan modificaciones al mismo
tiempo. Este es un tema que cae en otra materia, por lo que no lo abordaremos
en este momento. Como una primera aproximación al tema, vamos a utilizar archivos
para almacenar el estado de nuestros objetos. 

Para leer o escribir a un archivo, primero debemos familiarizarnos con los 
conceptos de flujos (streams en inglés) y buffers, ya que esto nos permitirá entender mejor
el funcionamiento de las clases `StreamReader` y `StreamWriter` que veremos
a continuación.

## Streams 

En computación, un flujo  (en inglés *stream*), es una secuencia continua de
datos que se transmiten o procesan de manera progresiva. Al igual los artículos
que viajan en una banda transportadora, los datos de un stream son procesados
uno por uno. Actualmente, los servicios de streaming de videos como Netflix, en
lugar de enviarnos el archivo completo de la película que queremos ver (lo cual
podría tardar mucho tiempo), utilizan precisamente streams para enviarnos la
película. Para esto, se divide primero el archivo en trozos (o paquetes), los
cuales se envían a nuestro dispositivo secuencialmente, uno tras otro, y los
vamos consumiendo a medida que llegan. El uso de streams, nos perimite procesar
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

Los datos fluyen desde o hacia nuestro programa desde diferentes fuentes: 

* Dispositivos IO (entrada-salida) como el teclado, la consola, impresora
* Archivos
* Memoria
* Un socket TCP/IP
* Tubería de comunicación interprocesos 
* Una conexión http

## Buffers

Siguiendo el ejemplo de Netflix, para evitar que la reproducción de la película
se detenga cuando tenemos una conexión a internet intermitente, se hace uso de
un búfer. Un búfer (buffer en inglés) se refiere a un área de memoria temporal utilizada para
almacenar datos antes de que sean procesados o enviados. En este caso, se
almacenan un búfer bloques de la película conforme van llegando, y se
reproducen constantemente los bloques ya están en el búfer. En caso de que el
búfer se vacíe, entonces necesitaremos esperar a que el búfer tenga datos
suficientes para seguir reproduciendo la película. Entonces, el búfer actúa
como un intermediario entre la fuente de datos y el destino, permitiendo una
transferencia más eficiente y controlada de la información.

## System.IO

La clase abstracta `Stream` y sus derivadas, no brindan un mecanismo abstracto 
para leer y escribir a múltiples entidades sin preocuparnos por los detalles de 
bajo nivel específicos al sistema operativo o los dispositivos subyacentes.
Las clases principales que heredan de `Stream` son `FileStream` y `MemoryStream`.

Podemos realizar estas tres operaciones utilizando streams:

* Podemos leer de un stream. Le llamamos lectura a transferir datos del stream 
a una estructura dentro de nuestro programa como una lista o un arreglo.

* Podemos escribir a un stream. Escribir es transferir datos de un arreglo en 
nuestro programa a un stream. 

* Algunos flujos pueden incluir una funcionalidad de posicionamiento (seek),
  con la cual podemos consultar y modificar la posición actual del flujo.
  Algunos flujos no tienen esta capacidad, por ejemplo, un flujo de red.


Para saber con qué capacidades cuenta el stream que estemos utilizando el momento
dado, podemos consular las siguientes propiedades de la clase `Stream`: `CanRead`, 
`CanWrite` y `CanSeek` respectivamente.

Para realizar las operaciones descritas arriba, utilizaremos los métodos
[`Read`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.read?view=net-7.0)
y [`Write`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.write?view=net-7.0). 
Por otro lado, para la búsqueda utilizaremos el método `Seek` para posicionarnos en otro lugar en el stream.

La clase `Stream` implementa a la interfaz `IDisposible`. Esto es necesario porque 
utilizaremos recursos que están fuera del proceso, y por lo, tanto no pueden 
destruirse automáticamente por el *recolector de basura*. Cuando terminamos de utilizar un stream
debemos desecharlo implícita o explícitamente. Para hacerlo explícitamente debemos de
llamar al método `Dispose` dentro de un bloque `try/catch`. Para disponerlo explícitamente
debemos utilizar la construcción `using`.  Al eliminar un stream, se vacían los datos
almacenados en el búfer y se liberan los recursos del sistema operativo, red u otros. 

En las versiones actuales de .NET también se cuenta con clases asíncronas,  esto se
verá en otra unidad. 

### `StreamReader`

La clase `StreamReader` nos permite leer archivos de texto. En el constructor
pasamos la ruta y nombre del archivo que vamos a leer. Podemos llamar
al método `ReadLine` para leer del archivo una línea de texto. En caso de
que lleguemos al fin del archivo, `ReadLine` nos regresará `null`.
En ejemplo siguiente, vemos cómo se utiliza la construcción `using` para 
desechar al objeto `sr` de manera implícita. 

```csharp
using System;
using System.IO;

class Test 
{
  public static void Main()
  {
    try 
    {
    // Creamos una instancia de StreamReader para leer desde un archivo.
    // using nos permite cerrar y desecharlo de manera indirecta.
    using (StreamReader sr = new StreamReader("ArchivoPrueba.txt"))
      {
      string line;
      // Leemos y mostramos las líneas mientras
      // no lleguemos al final del archivo.
      while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
      } 
    }
    catch (Exception e)
    {
    Console.WriteLine("No se pudo leer el archivo");
    Console.WriteLine(e.Message);
    }
  }
}

```

En las siguientes secciones veremos cómo leer y escribir el estado de los objetos
a archivos de texto y binarios.

#### Referencias

* Algunas partes son adaptadas del material de [dotnet/docs](https://github.com/dotnet/docs/) 
con licencia ***Attribution 4.0 International***, este material se comparte con la misma licencia. 

* Streams en [dotnet/docs](https://learn.microsoft.com/es-mx/dotnet/api/system.io.stream?view=net-7.0)


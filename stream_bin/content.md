
### Archivos de Texto 

Todos los archivos almacenan datos que consisten en una secuencia de bytes. 
Esto nos permite almacenar en archivos tipo de información digital como 
imágenes, videos, texto y hasta programas ejecutables. El detalle está en la 
manera en la que interpretamos a los bytes que almacenamos en el archivo.

En caso de 
los archivos de texto, exiten varias codificaciones que asocian a los caracteres
de un alfabeto a una representación binaria, por ejemplo, las codificaciones ASCII o 
UTF-8. Decimos que un archivo de texto (también les llamamos de texto plano) incluye solo 
texto codificado en algún estándar. No incluye bytes que representen 
directamente imágenes u otro tipo de datos. Los programadores utilizamos editores de 
texto como *vscode*, *vim*, *emacs* o *notepad++* para programar, ya que el código fuente
de nuestros programas es puro texto. Un archivo de texto también incluye caracteres que no
se muestran en el editor directamente, por ejemplo un salto de línea o una tabulación. 
La ventaja que tienen los archivos de texto al limitar el tipo de datos que contienen,
es que pueden leerse de manera universal, no importa el sistema operativo, o el tipo de 
programa con interfaz gráfica o directamente en la consola de comandos, tenemos muchas 
herramientas para leer y editar el texto. Además de la codificación, también hay 
formatos de almacenamiento que se basan en texto, por ejemplo los archivos de html, xml, json
o yaml. 

### Archivos Binarios

Por otro lado, los archivos binarios no tienen la limitación de contener solamente texto.
Algunos bytes dentro del archivo pueden codificar texto, pero otro pueden representar 
una imagen, o tipos de dato básicos definidos en un lenguaje. Por ejemplo, hablando de C#,
si queremos almacenar el valor `23.1m` de tipo decimal, vimos como al guardarlo en un archivo
de texto, debemos convertirlo a `string` (esto se hace internamente por el método `ToString()`). 
Y al leerlo debemos hacer la conversión de regreso de `string` a `decimal`. En el caso de 
un archivo binario, esto no es necesario porque el podemos grabar directamente los bytes que 
representan al decimal. De la misma manera, al leer, los bytes ya representan al valor decimal. 

Almacenar datos a un archivo binario es más fácil que a uno de texto, pues no
tenemos que hacer ninguna conversión de tipos. Todo se guarda con los mismos
bytes que el tipo dato en C#. ¿Un entero?, pues se guarda directamente como
entero, más correctamente, su representación binaria.  

Como ahora tenemos la posibilidad de almacenar bytes con distintos significados, perdemos la 
ventaja de leer todo de la misma manera. Ya no podemos tener un solo método `Read()` o `ReadLine()`,
esto era posible porque en el archivo todo es texto (`string`). Ahora debemos ajustar la lectura del 
stream al tipo de dato que esperamos. ¿Es un decimal o un entero?, ¿es entero de 16 o 32 bits?, cada 
tipo de dato básico requiere de un procesamiento algo diferente. Por esta razón, al leer archivos 
binarios, debemos utilizar métodos especializados para cada tipo básico, por ejemplo, para un
`Decimal` utilizamos `ReadDecimal()` y para un `Int16` usamos `ReadInt16`.

### BinaryWriter y BinaryReader

Al igual que en la contraparte de archivos de texto, utilizamos dos clases derivadas de `Stream`, 
las cuales se especializan en streams binarios. Utilizamos estas clases en conjunto con la 
clase `FileStream` de la misma manera que antes. Vamos el ejemplo de la documentación de C#:

```csharp
using System;
using System.IO;
using System.Text;

class ConsoleApplication
{
    const string fileName = "AppSettings.dat";

    static void Main()
    {
        WriteDefaultValues();
        DisplayValues();
    }

    public static void WriteDefaultValues()
    {
        using (var stream = File.Open(fileName, FileMode.Create))
        {
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
            {
                writer.Write(1.250F);
                writer.Write(@"c:\Temp");
                writer.Write(10);
                writer.Write(true);
            }
        }
    }

    public static void DisplayValues()
    {
        float aspectRatio;
        string tempDirectory;
        int autoSaveTime;
        bool showStatusBar;

        if (File.Exists(fileName))
        {
            using (var stream = File.Open(fileName, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                }
            }

            Console.WriteLine("Aspect ratio set to: " + aspectRatio);
            Console.WriteLine("Temp directory is: " + tempDirectory);
            Console.WriteLine("Auto save time set to: " + autoSaveTime);
            Console.WriteLine("Show status bar: " + showStatusBar);
        }
    }
}
```
El ejemplo muestra un caso práctico donde queremos almacenar la configuración de nuestro 
programa en un archivo binario. Para indicar que es un archivo binario en este caso le 
pondremos la extensión `.dat`. El nombre del archivo es:
```
const string fileName = "AppSettings.dat";
```
Empecemos por almacenar los datos, eso se hace en el método `WriteDefaultValues`. Como
vemos al igual que en el caso de los archivos de texto, creamos el `BinaryStream` tomando 
como primer parámetro una instancia del `FileStream` con el archivo dónde vamos guardar los datos.
Como vemos, no es necesario utilizar algún mecanismo para separar los datos, cómo un separador u 
algo similar.

Para la lectura ahora debemos utilizar el método de `BinaryReader` específico para el tipo de
dato que vamos a leer. Vemos que aun en el caso binario especificamos el tipo de codificación 
`Encoding.UTF8`, pues recordemos que los archivos binarios también pueden incluir texto. 
Para el caso del tipo de dato `float`, se utiliza el método `ReadSingle` el cual lee un 
flotante de 4 bytes, a esto se le conoce como `single precision`.  




#### Referencias

* Algunas partes son adaptadas del material de [dotnet/docs](https://github.com/dotnet/docs/) 
con licencia ***Attribution 4.0 International***, este material se comparte con la misma licencia. 

* Streams en [dotnet/docs](https://learn.microsoft.com/es-mx/dotnet/api/system.io.stream?view=net-7.0)


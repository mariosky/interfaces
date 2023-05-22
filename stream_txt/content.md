### Cómo almacenar objetos a un archivo de texto

Para escribir a un archivo de texto vamos a utilizar dos clases
complementarias: `FileStream` y `StreamWriter`, estas se utilizan para realizar
operaciones de escritura en archivos en C#. Aunque ambas se pueden utilizar de
manera independiente , existen algunas diferencias clave entre ellas en
términos de su funcionalidad y manera de utilizarse:

1. Funcionalidad:
* `FileStream`: es una clase que se utiliza para leer y escribir
     **bytes** en un archivo. Proporciona métodos para realizar operaciones 
     de lectura y escritura a bajo nivel manipulando los bytes. Implementa los métodos Read, Write y Seek.

* `StreamWriter`: proporciona métodos para escribir cadenas y caracteres a
     un archivo, realizando también tareas de codificación y formato.
     A `StreamWriter` se considera una clase de nivel superior, ya que no opera a nivel de bytes y 
     por lo mismo es más fácil de utilizar.

2. Uso y sintaxis:

   - `FileStream`: Primero necesitamos crear una
     instancia de la clase `FileStream` y especificando como parámetro el archivo con el que 
     vamos a trabajar. Luego, puedemos utilizar los
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
   - `FileStream`: Como `FileStream` trabaja a nivel de bytes, nos permite realizar
     operaciones más avanzadas, como leer o escribir en ubicaciones específicas
     del archivo utilizando el método `Seek`.
   - `StreamWriter`: Nos proporciona métodos 
     específicos para escribir texto, y podemos especificar el
     formato de codificación para el archivo, el uso de una memoria intermedia
     para almacenar datos antes de escribirlos en el archivo y podemos utilizar el método `WriteLine`.

 


En las siguientes secciones veremos como leer y escribir el estado de los objetos
a archivos de texto y binarios.

#### Referencias

* Algunos partes son adaptadas del material de [dotnet/docs](https://github.com/dotnet/docs/) 
con licencia ***Attribution 4.0 International***, este material se comparte con la misma licencia. 

* Streams en [dotnet/docs](https://learn.microsoft.com/es-mx/dotnet/api/system.io.stream?view=net-7.0)


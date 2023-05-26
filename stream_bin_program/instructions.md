### Guarda objetos de la clase Alumno a un archivo binario

Sigue estos pasos para completar el programa:

1. Debes completar el programa agregando el constructor 
   de la clase Alumno, incializando todos los campos.

2. Completar los parámetros del constructor de `FileStream`.

3. Itera por la lista de alumnos agregando el estado de cada 
   alumno al archivo binario. Recuerda que debas hacer en el mismo orden
   en el que se especifican en la clase. 

Observa el uso de la construcción `using` para `FileSrteam` y `BinaryWriter`.

Puedes guardar tu código temporalmente en
<a href="https://gist.github.com/" target="_blank">GitHub Gist</a>

---

#### Notas:

En la salida de **errores de compilación** ahora se incluye el número de línea
y columna dónde sucede error. Si el número de línea es mayor a las líneas de tu
programa, significa que tu código compila correctamente, pero ocasiona errores
en otras partes del programa. 

En el ejemplo utilizamos una instancia de `FileStream` para especificar el modo y tipo de acceso 
que utilizaremos al manipular el archivo. Esto lo especificamos utilizando las enumeraciones 
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


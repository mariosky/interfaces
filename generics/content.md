
¿Cuál sería la interfaz básica para una colección tipo lista?, podríamos 
definir para empezar las operaciones de agregar, leer y borrar elementos. 
Una versión reducida de la interfaz `IList` de *.NET* puede ser: 


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

Hay varias opciones para implementar en una clase concreta esta interfaz.
Por ejemplo, utilizando un arreglo de tamaño fijo o podríamos diseñar una
lista enlazada –que ya es un tema para *Estructura de Datos*. En fin, en lo que 
nos vamos a enfocar de momento, es en la decisión de utilizar a la clase `Object`,
como el tipo de dato que almacenaremos en la lista.
Esto tiene la ventaja de que podemos almacenar cualquier tipo de objeto en la lista:

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

En este caso estamos utilizando a la clase `ArrayList` la cual implementa a `IList` con 
tamaño dinámico. Vemos que podemos agregar distintos tipos de objetos, pero hay un detalle importante: 
cuando leemos los datos debemos hacer una conversión de tipos, de `Object` al tipo del objeto
que almacenamos. Esto sucede también al momento en el que guardamos los datos, aunque no lo 
hagamos explícitamente. También debemos tener cuidado de saber exactamente en que posición almacenamos 
que tipo de dato. Una solución a esto, sería tener cuidado de almacenar solo objetos de un tipo.
¿Qué opciones tenemos para aliviar este problema?. Una idea podría ser el establecer una interfaz por
cada tipo de dato, por ejemplo, para almacenar enteros tendríamos:


```csharp
interface IList
 {
  // Propiedad Count, con el número de elementos 
  // en la lista.
  int  Count { get; } 

  // Agrega un item a la lista, regresa la posición, o -1 si no 
  // fue posible agregar el elemento.
  int Add (int? value);

  // Borra un elemento  
  void Remove (int? value);

  // Regresa o modifica el elemento en el índice especificado
  int? this[int index] { get; set; }
  }
```

Y así sucesivamente para `string`, `double`, y otras clases. Si te fijas, lo único que 
cambiaría en las interfaces ¡y en las implementaciones!, sería solamente el tipo de dato. 
Prácticamente, podríamos hacer un *Find & Replace* en el código, o utilizar una plantilla 
dónde solo cambiemos el tipo de dato. Esta tarea la evitamos utilizando interfaces, clases 
y métodos genéricos.

### Genéricos en .NET 

Las clases, estructuras, interfaces y métodos genéricos utilizan unos marcadores de posición
especiales –llamados **parámetros de tipo**- los cuales después son reemplazados por los tipos 
de dato específicos que van a utilizar. Los parámetros de tipo, aparecen en aquellos lugares
doode se utilizaría el tipo de dato a emplear (como valores de retorno, argumentos, en los campos,
propiedades, etc.). Por ejemplo, nuestra interfaz IList genérica quedaría de la siguiente manera:

```csharp
interface IList<T>
 {
  // Propiedad Count, con el número de elementos 
  // en la lista.
  int  Count { get; } 

  // Agrega un item a la lista, regresa la posición, o -1 si no 
  // fue posible agregar el elemento.
  int Add (T? value);

  // Borra un elemento  
  void Remove (T? value);

  // Regresa o modifica el elemento en el índice especificado
  T? this[int index] { get; set; }
  }
```

Cómo vemos, el nombre de la interfaz cambia, pues ahora le agregamos el
parámetro de tipo `T`, los parámetros de tipo van entre los símbolos `< >` en
lugar de paréntesis. Los nombres de los parámetros genéricos tienen el prefijo
o se llaman `T` por convención.  Una vez especificado el parámetro, cambiamos
dónde correspondería el tipo `Object` por `T`. 

A continuación se muestra como podríamos utilizar la clase genérica `List<T>`
la cual implementa a `IList`. En este caso la lista solo puede almacenar un
tipo de dato específico: 


```csharp
using System.Collections.Generic; // No es necesario en versiones recientes

public class Program 
{
    public static void Main() 
    {
    List<int> enteros = new List<int>();
    enteros.Add(5);
    enteros.Add(15);
    enteros.Add(25);
    
    List<string> saludos = new List<string>();
    saludos.Add("Hola");
    saludos.Add("Hey");
    saludos.Add("What's up");

    string? saludo = saludos[2];

    int z = 10 + enteros[0];

    foreach(var saludo in saludos) // se puede utilizar var en lugar de string
      Console.WriteLine(saludos);
    }
}
```
 Al momento de crear una instancia de un objeto genérico, debemos especificar el tipo de 
 dato que queremos utilizar, según nuestras necesidades. A esta le llamamos una ***clase genérica 
 construida***, en la cual se han reemplazado los marcadores de posición, por los tipos de datos 
 especificados. 

## Métodos Genéricos

Podemos definir también, métodos genéricos los cuales tendrán dos listas de parámetros: una lista 
de parámetros de tipo genérico y otra lista de parámetros formales. Esto se muestra en el siguiente
ejemplo:

```csharp
static void Swap<T>(ref T a, ref T b)
{
    T temp = a;
      a = b;
      b = temp;
}
```

El método *Swap*, nos permite intercambiar los valores de dos variables entre sí. 
Para utilizar el método con dos enteros haríamos lo siguiente:

```csharp
    // Fragmento de código
    int x = 10;
    int y = 1;

    Swap<int>(ref x, ref y);

    // valor de x = 1
    // valor de y = 10

```

En este caso solo se utiliza un parámetro de tipo genérico. 


### Terminología

* Una *definición de tipo genérica* es una declaración de clase, estructura o interfaz, la cual 
funciona como una plantilla, con marcas de posición para los tipos de dato que contiene o utiliza.

* Los *parámetros de tipo genéricos* son los marcadores de posición empleados
  en la definición de tipos o métodos genéricos. Por ejemplo, una estructura
  [tipo diccionario](https://es.wikipedia.org/wiki/Tabla_hash) como la clase
  `Dictionary<TKey,TValue>` puede incluir dos parámetros de tipo genéricos: `TKey` y
  `TValue`, para representar a los tipos de datos de las claves y valores
  almacenados en el diccionario. 

### Vista General

* Utiliza tipos genéricos para maximizar el reuso de código, protección de
  tipos y desempeño.
* Los tipos de datos genéricos se utilizan sobre todo en colecciónes de datos.
* Se incluyen clases genéricas para la mayoría de estructuras de datos que
  utilizamos al programar.
* El mismo concepto en otros lenguajes tiene otros nombres: plantillas en C++,
  con origen en la [Standar Template Library](https://www.stroustrup.com/DnE2005.pdf) (Ver 3.1 The emergence of the STL).

### Leer 

* [Programación Genérica](https://en.wikipedia.org/wiki/Generic_programming#Stepanov%E2%80%93Musser_and_other_generic_programming_paradigms)

#### Referencias

* Algunos partes son adaptadas del material de [dotnet/docs](https://github.com/dotnet/docs/) 
con licencia ***Attribution 4.0 International***, este material se comparte con la misma licencia. 




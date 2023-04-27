
Aunque no podemos crear objetos a partir de una interfaz, si podemos asignar
objetos a referencias de tipo interfaz.  La única restricción es que el objeto
en cuestión implemente a la interfaz. Veamos un ejemplo:


```csharp
interface IFigura 
 {
  int  X { get; set; } 
  int  Y { get; set; } 
  void Dibuja();  
  }
```

En este caso, para definir una figura concreta, por ejemplo un rectángulo,
simplemente implementamos a `IFigura`, incluyendo todos sus miembros en la 
clase: 

```csharp
class Rectángulo : IFigura
{
    private double _X, _Y;

    public void Dibuja() { 
        Console.WriteLine($"Se dibuja un círculo en ({X},{Y})");
        }

    public double X{ 
        set => _X = value
        get => _X  
    }

    public double Y {
        set { _Y = value; }
        get { return _Y; }
    }

    public ImprimeCoordenadas() {
        Console.WriteLine($"Mis coordenadas son: ({X},{Y})");
    }
}
```
Ahora podríamos asignar un objeto tipo `Rectángulo` a una referencia `IFigura`: 

```csharp
class Program 
{
    static void Main()
    {
        IFigura rect = new Rectángulo();
        rect.Dibuja();
    }
}
```

Cuándo asignamos un objeto a la referencia, en este caso `rect`, mediante
ella podemos acceder a los miembros definidos en la interfaz `IFigura`. Aunque no
sería posible, por ejemplo, llamar al método `ImprimeCoordenadas()`, que 
aunque es miembro de la clase `Rectángulo`, no es miembro de la interfaz. 

En caso de ser necesario podríamos hacer una conversión de tipo:

```csharp
class Program 
{
    static void Main()
    {

        IFigura rect = new Rectángulo() {X=120, Y=100};
        rect.Dibuja();

        // Para ejecutar un método miembro de Rectángulo 
        // debemos dereferenciar a esta clase
        (rect as Rectángulo).ImprimeCoordenadas(); 

        // En versiones recientes de C#, nos marca un warning
        // porque rect podría ser nulo. En este caso podemos 
        // utilizar el operador ! para que no considere el posible error
        (rect as Rectángulo)!.ImprimeCoordenadas(); 
    }
}
```

### Polimorfismo

El polimorfismo se puede implementar igual que con una clase abstracta,
asignando a `IFigura` objetos con la capacidad de dibujarse. Esto es algo
distinto al polimorfismo que vimos antes, el cual se basaba en la herencia, en
este caso no es necesario que haya esta relación jerárquica entre las clases.
Por esta razón, incluso sería mejor que la clase se llamara `IDibujable`, ya
que no tienen que ser necesariamente figuras los objetos que deseamos dibujar.

```csharp
class Program 
{
    static void Main()
    {
        List<IDibujable> objetos = new List<IDibujable>();

        IDibujable rect = new Rectángulo() {X=120, Y=100};
        (rect as Rectángulo)!.ImprimeCoordenadas(); 
        
        objetos.Add(rect); 
        objetos.Add(new Elipse() {X=100, Y=200}); 
        objetos.Add(new Imágen() {X=300, Y=300}); 
        
        foreach(var o in objetos)
            o.Dibuja(); // Cada objeto se dibuja de acuerdo a su implementación 
    }
}
```

Puedes completar el código anteror como ejercicio personal.

### Múltiples implementaciones

El uso de las interfaces, más allá del polimorfismo, es el establecer cierta
funcionalidad, la cual puede ser implementada por distintos tipos de objetos.
Por ejemplo, la funcionalidad genérica para conectarse a un sistema de bases de
datos podría especificarse en una interfaz. Por ejemplo: 

```csharp
interface IBaseDeDatos 
 {
  IConexion CreaConexión();  
  ICursor ExecutaConsulta(IConexion c);
  int CierraConexión();
  }
```

Después otros programadores podrían implementar estas interfaces con clases para distintos servidores como 
MySQL, Oracle, SQLServer, etc. 


#### Referencias

El ejemplo utilizado es una adaptación de [Interfaces en C# de Wikibooks](https://en.wikibooks.org/wiki/C_Sharp_Programming/Interfaces)  

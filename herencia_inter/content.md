
Las interfaces son una collección de métodos y propiedades las cuales 
establecen la interfaz de un servicio. Podemos exteder 
los servicios que específica una interfaz, agregando los que se definen 
en otra en una relación parecida a la herencia. Por ejemplo, 
la interfaz `IFigura` incluye las coordenadas de su posición como propiedades 
y el método `void Dibuja ()`.  


```csharp
interface IFigura 
 {
  int  X { get; set; } 
  int  Y { get; set; } 
  void Dibuja();  
  }
```

Podemos extender esta funcionalidad 
para agregar la capacidad de rotar sobre su eje, agregando primero la funcionalidad 
en su propia interfaz:

```csharp
interface IRotable 
 {
  void Rota(double radianes);  
 }
```

Separar la funcionalidad nos va a permitir reutilizar la interfaz `IRotable` en otros 
contextos, esto no lo podríamos hacer si incluimos la funcionalidad dentro de `IFigura`. 
Para extender a la interfaz `IFigura` utilizamos la misma sintaxis que la herencia, 
en este caso vamos a extender la funcionalidad con múltiples interfaces:

```csharp
interface IFigura : IRotable, ISerializable, IImprimible
 {
  int  X { get; set; } 
  int  Y { get; set; } 
  void Dibuja();  
  }
```

Una interfaz solo puede extender a otras interfaces, no podemos incluir una clase dentro
de la lista. 

Ahora, si una clase implementa a `IFigura`, deberá implementar todos los métodos y propiedades 
que se especifiquen en `IFigura` pero también en las interfaces que la extienden 
(`IRotable`, `ISerializable`, `IImprimible`). 

Veamos un ejemplo dónde se presenta un caso particular. La clase `Rectángulo` implementa 
tanto a `IFigura` como a `IDibujable`, y ambas interfaces incluyen al método `void Dibuja()`. 

```csharp
interface IDibujable
 {
  void Dibuja();
 }

interface IRotable 
 {
  void Rota(double radianes);  
 }

interface IFigura : IRotable
 {
  int  X { get; set; } 
  int  Y { get; set; } 
  void Dibuja();  
  }

class Rectángulo: IFigura, IDibujable
{

    public double X { get; set;}
    public double Y { get; set;}

    void IFigura.Dibuja() { 
        Console.WriteLine($"Se dibuja un rectángulo en ({X},{Y})");
        }
    public void Rota(double r) { 
        Console.WriteLine($"Se rota el rectángulo {r} radianes");
        }

    void IDibujable.Dibuja() { 
        Console.WriteLine($"Se dibuja un rectángulo");
        }

}
``` 

La ambigüedad se resuelve añadiendo como prefijo el nombre de la interfaz correspondiente 
al momento de implementar el método y eliminando el modificador de acceso `public`. En
este caso implementamos distinta funcionalidad según el caso. Otra opción sería implementar 
un solo `void Dibuja()` el cual se utilice en ambos casos.

#### Notas

* En ocasiones se le conoce como ***herencia de interfaces*** al extender una interfaz.


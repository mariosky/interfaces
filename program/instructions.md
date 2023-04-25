
### Implementa la interface IFoo 

Nuestra clase `Producto` debe implementar la interface `IFoo`.

#### Si tienes dudas 

Aquí tienes este ejemplo:

```csharp
interface IAmigable
 {
  string? Nombre { get; set; } 
  bool EsAmigo(string nombre); 
  int GetNumAmigos();
 }

public class Alumno : IAmigable
  {
  // En implementaciones debemos indicar 
  // el modificador de accreso.
  private string? _nombre; // Campo para implementar la propiedad
  // Propiedad 
  public string? Nombre  
     {
      get => _nombre;
      set{ 
        _nombre = value;
        }
     }
   // También se podría: 
   // public string? Nombre { get; set;}
  public int GetNumAmigos()
     {
      return 100000; // Para el ejemplo es suficiente con regresar 
                     // un valor del tipo correcto.
     }
  public bool EsAmigo(string n) => true;
  }
```

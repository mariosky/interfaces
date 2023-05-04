
interface Dibujable 
 {
  double  X { get; set; }
  double  Y { get; set; } 
 }

class Rectángulo : IDibujable
{
    private double _X, _Y;

    public void Dibuja() { 
        Console.WriteLine($"Se dibuja un círculo en ({X},{Y})");
        }

    public double X{ 
        set => _X = value;
        get => _X; 
    }

    public double Y {
        set { _Y = value; }
        get { return _Y; }
    }

    public void ImprimeCoordenadas() {
        Console.WriteLine($"Mis coordenadas son: ({X},{Y})");
    }
}

class Alumno  
{
    public string? Nombre;
    public double X {get; set;} 
    public double Y {get; set;} 

    public void Dibuja() { 
        Console.WriteLine($"Se dibuja un círculo en ({X},{Y})");
        }


    public void ImprimeNombre() {
        Console.WriteLine($"Mis coordenadas son: ({X},{Y})");
    }
}
class Program 
{
    static void MainEjemplo()
    {
        List<IDibujable> objetos = new List<IDibujable>();

        IDibujable rect = new Rectángulo() {X=120, Y=100};
        rect.ImprimeCoordenadas(); 

        objetos.Add(rect); 
        objetos.Add(new Rectángulo() {X=100, Y=200}); 
        objetos.Add(new Alumno() {X=300, Y=300}); 

        foreach(var o in objetos)
            o.Dibuja(); // Cada objeto se dibuja de acuerdo a su implementación 
    }
}


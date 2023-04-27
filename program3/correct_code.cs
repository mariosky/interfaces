
interface ISaludador
 {
     void Saluda();
 }

interface IEstudioso
 {

  void Estudia();

 }

interface IAmigable
 {
   string? Nombre { get; set; } 
   bool EsAmigo(string nombre); 
   void Saluda();
 }

class Alumno : IAmigable, ISaludador,  IEstudioso 
  { 
  public string?  Nombre {get; set;}
  public bool EsAmigo(string n)
  {
      return true;
  }
  void ISaludador.Saluda()
  { Console.WriteLine("Hola");
  }
  void IAmigable.Saluda()
  { Console.WriteLine("Hola");
  }
  public void Estudia()
  {}
  

  }

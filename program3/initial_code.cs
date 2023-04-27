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




  }


public class InterfaceTest
{
    [Fact]
    public void Interface()
    {
      List<IDibujable> objetos = new List<IDibujable>();

        IDibujable rect = new Rectángulo() {X=120, Y=100};
        (rect as Rectángulo)!.ImprimeCoordenadas(); 

        objetos.Add(rect); 
        objetos.Add(new Rectángulo() {X=100, Y=200}); 

        foreach(var o in objetos)
            o.Dibuja(); // Cada objeto  
    }
}




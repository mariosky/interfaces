
public class UnitTest1
{
    [Fact]
    public void ConstructorClass()
    {
      Alumno p = new Alumno(1, "NombreA", 90.22m);
      Assert.Equal("NombreA",p.nombre);
      Assert.Equal(1, p.id);
      Assert.Equal(90.22m,p.calificación);
    }

    [Fact]
    public void SaveAlumnosTxt()
    {
      List<Alumno> alumnos = new();
      alumnos.Add(new Alumno(1, "NombreA", 82.22m));
      alumnos.Add(new Alumno(2, "NombreB", 92.22m));
      alumnos.Add(new Alumno(3, "NombreC", 32.22m));
    
      AlumnoDB.SaveAlumnosBin(alumnos, "alumnos.dat");

      List<Alumno> alumnosFF = new();
      alumnosFF = ReadAlumnosBin();
      Assert.Equal(1, alumnosFF[0].id);
      Assert.Equal(2, alumnosFF[1].id);
      Assert.Equal(3, alumnosFF[2].id);
      
    }

    private static List<Alumno> ReadAlumnosBin()
    {
        List<Alumno> alumnos = new();
        FileStream? fs = null;
        try {
            fs = new FileStream("alumnos.dat", FileMode.Open, FileAccess.Read);
            using(BinaryReader binIn = new BinaryReader(fs, Encoding.UTF8))
            {
                while (binIn.PeekChar() != -1)
                {
                    int id = binIn.ReadInt32(); 
                    string name = binIn.ReadString();
                    decimal cali= binIn.ReadDecimal();
                    Console.Write($"{id}{name}{cali}");
                    alumnos.Add(new Alumno(id, name, cali));
                }
            }
        }
        finally {
            if (fs != null)
                fs.Dispose();
        }
        return alumnos;
    }

}

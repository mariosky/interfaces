
public class UnitTest1
{
    [Fact]
    public void ConstructorClass()
    {
      Alumno p = new Alumno(1, "ana@gmail.com", 90.22m);
      Assert.Equal("ana@gmail.com",p.correo);
      Assert.Equal(1, p.id);
      Assert.Equal("ana@gmail.com",p.correo);
    }

    [Fact]
    public void SaveAlumnosTxt()
    {
      List<Alumno> alumnos = new();
      alumnos.Add(new Alumno(1, "NombreA", 82.22m));
      alumnos.Add(new Alumno(2, "NombreB", 92.22m));
      alumnos.Add(new Alumno(3, "NombreC", 32.22m));
    
      ProductDB.SavealumnosBin(alumnos);

      List<Product> alumnosFF = new();
      alumnosFF = ReadAlumnosBin();
      Assert.Equal("AAA", alumnosFF[0].code);
      Assert.Equal("BAA", alumnosFF[1].code);
      Assert.Equal("CAA", alumnosFF[2].code);
      
    }

    private static List<Product> ReadAlumnosBin()
    {
        List<Alumno> alumnos = new();
        FileStream? fs = null;
        try {
            fs = new FileStream("alumnos.dat", FileMode.Open, FileAccess.Read);
            using(BinaryStream txtIn = new BinaryStream(fs, Encoding.UTF8))
            {
                while (txtIn.PeekChar() != -1)
                {
                    int id = binIn.ReadInt(); 
                    string name = binIn.ReadString();
                    decimal? cali= binIn.ReadDecimal(); 
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

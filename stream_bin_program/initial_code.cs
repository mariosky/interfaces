using System.Text;

public class Alumno
{
    public int id;
    public string nombre;
    public decimal? calificación;

    // Agrega el constructor

    public Alumno(int id, string n, decimal? c)
    {
        this.id = id; this.nombre = nombre; this.calificación=c;
    }
}

public class AlumnoDB
{
    public static void SaveAlumnosBin(List<Alumno> alumnos, string path)
    {
            // El nombre del archivo nos lo envían en el parámetro path
            // El archivo puede ser que exista previamente
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate, 
                        FileAccess.Write))
            using(BinartWriter binOut = new Writer(fs, Encoding.UTF8, 512))
            {
                foreach (var p in alumnos)
                {
                    // Utiliza los métodos Write y WriteLine para 
                    // Agregar los productos al archivo
                    binOut.Write(nombre);
                    binOut.Write(correo);
                    binOut.Write(calificación);
                }
            }
    }
}

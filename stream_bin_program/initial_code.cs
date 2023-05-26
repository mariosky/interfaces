using System.Text;

public class Alumno
{
    public int id;
    public string nombre;
    public decimal calificación;

    // Agrega el constructor
}

public class AlumnoDB
{
    public static void SaveAlumnosBin(List<Alumno> alumnos, string path)
    {
            // El nombre del archivo nos lo envían en el parámetro path
            // El archivo puede ser que exista previamente
            using(FileStream fs = new FileStream( ,  , 
                        FileAccess.Write))
            using(BinaryWriter binOut = new BinaryWriter(fs, Encoding.UTF8))
            {
                //Debes iterar por la lista que nos han enviado como parámetro
                //Escribe al stream en binario los campos de cada alumno
                //En el mismo orden que en la clase

            }
    }
}

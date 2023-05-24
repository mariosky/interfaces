using System.Text;

public class FileSaver
{
    public static void SaveToText(string data, string file)
    {
        FileStream fs = null;
        try {
            fs =  new FileStream(file, FileMode.Open, FileAccess.Write);
            using(StreamWriter txtOut = new StreamWriter(fs, Encoding.UTF8, 512))
            {
               txtOut.Write(data); 
            }
        }
        
        finally {
            if (fs != null)
                fs.Dispose();
        }
    }
}

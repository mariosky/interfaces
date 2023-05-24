public class UnitTest1
{
    [Fact]
    public void SaveProductsTxt()
    {
      string data = "data";
      string file = "data.txt";

      using (StringWriter s = new StringWriter())
            {
                Console.SetOut(s);
                
                FileSaver.SaveToText(data, file);

                var result = s.ToString().Trim().Replace("\r","");
                Assert.Equal("El archivo no existe", result );
            }
    }

}

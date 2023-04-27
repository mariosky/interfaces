public class InterfaceTest
{
    [Fact]
    public void Interface()
    {
        
        Alumno a = new Alumno() {Nombre="Juan"};

        ISaludador sa  = a as ISaludador; 
        Assert.NotNull(sa);
        IEstudioso est =  a as IEstudioso; 
        Assert.NotNull(est);
        IAmigable ami  = a as IAmigable;
        Assert.NotNull(ami);
    }

    [Fact]
    public void ISaludador()
    {
        
        Alumno a = new Alumno() {Nombre="Juan"};
        ISaludador sa  = a as ISaludador; 
        using (StringWriter s = new StringWriter())
            {
                Console.SetOut(s);
                
                sa.Saluda();

                var result = s.ToString().Trim().Replace("\r","");
                Assert.Equal("Hola", result );
            }

    }

    [Fact]
    public void IAmigable()
    {
        
        Alumno a = new Alumno() {Nombre="Juan"};

        IAmigable ami  = a as IAmigable; 
        using (StringWriter s = new StringWriter())
            {
                Console.SetOut(s);
                
                ami.Saluda();

                var result = s.ToString().Trim().Replace("\r","");
                Assert.Equal($"{ami.Nombre} dice Hola", result );
            }

    }

}




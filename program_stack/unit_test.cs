public class UnitTest1
{
    [Fact]
    public void PushPopStack()
    {
       Stack<int> pila = new Stack<int>(5);
       pila.Push(5);
       Assert.Equal(5, pila.Pop()); 
    }

    [Fact]
    public void PopStack()
    {
       Stack<int> pila = new Stack<int>(5);
       pila.Push(5);
       pila.Pop();

       Assert.Throws<InvalidOperationException>(()=>pila.Pop()); 
    }

    [Fact]
    public void PushStack()
    {
       Stack<int> pila = new Stack<int>(2);
       pila.Push(5);
       pila.Push(5);
       Action testCode = () => pila.Push(0);
       StackOverflowException exception = Assert.Throws<StackOverflowException>(testCode); 
       Assert.Equal("La pila está llena",exception.Message);
    }
}

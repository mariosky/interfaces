
class Stack<T>
{
 private readonly int Size;
 private int StackPointer = 0;

 private T[] Items;

 public Stack():this(5){}
 public Stack(int size){
        this.Size = size;
        Items = new T[size];
 }
 
 public void Push(T item){
     if (StackPointer >= Size)
        throw new StackOverflowException("La pila está llena");
    
     Items[StackPointer] = item;
     StackPointer++;
 }
 public T Pop()
 {
    StackPointer--;
    if (StackPointer >= 0)
        return Items[StackPointer];
    else
    {
    StackPointer = 0;
    throw new InvalidOperationException("La pila está vacía");
    }
 }
}

class Program{
    static void Main(){
        Console.WriteLine("Pila de tamaño 5");

        Stack<int> pila = new Stack<int>();
        pila.Push(3);
        pila.Push(4);
        pila.Push(5);

        Console.WriteLine(pila.Pop());
        Console.WriteLine(pila.Pop());
        Console.WriteLine(pila.Pop());
        Console.WriteLine(pila.Pop());
    }
}

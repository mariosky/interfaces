
class Stack<T>
{
 private readonly int ;
 private int StackPointer = 0;

 private [] Items;

 public Stack():this(5){}
 public Stack(int size){
        this.Size = size;
        Items = new int[size];
 }
 
 public void Push(T item){
     if (StackPointer >= Size)
        throw new StackOverflowException("La pila está llena");
     // Completar 
     // Agregar elementos al arrglo en la posición del StackPointer
     // Incrementar el StackPoiner en uno
 }
 public T Pop()
 {
     // Completar
     // Primero debemos decrementar el StackPointer

    if (StackPointer >= 0)
     // Completar
     // Si estamos en una posición válida regresamos el Item en esa posición 
    else
    {
    StackPointer = 0;
    throw new InvalidOperationException("La pila está vacía");
    }
 }
}



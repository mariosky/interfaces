
### Implementa la estructura Stack Genérica

Completa y cambia el tipo de dato de algún elemento
de la clase Stack, para que funcione como eso, una pila.

Si te fijas, la clase es Genérica y utilizamos el parámetro de 
tipo `T`. El funcionamiento de la pila para utilizar enteros
se muestra a continuación:

```csharp
class Program{
    static void Main(){
        Console.WriteLine("Pila de tamaño 5");
	// Una pila para utilizar objetos tipo entero
        Stack<int> pila = new Stack<int>();
        pila.Push(3);
        pila.Push(4);
        pila.Push(5);

        Console.WriteLine(pila.Pop());
        Console.WriteLine(pila.Pop());
        Console.WriteLine(pila.Pop());
        // Hay una excepción si queremos extrer otro elemento 
        // de la pila
        Console.WriteLine(pila.Pop());
    }
}
```



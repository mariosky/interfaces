using System;
using System.IO;

interface IFoo
{
   int ID { set; } 
   string Nombre { get; set; } 
   bool HazAlgo(string g); 
   int GetID();
}

public class Producto : IFoo
  {
  // Agrega los miembros necesarios para implementar IFoo.
  }


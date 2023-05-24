### Atrapa la excepción

El código inicial tiene un error, el programador quiere
abrir el archivo que llega como parámetro, pero el 
archivo no existe. Cuando sucede esto se dispara 
la excepción `System.IO.FileNotFoundException`. 

Agrega el bloque necesario para atrapar esta 
excepción, dentro de ella simplemente imprime a la 
consola el mensaje: `"El archivo no existe"`.

No es necesario modificar otra parte del programa.


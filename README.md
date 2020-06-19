#Sustentación Examen 3, GNU Web-Services


__En este apartado, vamos a analizar el CRUD de la API__

Como prueba, utilizamos la aplicación, [postman].

* __Ver__
 
![Función Ver](/Ver.PNG)
Probamos en Postman:
![Postman Ver](/VerPostman.PNG)
~~~
Se hace una peticion GET para hacer una consulta a la base de datos.
Tambien de puede agregar al final de la URL el ID.
~~~
Por ejemplo: https://localhost:5001/api/Blogs/1
-----------
* __Crear__

![Función Crear](/Crear.PNG)
~~~
El agregar utiliza la petición POST.
Probamos en Postman:
~~~
![Postman Crear](/CrearPostman.PNG)
~~~
Para hacer el guardado en postman, se usa el formato JSON con la misma estructura que se está utilizando
~~~
`{"id": 3,"nombre": "Blog del profesor","autor": "William"}`

------
* __Eliminar__

![Función Eliminar](/Eliminar.PNG)
~~~
El agregar utiliza la petición DELETE.
Probamos en Postman:
~~~
![Postman Eliminar](/EliminarPostman.PNG)
~~~
Definimos al final de la URL el ID que se desea eliminar de la base de datos.
Por ejemplo: https://localhost:5001/api/Blogs/1
Para verificar, solo es ir a la funcion ver que tiene como petición GET.
~~~
![Postman Eliminar](/EliminarPostmanGet.PNG)
~~~
Podemos ver que ya no está en la base de datos, las tablas relacionadas con el ID __"1"__
~~~
------
* __Editar__
  
![Función Editar](/Editar.PNG)
~~~
El eliminar se usa con la petición PUT.
Probamos en Postman:
~~~
![Postman Editar](/EditarPostman.PNG)
~~~
Aún se sigue trabajando en el editar
~~~



--------
* __Apartado de configuraciones__

dotnet new global.json
> dotnet new global.json --sdk-version 2.2.207

dotnet new webapi -n api

dotnet restore

dotnet build 

dotnet run 

1. https://code.visualstudio.com/#alt-downloads
2. https://download.visualstudio.microsoft.com/download/pr/279de74e-f7e3-426b-94d8-7f31d32a129c/e83e8c4c49bcb720def67a5c8fe0d8df/dotnet-sdk-2.2.207-win-x64.exe
3. https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp
4. https://www.postman.com/


[postman]: https://www.postman.com/
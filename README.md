## OnlineClothingStore - Proyecto de API para una Tienda de Ropa Online

`Este proyecto es una API REST para una tienda de ropa online que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre productos. Incluye pruebas unitarias para validar las operaciones y utiliza Swagger para probar las endpoints directamente desde el navegador.`

# Tecnologías Utilizadas

`A lo largo del desarrollo del proyecto, utilizamos las siguientes tecnologías y herramientas:`

.NET 8.0: `Framework principal para construir la API y las pruebas.`
C#: `Lenguaje de programación utilizado para escribir el código.`
ASP.NET Core: `Framework para crear la API REST.`
Entity Framework Core: `ORM para manejar la persistencia de datos (usamos Microsoft.EntityFrameworkCore.InMemory para pruebas).`
xUnit: `Framework de pruebas unitarias para validar las operaciones CRUD.`
Moq: `Biblioteca para crear mocks (aunque no la usamos directamente en las pruebas finales, es común en proyectos con xUnit).`
Swagger (Swashbuckle.AspNetCore): `Herramienta para documentar y probar las endpoints de la API.`
Microsoft.EntityFrameworkCore.InMemory: `Proveedor de base de datos en memoria para pruebas unitarias.`
PowerShell: `Terminal utilizada para ejecutar comandos dotnet y gestionar archivos.`
dotnet CLI: `Interfaz de línea de comandos para compilar, restaurar dependencias, ejecutar pruebas y lanzar la API.`


## Estructura del Proyecto

`El proyecto está dividido en varias partes:`

OnlineClothingStore.Core: `Contiene las entidades (Product) y DTOs (ProductDto).`
OnlineClothingStore.Data: `Contiene el contexto de datos (StoreDbContext) y el repositorio (ProductRepository) para la persistencia.`
OnlineClothingStore.Api: `Contiene la API REST con el controlador ProductsController.`
OnlineClothingStore.Tests: `Contiene las pruebas unitarias para el controlador.`
OnlineClothingStore.sln: `Archivo de solución que agrupa todos los proyectos.`

## Cómo Ejecutar el Proyecto: `Utiliza los siguientes comandos en la terminal`

Navega al Directorio del Proyecto:

`cd OnlineClothingStore`

Restaura las Dependencias:

`dotnet restore OnlineClothingStore.sln`

Compila el Proyecto:

`dotnet build OnlineClothingStore.sln`

Ejecuta las Pruebas:

`dotnet test OnlineClothingStore.sln`

Ejecuta la API:

`cd OnlineClothingStore.Api`
`dotnet run`

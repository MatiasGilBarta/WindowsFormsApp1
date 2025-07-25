Sistema de Gestión – Windows Forms en C#

Descripción
Este proyecto es un **sistema CRUD por capas** desarrollado con **Windows Forms en C#**, que forma parte de un prototipo funcional derivado de una tesis académica en curso.

La aplicación implementa una arquitectura por capas, conexión a base de datos **SQL Server**, y aplica patrones de diseño como **Repository**, **Singleton**, **Factory** y **Adapter** lo que lo convierte en un ejemplo realista y escalable de sistema de gestión.

Actualmente permite gestionar entidades como **Stock** (con propiedades como estado, nombre, ID, etc.) mediante una interfaz de escritorio simple.

Características principales
- Arquitectura por capas:
  - `UI` (interfaz de usuario)
  - `BLL` (lógica de negocio)
  - `DAL` (acceso a datos)
  - `Domain` (modelo de datos)
- Conexión a base de datos **SQL Server**
- Patrones de diseño aplicados:
  - **Repository**: para abstraer el acceso a datos.
  - **Singleton**: para control de instancias.
  - **Adapter**: traduce entre clases incompatibles (por ejemplo, para registrar cambios o actualizar visualmente).
  - **Static Factory**: **Static Factory**: para elegir dinámicamente el tipo de persistencia (`DAL_SQL` o `DAL_Memoria`).
- Interfaz gráfica con **Windows Forms**
- CRUD completo de entidades: alta, baja, modificación y consulta.

Tecnologías utilizadas
- Lenguaje: **C#**
- Plataforma: **.NET Framework**
- UI: **Windows Forms**
- Base de datos: **SQL Server**
- Librerías usadas: `System.Data.SqlClient`, componentes visuales estándar.

Cómo ejecutar el proyecto
1. Cloná este repositorio o descargalo como ZIP.
2. Abrí el proyecto en **Visual Studio**.
3. Verificá que la cadena de conexión (`Conexion.cs`) esté apuntando a tu instancia de SQL Server.
4. Restaurá o creá la base de datos correspondiente si no existe y cambiar la connectionString a la correspondiente (ya que en esta version no esta realizada para correr en memoria por ahora).
5. Ejecutá el proyecto (`WindowsFormsApp1` como startup project).
6. (para la proxima actualización) Para cambiar el tipo de persistencia de SQL a memoria, modificá el value "sqlserver" a "memory" de la key dentro `App.config`.

Capturas de pantalla 
<img width="751" height="496" alt="image" src="https://github.com/user-attachments/assets/0d442638-7c86-46b7-b1aa-91fd8e8c0867" />
(imagen ilustrativa de la salida en pantalla)
PD: al ser un prototipo el boton 3 no está implementado

Estado del proyecto
Este repositorio representa una **fase inicial de prototipo y funcional** del sistema real que será parte de una tesis universitaria.  
La versión completa se mantiene privada por motivos académicos y de confidencialidad.

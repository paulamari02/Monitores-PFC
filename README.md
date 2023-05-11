## Índice
- [1. Introducción](#introduccion) 						 
- [2. Objetivos](#objetivos)  
  - [Objetivos especifícos](#objetivosEspecificos)  
- [3. Tecnologías escogidas y justificación](#tecnologiasEscogidas)  				
  - [Frameworks seleccionados](#frameworks)  
  - [Motor de bases de datos](#baseDeDatos)  
- [4. Diseño de la aplicación](#diseño)  				
  - [Tablas de la bases de datos](#tablas)  
  - [Mockup](#mockup)  
  - [Arquitectura web](#arquitectura)  
- [5. Estructura de la aplicación](#estructura)  				
  - [Recursos externos](#recursos)  
- [6. Manual de despliegue](#despliegue)  				
 
<a name="introduccion"></a>	
## 1. Introducción
Este proyecto consiste en una aplicación web para facilitar el acceso a los datos almacenados en una base de datos para los empleados de la empresa. La aplicación incluye herramientas, como gráficos y tablas, para ayudar a los usuarios a encontrar la información que necesitan de una manera mas visual y les permitirá agregar y eliminar datos de la base de datos. El objetivo principal es mejorar la eficiencia de los empleados al proporcionarles una herramienta que facilite el acceso a la información almacenada, lo que les permitirá realizar su trabajo de manera más efectiva y eficiente.

<a name="objetivos"></a>	
## 2. Objetivos
La idea de este proyecto surge de la necesidad de una nueva forma de organizar y visualizar los datos en tiempo real para los trabajadores de la empresa. La introducción de esta aplicación tiene como objetivo mejorar la eficiencia y productividad de la empresa, al mismo tiempo que facilita el trabajo diario de los empleados.
<a name="objetivosEspecificos"></a>	
### Algunos de los objetivos más especifícos serían:
- Proporcionar una interfaz amigable para facilitar el acceso eficiente a la información almacenada en la base de datos.
- Permitir a los usuarios agregar y eliminar datos de manera segura y fácil, garantizando la precisión y actualización de la información.
- Mejorar la eficiencia del proceso de búsqueda de datos mediante herramientas de búsqueda y filtrado.
- Aumentar la eficiencia y productividad de los empleados al brindarles una herramienta fácil para acceder a la información necesaria en su trabajo.
- Utilizar tecnologías avanzadas como `C# y .NET`, y librerías como `Chart.JS`, para mejorar la visualización de datos y la experiencia del usuario en la aplicación.

<a name="tecnologiasEscogidas"></a>	
## 3. Tecnologías escogidas y justificación
<a name="frameworks"></a>	
### Frameworks seleccionados
El framework usado es `Blazor de ASP.NET Core`. Esta plataforma de trabajo nos ha permitido:
- Crear interfaces de usuario completamente interactivas con C#.
- Compartir la lógica de aplicación del lado cliente y servidor escrita con .NET.
- Obtener beneficios de rendimiento, confiabilidad y seguridad de .NET.
<a name="baseDeDatos"></a>	
### Motor de bases de datos 
El motor de bases de datos usado es `MySql`. Las razones de su elección son las siguientes:
- **Costo:** MySQL se adquiere de forma gratuita, lo que permite reducir los gastos para el cliente en comparación con otros sistemas de bases de datos que pueden tener licencias costosas.
- **Multiplataforma:** MySQL es compatible con Windows, Linux y Mac, que son los sistemas operativos más ampliamente utilizados. Esto significa que se puede utilizar en cualquier plataforma que el cliente prefiera.
- **Comunidad de desarrolladores:** MySQL es ampliamente utilizado y cuenta con una gran comunidad de desarrolladores. Es decir puedes encontrar ayuda, recursos y soluciones a problemas comunes, lo que agiliza el proceso de desarrollo y mantenimiento.
- **Mantenimiento sencillo:** MySQL tiene una estructura más simple en comparación con otros sistemas de gestión de bases de datos, lo que facilita su mantenimiento. Esto implica que el propio desarrollador puede encargarse del mantenimiento de la base de datos sin necesidad de un administrador de bases de datos dedicado.
- **Escalabilidad:** MySQL es escalable, lo que significa que puede adaptarse y crecer según las necesidades futuras del proyecto. Esto proporciona una ventaja a largo plazo, ya que la base de datos puede manejar un mayor volumen de datos y usuarios a medida que la aplicación se expande.

<a name="diseño"></a>	
## 4. Diseño de la aplicación
<a name="tablas"></a>	
### Tablas de la bases de datos 
<a name="mockup"></a>	
### Mockup
Se realizó una representación en forma de dibujo, es decir prototipo visual estático, de cómo será el diseño final del producto. De esta manera conseguimos una idea clara de cómo se verá y se comportará la interfaz de usuario final, lo que nos permite hacer cambios y mejoras antes de comenzar el proceso de desarrollo. 
Como en nuestra web se van a repetir muchas de las pantallas con el mismo diseño pero con diferentes datos solo se ha realizado las páginas principales de una manera generalizada.
<a name="arquitectura"></a>	
### Arquitectura web
Hemos utilizado un modelo de navegación radial como eje central la home page que constará de un menú con todos los monitores disponibles. Todo gira en torno a ella. El usuario aterriza en la home y, desde ella, puede visitar un monitor o otro. Pero si quiere moverse de un monitor a otro debe volver a la home y seleccionarlo desde ahí.
Se pretende realizar en un futuro un inicio de sesión para los usuarios que se enlazará a este modelo de una manera lineal con el menú.

<a name="estructura"></a>	
## 5. Estructura de la aplicación
La estructura típica de un proyecto .NET Core:
- `wwwroot`: Almacena los archivos estáticos que se servirán directamente al cliente, como archivos CSS, JavaScript, imágenes, etc.
- `Components`: Contiene componentes compartidos que se utilizan en múltiples páginas de la aplicación. Estos componentes pueden ser barras de navegación, encabezados, pies de página, etc.
- `Contexts`: Contiene las clases de contexto de base de datos.
- `Data`: Contiene los archivos y las clases relacionadas con el acceso a datos, como los repositorios
- `Models`: Se encuentran las clases de modelos que representan las entidades y objetos utilizados en la aplicación.
- `Pages`: Se encuentran las páginas de Blazor, que representan las diferentes vistas y componentes de la aplicación. Cada página generalmente tiene su propio archivo .razor, que define su estructura y comportamiento.
- `Shared`: Contiene servicios adicionales utilizados por la aplicación, como servicios de autenticación, servicios de notificación, servicios de almacenamiento, etc.
<a name="recursos"></a>	
### Recursos externos
- `Bootstrap`: para el aspecto visual de la aplicación.
- `Font Awesome`: iconos para los distintos elementos html.
- `Chart.js`: libreria para los gráficos.
- `LINQ` o Language Integrated Query: conjunto de herramientas de Microsoft para realizar todo tipo de consultas sobre distintas fuentes de datos. (NuGet)
- `Entity Framework Core`: permite a los desarrolladores convertir sus estructuras de datos en clases para poder trabajar con esa información usando objetos de .NET. (NuGet)

<a name="despliegue"></a>	
## 6. Manual de despliegue

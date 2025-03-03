## Generar Contraseña en C#

Este proyecto en C# permite generar una contraseña segura de manera automática o solicitar al usuario que ingrese una contraseña bajo ciertas condiciones de seguridad. A continuación, se describe el funcionamiento y las principales características de la aplicación.

### Funcionalidad

1. **Interfaz de Usuario (Main):**
   - Solicita el nombre de usuario.
   - Pregunta si el usuario desea que se genere una contraseña segura automáticamente.
     - Si la respuesta es "Sí", se utiliza el método `GenerarContraseña` para generar una contraseña segura.
     - Si la respuesta es "No", el usuario debe ingresar una contraseña que cumpla con ciertas reglas de seguridad.
   - La contraseña debe tener entre 8 y 20 caracteres, contener al menos un número, una letra mayúscula, una minúscula y un carácter especial.
   - La validez de la contraseña ingresada es comprobada mediante el método `VerificarContraseña`.

2. **Generación de Contraseña (Clase `Contraseña`):**
   - La contraseña generada aleatoriamente tiene una longitud entre 8 y 20 caracteres.
   - La contraseña contiene:
     - Un 15% de números.
     - Un 35% de letras minúsculas.
     - Un 35% de letras mayúsculas.
     - Un 15% de caracteres especiales.
   - Se utiliza `StringBuilder` para construir la contraseña de manera eficiente.

3. **Verificación de Contraseña:**
   - Se verifica que la contraseña ingresada cumpla con las condiciones:
     - Longitud entre 8 y 20 caracteres.
     - Al menos un número, una letra mayúscula, una letra minúscula y un carácter especial.
   - Si la contraseña es válida, se devuelve un mensaje confirmando su validez.
   - Si la contraseña no es válida, se devuelve un mensaje de error con la razón.

### Requisitos

Este proyecto utiliza las bibliotecas estándar de C#, por lo que no se requieren dependencias adicionales para ejecutar el código.

### Mejoras Posibles

- **Uso de Expresiones Regulares:** En lugar de iterar manualmente sobre los caracteres de la contraseña, se podría utilizar expresiones regulares para verificar las condiciones de manera más eficiente.
  
- **Seguridad Adicional:** Si esta aplicación estuviera en producción, sería importante considerar métodos de almacenamiento seguro de contraseñas, como hash y salting, para proteger las contraseñas almacenadas.

- **Pruebas Adicionales:** Se podrían agregar pruebas para garantizar que la generación y verificación de contraseñas funcionen correctamente en diferentes casos.

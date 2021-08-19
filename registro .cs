using System;
using Microsoft.Win32;
namespace registro
{
    class Program
    {
        //NOTA: hay claves que no se pueden modificar, unicamente ejecutando el porgrama como administrador se podra 
        static void Main(string[] args)
        {
             // Abrimos la clave del registro con la que queremos trabajar
            RegistryKey rk1 = Registry.LocalMachine;

            // Nos movemos hasta la subclave donde queremos trabajar.
            // El parámetro boleano indica si la abrimos en solo lectura (false)
            // ó en lectura/escritura (true).
            rk1 = rk1.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", true);
         // Si devuelve null es que la clave no existe
            if (rk1 == null)  Console.WriteLine("No existe esa clave");
            else   Console.WriteLine("si exxiste");

            // Crear una nueva clave
            // El método devuelve un RegistryKey apuntando
            // a la nueva entrada.
            RegistryKey rk2 = rk1.CreateSubKey("Run");

            // Obtener todas las subclaves contenidas en esta:
            //String[] subKeys = rk1.GetSubKeyNames();

            // Borrar una clave vacia:
            //rk1.DeleteSubKey("Prueba");

            // Borrar una clave recursivamente:
            //rk1.DeleteSubKeyTree("Prueba");

            // Crea un key-value indicando su nombre, valor y tipo:
            rk2.SetValue("3", "C:\\Users\\chaca\\OneDrive\\Escritorio\\ratonloco.exe", RegistryValueKind.String); // en este caso creamos un valor en cadena 

            // Obtener todos los nombres de key-values que hay en una clave:
            //String[] values = rk1.GetValueNames();

            // Obtener el valor de un key-value:
            //Console.WriteLine(rk2.GetValueKind("ValorPrueba").ToString());
            

            // esto es por si queremos crear una valor en clave ya creado  
             RegistryKey hola = Registry.CurrentUser;
            hola = hola.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            hola.SetValue("504", "C:\\Users\\chaca\\OneDrive\\Escritorio\\ratonloco.exe", RegistryValueKind.String);

            Console.ReadLine();
        }
    }
}

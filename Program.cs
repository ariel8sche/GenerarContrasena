using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGenerarContraseña
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usuario, opcion, contraseña = "";

            Console.WriteLine("\t\tRegistro\n\n");
            Console.Write("Ingrese su nombre de usuario: ");
            usuario = Console.ReadLine();

            Console.Write("Desea que le generemos una contraseña segura (Si/No): ");
            opcion = Console.ReadLine();
            opcion = opcion.ToLower();

            switch (opcion)
            {
                case "si":
                    Contraseña nuevaContraseña = new Contraseña();
                    contraseña = nuevaContraseña.GenerarContraseña();
                    Console.WriteLine($"Esta es la contraseña segura que generamos para usted, guardela en un lugar seguro: {contraseña}");
                    Console.WriteLine("\nPresione una tecla para terminar su registro");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine($"\nTus datos de acceso son los siguientes \n\tUsuario: {usuario} \n\tContraseña: {contraseña} ");
                    break;
                case "no":
                    Console.Write("Ingrese una contraseña segura (La contraseña debe contener entre 8 y 20 caracteres, incluido un numero, una mayuscula, una minuscula y un caracter especial (#$%&!?)): ");
                    contraseña = Console.ReadLine();
                    Contraseña verificarContraseña = new Contraseña();
                    var resultado = verificarContraseña.VerificarContraseña(contraseña);
                    if (resultado.Item1)
                    {
                        Console.WriteLine("Presione una tecla para terminar su registro");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine($"\nTus datos de acceso son los siguientes \n\tUsuario: {usuario} \n\tContraseña: {contraseña} ");
                    }
                    else
                    {
                        Console.WriteLine(resultado.Item2 + ". Ingrese una contraseña valida");
                    }
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

        }
    }

    public class Contraseña
    {
        private string numeros = "0123456789";
        private string minusculas = "abcdefghijklmnñopqrstuvwxyz";
        private string mayusculas = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        private string especiales = "#$%&!?";
        private int numContiene = 0, minContiene = 0, mayContiene = 0, espContiene = 0;

        public string GenerarContraseña()
        {
            Random random = new Random();

            int longitudContraseña = random.Next(8, 21);

            double numTener = longitudContraseña * .15;
            double minTener = longitudContraseña * .35;
            double mayTener = longitudContraseña * .35;
            double espTener = longitudContraseña * .15;

            char caracterEscogido;

            StringBuilder contraseñaBuilder = new StringBuilder();

            while (contraseñaBuilder.Length < longitudContraseña)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        if (numContiene < numTener)
                        {
                            caracterEscogido = numeros[random.Next(0, numeros.Length)];
                            numContiene++;
                            contraseñaBuilder.Append(caracterEscogido);
                        }
                        break;
                    case 1:
                        if (minContiene < minTener)
                        {
                            caracterEscogido = minusculas[random.Next(0, minusculas.Length)];
                            minContiene++;
                            contraseñaBuilder.Append(caracterEscogido);
                        }
                        break;
                    case 2:
                        if (mayContiene < mayTener)
                        {
                            caracterEscogido = mayusculas[random.Next(0, mayusculas.Length)];
                            mayContiene++;
                            contraseñaBuilder.Append(caracterEscogido);
                        }
                        break;
                    case 3:
                        if (espContiene < espTener)
                        {
                            caracterEscogido = especiales[random.Next(0, especiales.Length)];
                            espContiene++;
                            contraseñaBuilder.Append(caracterEscogido);
                        }
                        break;

                }
            }

            return contraseñaBuilder.ToString();
        }

        public (bool, string) VerificarContraseña(string contraseña)
        {
            bool contraseñaValida = false;
            string mensaje = "";
            bool esNumero = false, esMinuscula = false, esMayuscula = false, esEspecial = false;

            if (contraseña.Length >= 8 && contraseña.Length <= 20)
            {
                foreach (char elemento in numeros)
                {
                    if (contraseña.IndexOf(elemento) >= 0)
                    {
                        esNumero = true;
                        break;
                    }
                    else
                    {
                        esNumero = false;
                    }
                }

                if (esNumero)
                {
                    foreach (char elemento in minusculas)
                    {
                        if (contraseña.IndexOf(elemento) >= 0)
                        {
                            esMinuscula = true;
                            break;
                        }
                        else
                        {
                            esMinuscula = false;
                        }
                    }

                    if (esMinuscula)
                    {
                        foreach (char elemento in mayusculas)
                        {
                            if (contraseña.IndexOf(elemento) >= 0)
                            {
                                esMayuscula = true;
                                break;
                            }
                            else
                            {
                                esMayuscula = false;
                            }
                        }

                        if (esMayuscula)
                        {
                            foreach (char elemento in especiales)
                            {
                                if (contraseña.IndexOf(elemento) >= 0)
                                {
                                    esEspecial = true;
                                    break;
                                }
                                else
                                {
                                    esEspecial = false;
                                }
                            }

                            if (esEspecial)
                            {
                                mensaje = "Contraseña válida";
                                contraseñaValida = true;
                            }
                            else
                            {
                                mensaje = "La contraseña debe contener al menos un caracter especial";
                                contraseñaValida = false;
                            }

                            return (contraseñaValida, mensaje);
                        }
                        else
                        {
                            mensaje = "La contraseña debe contener al menos una letra mayúscula";
                            contraseñaValida = false;
                        }

                    }
                    else
                    {
                        mensaje = "La contraseña debe contener al menos una letra minúscula";
                        contraseñaValida = false;
                    }
                }
                else
                {
                    mensaje = "La contraseña debe contener al menos un número";
                    contraseñaValida = false;
                }
            }
            else
            {
                mensaje = "La contraseña debe tener entre 8 y 20 caracteres";
                contraseñaValida = false;
            }
            return (contraseñaValida, mensaje);
        }

    }
}

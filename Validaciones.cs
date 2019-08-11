using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ABMLEmpleados
{
    static class Validaciones
    {

        public static int ANumeroEntero(string valor)
        {
            int b;
            bool esEntero = int.TryParse(valor, out b);

            if (esEntero) return b;
            else
            {
                Console.WriteLine("El valor ingresado no es un numero entero, ingrese nuevamente");
                return ANumeroEntero(Console.ReadLine());
            }
        }

        public static string ValidaNombre(string valor)
        {
            Regex rex = new Regex("^[a-zA-Z ]+$");

            if (rex.IsMatch(valor)) return valor;

            else
            {
                Console.Write("Ha ingresado un nombre invalido, ingrese nuevamente: ");
                return ValidaNombre(Console.ReadLine());
            }
        }

        public static string ValidaDNI(string valor)
        {

            Regex rex = new Regex("^[0-9]+$");

            if (rex.IsMatch(valor))
            {
                return valor;
            }
            else
            {
                Console.Write("El dni debe contener solo numeros, ingrese nuevamen: ");
                return ValidaDNI(Console.ReadLine());
            }
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ABMLEmpleados
{
    class Menu
    {
        ABML aBML = new ABML();
        public void CargarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("MENU PRINCIPAL.\n");
                Console.WriteLine("1-CARGAR EMPLEADO.");
                Console.WriteLine("2-DAR DE BAJA UN EMPLEADO.");
                Console.WriteLine("3-MODIFICAR EMPLEADO.");
                Console.WriteLine("4-CONSULTAR EMPLEADO.");
                Console.WriteLine("5-LISTA DE EMPLEADOS.");
                Console.WriteLine("0-SALIR.\n");
                opcion = Validaciones.ANumeroEntero(Console.ReadLine());
                Console.Clear();
                OpcionMenu(opcion);
            } while (opcion != 0);
        }
        
        public void OpcionMenu(int opcion)
        {
            string dni;
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el DNI :");
                    dni = Validaciones.ValidaDNI(Console.ReadLine());
                    aBML.CargarEmpleado(dni);
                    break;
                case 2:
                    Console.Write("Ingresa el DNI del empleado que desea dar de baja: ");
                    dni = Validaciones.ValidaDNI(Console.ReadLine());
                    aBML.BajaEmpleado(dni);
                    break;
                case 3:
                    Console.Write("Ingresa el DNI del empleado que desea modificar: ");
                    dni = Validaciones.ValidaDNI(Console.ReadLine());
                    aBML.ModificarEmpleado(dni);
                    break;
                case 4:
                    Console.WriteLine("Ingrese el DNI del empleado.");
                    dni = Validaciones.ValidaDNI(Console.ReadLine());
                    aBML.ConsultaEmpleado(dni);
                    break;
                case 5:
                    aBML.ListaEmpleado();
                    break;
                default:
                    if (opcion != 0)
                    {
                        Console.WriteLine("Fuera de rango.");
                    }
                    break;
            }
        }

    }
}

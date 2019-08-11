using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ABMLEmpleados
{
    class ABML
    {
        List<Empleado> empleados = new List<Empleado>();

        public void CargarEmpleado(string dni)
        {
            int opcion;
            do
            {
                if (ExisteEmpleado(dni))
                {
                    if (!EmpleadoAtDNI(dni).ACTIVO)
                    {
                        Console.WriteLine("Ya exist un empleado con ese DNI dado de baja, "+ EmpleadoAtDNI(dni).ToString()+" \nQue desea hacer?");
                        Console.WriteLine();
                        Console.WriteLine("1-Darlo de alta.\n2-Modificarlo y darlo de alta.\n3-Ingresar otro empleado.");
                        opcion = Validaciones.ANumeroEntero(Console.ReadLine());
                        if (opcion == 1)
                        {
                            EmpleadoAtDNI(dni).ACTIVO = true;
                            Console.WriteLine("Se dio de alta al empleado "+ EmpleadoAtDNI(dni).ToString());
                        }
                        else if (opcion == 2)
                        {
                            EmpleadoAtDNI(dni).ACTIVO = true;
                            ModificarEmpleado(dni);
                        }
                        else if (opcion == 3)
                        {
                            Console.Write("Ingrese el DNI :");
                            dni = Validaciones.ValidaDNI(Console.ReadLine());
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ya existe un empleado con ese DNI. \n");
                    }
                }
                else
                {
                    CargarEmpleado(out string nombre, out string apellido, out int edad, out string fecha);
                    empleados.Add(new Empleado(nombre, apellido, edad, dni, fecha));
                }

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1-CARGAR OTRO EMPLEADO.\n0-VOLVER AL MENU PRINCIPAL.");
                    opcion = Validaciones.ANumeroEntero(Console.ReadLine());
                    Console.WriteLine();
                    if (opcion != 1 && opcion != 0)
                    {
                        Console.WriteLine("Fuera de rango. ");
                    }
                    else if (opcion == 1)
                    {
                        Console.Write("Ingrese el DNI :");
                        dni = Validaciones.ValidaDNI(Console.ReadLine());
                    }
                } while (opcion != 0 && opcion != 1);

            } while (opcion != 0);
        }

        public void BajaEmpleado(string dni)
        {
            Empleado emp = DevuelveEmpleado(dni);
            if (emp != null)
            {
                emp.ACTIVO = false;
                Console.WriteLine("Se dio de baja a " + emp.ToString());
            }
        }

        public void ModificarEmpleado(string dni)
        {
            Empleado emp = DevuelveEmpleado(dni);
            if (emp != null)
            {
                if (!emp.ACTIVO)
                {
                    Console.WriteLine("Empleado dado de baja.");
                }
                else
                {
                    Console.WriteLine("Empleado a modificar: " + emp.ToString());
                    Console.Write("Ingrese el DNI :");
                    dni = Validaciones.ValidaDNI(Console.ReadLine());

                    if (ExisteEmpleado(dni) && dni != emp.DNI)
                    {
                        Console.WriteLine("YA EXISTE UN EMPLEADO CON ESE DNI. \n");
                    }
                    else
                    {
                        CargarEmpleado(out string nombre, out string apellido, out int edad, out string fecha);
                        emp.NOMBRE = nombre;
                        emp.APELLIDO = apellido;
                        emp.EDAD = edad;
                        emp.DNI = dni;

                        Console.WriteLine("EMPLEADO MODIFICADO. ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void ConsultaEmpleado(string dni)
        {

            Empleado emp = DevuelveEmpleado(dni);
            if (emp != null && emp.ACTIVO)
            {
                Console.WriteLine(emp.ToString());
            }
            else if (emp != null && !emp.ACTIVO)
            {
                Console.WriteLine("El empleado esta dado de baja");
            }
        }

        public void ListaEmpleado()
        {
            foreach (Empleado empleado  in empleados)
            {
                if (empleado.ACTIVO)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }
            Console.WriteLine("\n");
        }

        public Empleado DevuelveEmpleado(string dni)
        {
            if (ExisteEmpleado(dni))
            {
                return EmpleadoAtDNI(dni);
            }
            else
            {
                Console.WriteLine("No existe empleado con ese dni.");
                return null;
            }
        }

        public bool ExisteEmpleado(string dni)
        {
            if (empleados.Exists(item => item.DNI == dni)) return true;
            return false;
        }

        public Empleado EmpleadoAtDNI(string dni)
        {
            int index = empleados.FindIndex(em => em.DNI == dni);
            return empleados.ElementAt(index);
        }


        public void CargarEmpleado(out string nombre, out string apellido, out int edad, out string fecha)
        {
           
            Console.Write("Ingrese el nombre: ");
            nombre = Validaciones.ValidaNombre(Console.ReadLine());
            Console.Write("Ingrese el apellido: ");
            apellido = Validaciones.ValidaNombre(Console.ReadLine());
            Console.Write("Ingrese la edad: ");
            edad = Validaciones.ANumeroEntero(Console.ReadLine());
            Console.Write("Ingrese la fecha de nacimiento: ");
            fecha = Console.ReadLine();
        }


    }
}

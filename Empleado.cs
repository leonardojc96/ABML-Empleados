using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ABMLEmpleados
{
    class Empleado
    {
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        int edad;
        public int EDAD { get => edad;  set => edad = SetEdad(value); }
        public string DNI { get; set;  }
        public bool ACTIVO { get; set; }
        public string FechaNaciomiento  { get; set; }

        public Empleado() { }

        public Empleado(string nombre, string apellido, int edad, string dni, string fecha)
        {
            this.NOMBRE = nombre;
            this.APELLIDO = apellido;
            this.EDAD = SetEdad(edad);
            this.DNI = dni;
            this.FechaNaciomiento = fecha;
            ACTIVO = true;
        }

        public override string ToString()
        {
            return this.APELLIDO + " " + this.NOMBRE + ", " + this.EDAD+ " años, fecha nacimiento: "+FechaNaciomiento+"   DNI: "+DNI;
        }

        private int SetEdad (int edad)
        {
            
            if (edad < 18)
            {
                Console.WriteLine("La edad ingresada es menor a 18. Se le asignó la edad de 18 años.");
                Console.WriteLine();
                return 18;
            }
            return edad;
        }


        
    }
}

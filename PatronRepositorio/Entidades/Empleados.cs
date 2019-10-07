using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombres { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Cedula { get; set; }

        public double Sueldo { get; set; }

        public double Incentivo { get; set; }

        public Empleados()
        {

        }

        public Empleados(int empleadoId, DateTime fecha, string nombres, string direccion, string telefono, string celular, string cedula, double sueldo, double incentivo)
        {
            EmpleadoId = empleadoId;
            Fecha = fecha;
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Celular = celular ?? throw new ArgumentNullException(nameof(celular));
            Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula));
            Sueldo = sueldo;
            Incentivo = incentivo;
        }
    }
}

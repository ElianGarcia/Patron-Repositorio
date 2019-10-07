using PatronRepositorio.BLL;
using PatronRepositorio.DAL;
using PatronRepositorio.Entidades;
using System;
using System.Windows.Forms;

namespace PatronRepositorio.UI
{
    public partial class rEmpleados : Form
    {
        GenericaBLL<Empleados> generica;
        public rEmpleados()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            tbSueldo.Text = string.Empty;
            tbIncentivo.Text = string.Empty;
            tbNombres.Text = string.Empty;
            tbDireccion.Text = string.Empty;
            tbCedula.Text = string.Empty;
            tbCelular.Text = string.Empty;
            Fecha.Value = DateTime.Now;
            tbSueldo.Text = string.Empty;
            errorProvider.Clear();
        }

        private Empleados LlenaCLase()
        {
            Empleados empleado = new Empleados();
            empleado.EmpleadoId = Convert.ToInt32(IDnumericUpDown.Value);
            empleado.Nombres = tbNombres.Text;
            empleado.Direccion = tbDireccion.Text;
            empleado.Cedula = tbCedula.Text;
            empleado.Celular = tbCelular.Text;
            empleado.Sueldo = Convert.ToDouble(tbSueldo.Text);
            empleado.Incentivo = Convert.ToDouble(tbIncentivo.Text);
            empleado.Fecha = Fecha.Value;

            return empleado;
        }

        private void LlenaCampos(Empleados empleado)
        {
            IDnumericUpDown.Value = empleado.EmpleadoId;
            tbNombres.Text = empleado.Nombres;
            tbDireccion.Text = empleado.Direccion;
            tbCedula.Text = empleado.Cedula;
            tbTelefono.Text = empleado.Telefono;
            tbCelular.Text = empleado.Celular;
            Fecha.Value = empleado.Fecha;
            tbIncentivo.Text = empleado.Incentivo.ToString();
            tbSueldo.Text = empleado.Sueldo.ToString();

        }

        private bool Validar()
        {
            bool realizado = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(tbNombres.Text))
            {
                errorProvider.SetError(tbNombres, "EL CAMPO NOMBRE NO PUEDE ESTAR VACIO");
                tbNombres.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(IDnumericUpDown.Text))
            {
                errorProvider.SetError(IDnumericUpDown, "EL CAMPO ID NO PUEDE ESTAR VACIO");
                IDnumericUpDown.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbCedula.Text.Replace("-", "")))
            {
                errorProvider.SetError(tbCedula, "EL CAMPO CEDULA NO PUEDE ESTAR VACIO");
                tbCedula.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbDireccion.Text))
            {
                errorProvider.SetError(tbDireccion, "EL CAMPO DIRECCION NO PUEDE ESTAR VACIO");
                tbDireccion.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbSueldo.Text))
            {
                errorProvider.SetError(tbSueldo, "EL CAMPO Sueldo NO PUEDE ESTAR VACIO");
                tbSueldo.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbIncentivo.Text))
            {
                errorProvider.SetError(tbIncentivo, "EL CAMPO INCENTIVO NO PUEDE ESTAR VACIO");
                tbIncentivo.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbCelular.Text.Replace("-", "")))
            {
                errorProvider.SetError(tbCelular, "EL CAMPO CELULAR NO PUEDE ESTAR VACIO");
                tbCelular.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbTelefono.Text.Replace("-", "")))
            {
                errorProvider.SetError(tbTelefono, "EL CAMPO TELEFONO NO PUEDE ESTAR VACIO");
                tbTelefono.Focus();
                realizado = false;
            }

            return realizado;
        }

        private bool Existe()
        {
            Empleados estudiante = generica.Buscar((int)IDnumericUpDown.Value);

            return (estudiante != null);
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            int id;
            Empleados empleado = new Empleados();
            generica = new GenericaBLL<Empleados>();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            empleado = generica.Buscar(id);

            if (empleado != null)
            {
                LlenaCampos(empleado);
            }
            else
            {
                MessageBox.Show("Empleado No Encontrado");
            }
        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            bool realizado = false;

            if (!Validar())
                return;

            empleado = LlenaCLase();


            if (IDnumericUpDown.Value == 0)
                realizado = generica.Guardar(empleado);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("NO SE PUEDE MODIFICAR UN EMPLEADO INEXISTENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                realizado = generica.Modificar(empleado);
            }

            if (realizado)
            {
                Limpiar();
                MessageBox.Show("GUARDADO EXITOSAMENTE", "GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR", "NO GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Contexto db = new Contexto();

            Empleados empleado = new Empleados();

            Limpiar();

            if (generica.Eliminar(id))
            {
                MessageBox.Show("Eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                errorProvider.SetError(IDnumericUpDown, "No se puede eliminar un empleado inexistente");
            }
        }
    }
}

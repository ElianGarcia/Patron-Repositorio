using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PatronRepositorio.UI.cEmpleados
{
    public partial class cEmpleados : Form
    {
        GenericaBLL<Empleados> genericaBLL;
        public cEmpleados()
        {
            InitializeComponent();
        }

        private void BtConsulta_Click(object sender, EventArgs e)
        {
            var listado = new List<Empleados>();
            GenericaBLL<Empleados> genericaBLL = new GenericaBLL<Empleados>();

            if (tbCriterio.Text.Trim().Length > 0)
            {
                switch (cbFiltrar.SelectedIndex)
                {
                    case 0:
                        listado = genericaBLL.GetList(empleado => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(tbCriterio.Text);
                        listado = genericaBLL.GetList(empleado => empleado.EmpleadoId == id);
                        break;

                    case 2:
                        listado = genericaBLL.GetList(empleado => empleado.Nombres.Contains(tbCriterio.Text));
                        break;
                    case 3:
                        listado = genericaBLL.GetList(empleado => empleado.Cedula.Contains(tbCriterio.Text));
                        break;
                }

                listado = listado.Where(c => c.Fecha.Date >= DesdeDateTimePicker.Value.Date && c.Fecha.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = genericaBLL.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}

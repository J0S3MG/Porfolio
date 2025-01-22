using WinFormsCliente.Models;
using WinFormsCliente.Services;

namespace WinFormsCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AlumnoService servicio = new AlumnoService();
        #region Caso GetAll.
        private async void btnListar_Click(object sender, EventArgs e)
        {
            dgViews.Rows.Clear();
            foreach (var l in await servicio.GetAll())
            {
                dgViews.Rows.Add(new object[] { l.Id, l.Nombre, l.LU, l.Nota });
            }
        }
        #endregion
        #region Caso GetById.
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxID.Text);
            dgViews.Rows.Clear();
            var a = await servicio.GetById(id);
            dgViews.Rows.Add(new object[] { a.Id, a.Nombre, a.LU, a.Nota });
        }
        #endregion
        #region Caso Insert.
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxID.Text);
            int lu = Convert.ToInt32(tbxLU.Text);
            string nom = tbxNombre.Text;
            decimal nota = Convert.ToDecimal(tbxNota.Text);

            var a = new Alumno() { Id = id, Nombre = nom, LU = lu, Nota = nota };
            var a2 = await servicio.Insert(a);
            if (a2 != null)
            {
                MessageBox.Show("Alumno Agregado correctamente");
                dgViews.Rows.Clear();
                foreach (var l in await servicio.GetAll())
                {
                    dgViews.Rows.Add(new object[] { l.Id, l.Nombre, l.LU, l.Nota });
                }
            }
        }
        #endregion
        #region Caso Update
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxID.Text);
            int lu = Convert.ToInt32(tbxLU.Text);
            string nom = tbxNombre.Text;
            decimal nota = Convert.ToDecimal(tbxNota.Text);

            var a = new Alumno() { Id = id, Nombre = nom, LU = lu, Nota = nota };
            var a2 = await servicio.Update(a);
            if (a2 != null)
            {
                MessageBox.Show("Alumno Editado Correctamente");
                dgViews.Rows.Clear();
                dgViews.Rows.Add(new object[] { a2.Id, a2.Nombre, a2.LU, a2.Nota });
            }
        }
        #endregion
        #region Caso Delete
        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxID.Text);
            var b = await servicio.Delete(id);
            if (b != true)
            {
                MessageBox.Show("No se pudo allar al alumno");
            }
            MessageBox.Show("El alumno se borro correctamente");
            dgViews.Rows.Clear();
            foreach (var l in await servicio.GetAll())
            {
                dgViews.Rows.Add(new object[] { l.Id, l.Nombre, l.LU, l.Nota });
            }
        }
        #endregion
    }
}

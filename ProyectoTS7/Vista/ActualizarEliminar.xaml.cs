using ProyectoTS7.Modelos;
using System;
using System.Net;
using System.Threading.Tasks;


namespace ProyectoTS7.Vista
{
    public partial class ActualizarEliminar : ContentPage
    {
        private Estudiante datos;

        public ActualizarEliminar(Estudiante datos)
        {
            InitializeComponent();
            this.datos = datos;
            lblCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre;
            txtApellido.Text = datos.apellido;
            txtEdad.Text = datos.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string codigo = lblCodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;

                string url = "http://172.25.96.1/moviles/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad;
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                cliente.UploadValues(url, "PUT", parametros);
                Navigation.PushAsync(new Inicio());
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR", ex.Message, "CERRAR");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string codigo = lblCodigo.Text;

                string url = "http://172.25.96.1/moviles/post.php?codigo=" + codigo;
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                cliente.UploadValues(url, "DELETE", parametros);
                Navigation.PushAsync(new Inicio());
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR", ex.Message, "CERRAR");
            }
        }
    }
}
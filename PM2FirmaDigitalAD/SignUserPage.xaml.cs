using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace PM2FirmaDigitalAD
{
    public partial class SignUserPage : ContentPage
    {
        public SignUserPage()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(System.Object sender, System.EventArgs e)
        {
            Stream image = await this.SignPadView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            BinaryReader br = new BinaryReader(image);

            Byte[] bytesPath = br.ReadBytes((Int32)image.Length);
            String pathBase64 = Convert.ToBase64String(bytesPath, 0, bytesPath.Length);

            var mStream = new MemoryStream(bytesPath);

            if (!String.IsNullOrEmpty(txtNombre.Text) || !String.IsNullOrEmpty(txtDescripcion.Text))
            {
                Models.UsuarioFirma usuario = new Models.UsuarioFirma{nombre = txtNombre.Text, descripcion = txtDescripcion.Text, imagen = pathBase64 };

                await App.BaseDatos.GuardarUsuario(usuario);

                await DisplayAlert("", "Se ha guardado correctamente", "OK");
                txtNombre.Text = String.Empty;
                txtDescripcion.Text = String.Empty;
                
            }
            else
            {
                await DisplayAlert("Alerta", "Por favor complete la información", "OK");
            }
        }

        private async void btnListaFirmas_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.SignatureListPage());
        }
    }
}

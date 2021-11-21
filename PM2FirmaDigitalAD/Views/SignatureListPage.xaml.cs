using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace PM2FirmaDigitalAD.Views
{
    public partial class SignatureListPage : ContentPage
    {
        public SignatureListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listaUsuariosFirmas = await App.BaseDatos.ObtenerListadoUsuarios();
            
            List<ImageSource> firmasStreams = new List<ImageSource>();

            foreach (var u in listaUsuariosFirmas)
            {
                byte[] imagenBytes = Convert.FromBase64String(u.imagen);
                var memoryStream = new MemoryStream(imagenBytes);

                firmasStreams.Add(ImageSource.FromStream(() => new MemoryStream(imagenBytes)));
            }
            
            listaUsuarios.ItemsSource = firmasStreams;
        }

    }
}

using jlicuyT6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jlicuyT6.Views;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.0.26/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();
	}

	public async void ObtenerDatos()
	{
        /*
		var content = await cliente.GetStringAsync(url);
		List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		est = new ObservableCollection<Estudiante>(mostrar);
		listEstudiante.ItemsSource = est;
		*/
        var content = await cliente.GetStringAsync(url);
        List<Estudiante> estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);

        int fila = 1; // Comienza después de los encabezados
        foreach (var estudiante in estudiantes)
        {
            gridEstudiantes.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});

            var labelCodigo = new Label { Text = estudiante.codigo.ToString() };
            Grid.SetRow(labelCodigo, fila);
            Grid.SetColumn(labelCodigo, 0);
            gridEstudiantes.Children.Add(labelCodigo);

            var labelNombre = new Label { Text = estudiante.nombre };
            Grid.SetRow(labelNombre, fila);
            Grid.SetColumn(labelNombre, 1);
            gridEstudiantes.Children.Add(labelNombre);

            var labelApellido = new Label { Text = estudiante.apellido };
            Grid.SetRow(labelApellido, fila);
            Grid.SetColumn(labelApellido, 2);
            gridEstudiantes.Children.Add(labelApellido);

            var labelEdad = new Label { Text = estudiante.edad.ToString() };
            Grid.SetRow(labelEdad, fila);
            Grid.SetColumn(labelEdad, 3);
            gridEstudiantes.Children.Add(labelEdad);

            fila++;
        }

    }
}
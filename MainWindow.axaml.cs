using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MiPresentacion;

public partial class MainWindow : Window
{
    private const string MensajeInicial = "Completa el formulario y presiona «Presentarme».";

    private bool _saludoAlterno = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private bool TryObtenerDatos(out string nombre, out string apellido, out int edad)
    {
        nombre = (TxtNombre.Text ?? "").Trim();
        apellido = (TxtApellido.Text ?? "").Trim();
        string edadTexto = (TxtEdad.Text ?? "").Trim();
        edad = 0;

        if (string.IsNullOrWhiteSpace(nombre))
        {
            TxtResultado.Text = "⚠ Advertencia: el nombre no puede estar vacío.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            TxtResultado.Text = "⚠ Advertencia: el apellido no puede estar vacío.";
            return false;
        }

        if (!int.TryParse(edadTexto, out edad))
        {
            TxtResultado.Text = "⚠ Advertencia: la edad debe ser un número entero.";
            return false;
        }

        if (edad <= 0)
        {
            TxtResultado.Text = "⚠ Advertencia: la edad debe ser un número entero positivo.";
            return false;
        }

        return true;
    }

    private void MostrarPresentacion(string nombre, string apellido, int edad)
    {
        if (_saludoAlterno)
        {
            TxtResultado.Text =
                $"¡Qué gusto conocerte! Soy {nombre} {apellido}, " +
                $"tengo {edad} años y me encanta crear aplicaciones con Avalonia UI y C#.";
        }
        else
        {
            TxtResultado.Text =
                $"¡Hola! Mi nombre es {nombre} {apellido},\n" +
                $"tengo {edad} años y estoy aprendiendo\n" +
                "a desarrollar interfaces gráficas con C#.";
        }
    }

    private void BtnPresentarme_Click(object? sender, RoutedEventArgs e)
    {
        if (TryObtenerDatos(out string nombre, out string apellido, out int edad))
        {
            MostrarPresentacion(nombre, apellido, edad);
        }
    }

    private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
    {
        TxtNombre.Text = "";
        TxtApellido.Text = "";
        TxtEdad.Text = "";
        TxtResultado.Text = MensajeInicial;
        TxtNombre.Focus();
    }

    private void BtnCambiarSaludo_Click(object? sender, RoutedEventArgs e)
    {
        _saludoAlterno = !_saludoAlterno;

        if (TryObtenerDatos(out string nombre, out string apellido, out int edad))
        {
            MostrarPresentacion(nombre, apellido, edad);
        }
    }
}

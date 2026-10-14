using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using imc.Maui.Models;

namespace imc.Maui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _peso;
        [ObservableProperty]
        private string _estatura;
        [ObservableProperty]
        private string _imc;
        [ObservableProperty]
        private string _estadoNutricional;

        public MainViewModel()
        {
            Limpiar();
        }


        [RelayCommand]
        private void Limpiar()
        {
            Peso = string.Empty;
            EstadoNutricional = string.Empty;
            Imc = string.Empty;
            Estatura = string.Empty;
        }

        [RelayCommand]
        private void Calcular()
        {
            decimal peso;
            decimal estatura;
            bool PesoEsValido = decimal.TryParse(Peso, out peso);
            bool EstaturaEsValida = decimal.TryParse(Estatura, out estatura);

            if (PesoEsValido && EstaturaEsValida) 
            {
             decimal imc = CalculadoraImc.IndiceDeMasaCorporal(peso, estatura);
             Imc = imc.ToString("F4");
             EstadoNutricional = CalculadoraImc.SituacionNutricional(imc);
            }
        }

    }
}

    


using imc.Maui.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace imc.Maui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _peso;
        private string _estatura;

        private string _imc;
        private string _estadoNutricional;

  
        public string Peso
        {
            get => _peso;

            set
            {
                if (_peso != value) { _peso = value; }
                OnPropertyChanged(nameof(Peso));
            }
        }

        public string Estatura
        {
            get => _estatura;
            set
            {
                if (_estatura != value) { _estatura = value; OnPropertyChanged(nameof(Estatura)); }
            }
        }

        public string Imc
        {
            get => _imc;
            set
            {
                if (_imc != value) { _imc = value; OnPropertyChanged(nameof(Imc)); }
            }
        }

        public string EstadoNutricional
        {
            get => _estadoNutricional;
            set {
                if (_estadoNutricional != value) { _estadoNutricional = value; OnPropertyChanged(nameof(EstadoNutricional)); }
            }
        }

        public ICommand CalcularCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }

        private void LimpiarDatos()
        {
            Peso = string.Empty;
            EstadoNutricional = string.Empty;
            Imc = string.Empty;
            Estatura = string.Empty;
        }



        public MainViewModel()
        {
            LimpiarDatos();
            CalcularCommand = new Command(CalcularResultados);
            LimpiarCommand = new Command(LimpiarDatos);
        }

        private void CalcularResultados()
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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

    


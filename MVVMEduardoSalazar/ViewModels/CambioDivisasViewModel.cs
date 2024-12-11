using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMEduardoSalazar.ViewModels
{
    
    public class CambioDivisasViewModel : INotifyPropertyChanged
    {
        //Variables privadas que nos permiten manejar información
        private string _valorDolares; //El guion bajo se lo utiliza cuando se definen atributos privados
        private string _valorEuros;

        public string ValorDolares
        {
            get => _valorDolares;
            set {
                if (_valorDolares != value)
                {
                    _valorDolares = value; //Obtengo información que cambie
                    OnPropertyChanged();
                    //Generar eventos para transformar de Dolares a Euros
                    ConvertirDeDolaresAEuros();
                    

                }
            }
            
        }
        public string ValorEuros
        {
            get => _valorEuros;
            set
            {
                if (_valorEuros != value)
                {
                    _valorEuros = value;
                    OnPropertyChanged();//OnPropetyChange avisa a mi vista que hubo un cambio
                    //Generar eventos para transformar de Euros a Dolares
                    //ConvertirDeEurosADolares(); 
                                                

                }

            }
        }

        public void ConvertirDeDolaresAEuros()
        {
            double conversion = double.Parse(_valorDolares)*0.95;
            ValorEuros = $"{conversion:F2}";
        }
        public void ConvertirDeEurosADolares()
        {
            double conversion = double.Parse(_valorEuros) * 1.05;
            ValorDolares = $"{conversion:F2}";
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

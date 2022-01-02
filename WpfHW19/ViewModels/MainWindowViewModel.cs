using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfHW19.Models;

namespace WpfHW19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int number1;
        public int Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }

        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand CircleLengthCommand { get; }
        private void OnCircleLengthCommandExecute(object p)
        {
            Number2 = CircleLength.Calculate(Number1);
        }
        private bool CanCircleLengthCommandExecuted(object p)
        {
            if (Number1 != 0)
            {
                return true;
            }
            else return false;
        }
        public MainWindowViewModel()
        {
            CircleLengthCommand = new RelayCommand(OnCircleLengthCommandExecute, CanCircleLengthCommandExecuted);
        }
    }
}

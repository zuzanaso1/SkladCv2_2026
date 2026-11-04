using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SkladCv2_2026.Views; // Uprav podle svého namespace, kde se nacházejí Views

namespace SkladCv2_2026.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private bool _tabulkyPovoleny = true; // Výchozí stav zaškrtnuto

        public bool TabulkyPovoleny
        {
            get => _tabulkyPovoleny;
            set
            {
                _tabulkyPovoleny = value;
                OnPropertyChanged();
            }
        }

        // Příkazy pro tlačítka
        public ICommand OpenMaterialCommand { get; }
        public ICommand OpenPaletyCommand { get; }
        public ICommand OpenPrehledMaterialuCommand { get; }
        public ICommand OpenPrehledPaletCommand { get; }

        public MainWindowVM()
        {
            //OpenMaterialCommand = new RelayCommand(o => new MaterialView().Show());
            //OpenPaletyCommand = new RelayCommand(o => new PaletyView().Show());
            //OpenPrehledMaterialuCommand = new RelayCommand(o => new PrehledMaterialuView().Show());
            //OpenPrehledPaletCommand = new RelayCommand(o => new PrehledPaletView().Show());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Jednoduchá implementace ICommand (pokud ji již v projektu nemáš jinde)
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object? parameter) => _execute(parameter);
    }
}
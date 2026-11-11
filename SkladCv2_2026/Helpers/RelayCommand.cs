using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkladCv2_2026.Helpers
{
    /*/// <summary>
    /// Univerzální implementace rozhraní ICommand pro vzor MVVM v C#/WPF.
    /// Umožňuje přenést logiku tlačítka (nebo jiného ovládacího prvku) z rozhraní (View) přímo do ViewModelu.
    /// </summary>
    public class RelayCommand : ICommand
    {
        // Delegát uchovávající metodu, která se spustí při stisku tlačítka/vyvolání příkazu
        private readonly Action<object?> _execute;

        // Volitelný delegát určující podmínku, za jaké lze příkaz provést (vrací true/false)
        private readonly Predicate<object?>? _canExecute;

        /// <summary>
        /// Konstruktor třídy RelayCommand.
        /// </summary>
        /// <param name="execute">Metoda/akce, která se má vykonat. Nesmí být null.</param>
        /// <param name="canExecute">Volitelná logika (podmínka), zda je příkaz v danou chvíli aktivní.</param>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            // Pokud je předaný kód ke spuštění null, vyhodí výjimku ArgumentNullException
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(p => execute(), canExecute != null ? p => canExecute() : (Predicate<object>)null) { }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        /// <summary>
        /// Událost informující uživatelské rozhraní (WPF UI) o změně stavu příkazu.
        /// Nasměrováním na CommandManager.RequerySuggested zajistíme, že WPF automaticky přehodnotí,
        /// zda má být příslušné tlačítko aktivní (Enabled) nebo neaktivní (Disabled).
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Zjišťuje, zda je v tuto chvíli možné příkaz provést.
        /// Pokud nebylo předáno žádné omezení (_canExecute == null), vráceno je automaticky true.
        /// </summary>
        /// <param name="parameter">Parametr předaný z UI (např. přes CommandParameter v XAML).</param>
        /// <returns>True, pokud lze příkaz spustit; jinak False.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Vykoná předanou akci.
        /// </summary>
        /// <param name="parameter">Parametr předaný z UI.</param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }*/
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(p => execute(), canExecute != null ? p => canExecute() : (Predicate<object>)null) { }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }


}
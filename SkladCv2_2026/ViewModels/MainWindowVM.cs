using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SkladCv2_2026.Views; // Namespace, ve kterém se nacházejí jednotlivá okna/pohledy (Views)

namespace SkladCv2_2026.ViewModels
{
    /// <summary>
    /// Hlavní ViewModel pro okno MainWindow. 
    /// Implementuje INotifyPropertyChanged pro automatickou aktualizaci dat v UI (Data Binding).
    /// </summary>
    public class MainWindowVM : BaseVM
    {
        public ICommand OpenMaterialCommand { get; }
        public ICommand OpenPaletyCommand { get; }
        public ICommand OpenPrehledMaterialuCommand { get; }
        public ICommand OpenPrehledPaletCommand { get; }

        /// <summary>
        /// Konstruktor ViewModelu, kde se typicky inicializují jednotlivé příkazy.
        /// </summary>
        public MainWindowVM()
        {
            // Inicializace příkazů – po kliknutí na tlačítko se vytvoří a zobrazí odpovídající View (okno)
            // OpenMaterialCommand = new RelayCommand(o => new MaterialView().Show());
            // OpenPaletyCommand = new RelayCommand(o => new PaletyView().Show());
            // OpenPrehledMaterialuCommand = new RelayCommand(o => new PrehledMaterialuView().Show());
            // OpenPrehledPaletCommand = new RelayCommand(o => new PrehledPaletView().Show());
        }
    }
}
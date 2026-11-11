using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataEntity.Data;

namespace SkladCv2_2026.ViewModels
{
    public abstract class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Material>? materialyCol;

        public ObservableCollection<Material> MaterialyCol
        {
            get
            {   
                if (materialyCol == null)
                {
                    materialyCol = new ObservableCollection<Material>(
                        SkladCv2_2026.Globals.Globals.context.Material);
                }

                return materialyCol;
            }
        }
    }
}

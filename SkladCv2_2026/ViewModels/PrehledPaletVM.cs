using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using DataEntity.Data;
using DataEntity.Data.Enum;
using Microsoft.EntityFrameworkCore;
using SkladCv2_2026.Helpers;

namespace SkladCv2_2026.ViewModels
{
    public class PrehledPaletVM : BaseVM
    {
        private string vybranyTyp = "Vse";
        private string vybranyStav = "Vse";
        private string materialAdresa = string.Empty;

        public ObservableCollection<string> Typy { get; } =
            new()
            {
                "Vse",
                "Mala",
                "Velka",
                "Delena"
            };

        public ObservableCollection<string> Stavy { get; } =
            new()
            {
                "Vse",
                "Zaskladneno",
                "Vyskladneno",
                "V doprave"
            };

        public ObservableCollection<Paleta> Palety { get; }

        public ICollectionView FiltrovanePalety { get; }

        public ICommand ZrusitFiltryCommand { get; }

        public string VybranyTyp
        {
            get => vybranyTyp;
            set
            {
                if (vybranyTyp == value)
                    return;

                vybranyTyp = value;
                OnPropertyChanged();
                ObnovitFiltr();
            }
        }

        public string VybranyStav
        {
            get => vybranyStav;
            set
            {
                if (vybranyStav == value)
                    return;

                vybranyStav = value;
                OnPropertyChanged();
                ObnovitFiltr();
            }
        }

        public string MaterialAdresa
        {
            get => materialAdresa;
            set
            {
                if (materialAdresa == value)
                    return;

                materialAdresa = value;
                OnPropertyChanged();
                ObnovitFiltr();
            }
        }

        public int PocetPalet =>
            FiltrovanePalety.Cast<Paleta>().Count();

        public int SoucetMnozstvi =>
            FiltrovanePalety.Cast<Paleta>().Sum(paleta => paleta.Mnozstvi);

        public PrehledPaletVM()
        {
            ZrusitFiltryCommand = new RelayCommand(_ => ZrusitFiltry());

            Palety = new ObservableCollection<Paleta>(
                SkladCv2_2026.Globals.Globals.context.Paleta
                    .Include(paleta => paleta.Material)
                    .ThenInclude(material => material!.MernaJednotka)
                    .AsNoTracking()
                    .ToList());

            FiltrovanePalety = CollectionViewSource.GetDefaultView(Palety);
            FiltrovanePalety.Filter = FiltrovatPaletu;
        }

        private bool FiltrovatPaletu(object item)
        {
            if (item is not Paleta paleta)
                return false;

            bool typSouhlasi =
                VybranyTyp == "Vse" ||
                VybranyTyp == PrelozitTyp(paleta.Typ);

            bool stavSouhlasi =
                VybranyStav == "Vse" ||
                VybranyStav == PrelozitStav(paleta.Stav);

            string text = MaterialAdresa.Trim();

            bool textSouhlasi =
                string.IsNullOrWhiteSpace(text) ||
                (paleta.Material?.Nazev?.Contains(
                    text,
                    StringComparison.OrdinalIgnoreCase) ?? false) ||
                (paleta.AdresaUlozeni?.Contains(
                    text,
                    StringComparison.OrdinalIgnoreCase) ?? false);

            return typSouhlasi && stavSouhlasi && textSouhlasi;
        }

        private void ObnovitFiltr()
        {
            FiltrovanePalety.Refresh();
            OnPropertyChanged(nameof(PocetPalet));
            OnPropertyChanged(nameof(SoucetMnozstvi));
        }

        private void ZrusitFiltry()
        {
            VybranyTyp = "Vse";
            VybranyStav = "Vse";
            MaterialAdresa = string.Empty;
        }

        private static string PrelozitTyp(Enums.PaletaTyp typ)
        {
            return typ switch
            {
                Enums.PaletaTyp.Mala => "Mala",
                Enums.PaletaTyp.Velka => "Velka",
                Enums.PaletaTyp.Delena => "Delena",
                _ => typ.ToString()
            };
        }

        private static string PrelozitStav(Enums.PaletaStav stav)
        {
            return stav switch
            {
                Enums.PaletaStav.Zaskladneno => "Zaskladneno",
                Enums.PaletaStav.Vyskladneno => "Vyskladneno",
                Enums.PaletaStav.Doprava => "V doprave",
                _ => stav.ToString()
            };
        }
    }
}   
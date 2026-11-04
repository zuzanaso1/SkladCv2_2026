using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Data
{
    [AddINotifyPropertyChangedInterface] //automatický notifikace
    [Table("Material")]

    public class Material : Base.BaseModel
    {
        [Key]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Název materiálu je povinné pole")]
        [StringLength(150, ErrorMessage = "Maximální délka je 150")]
        public string Nazev { get; set; } = String.Empty;   //musíme nějak nadefinovat string, aby věděl že nějaký string je (viz meme) undefined 

        [Required(ErrorMessage = "Pojistné množství je povinné pole")]
        [Range(0, int.MaxValue, ErrorMessage = "Pojistné množství musí být kladné")]
        public int MnozPoj { get; set; } = 0; //dáváme nulu, aby tam něco bylo a nebyl undefined

        [Required(ErrorMessage = "Množství do palety je povinné pole")]
        [Range(0, int.MaxValue, ErrorMessage = "Množství do palety musí být kladné")]
        public int MnozDoPal{ get; set; } = 0;

        [Column(TypeName = "date")]
        public DateTime Datum { get; set; } = DateTime.Now; //abychom pořád nemuseli psát datum a čas

        public string Komentar { get; set; } = String.Empty; 

        public int MernaJednotkaID { get; set; }

        [ForeignKey(nameof(MernaJednotkaID))] 
        public virtual MernaJednotka MernaJednotka { get; set; } = null!;


        public virtual ObservableCollection<Paleta> Paleta { get; set; } = null!;
        public int CelkoveMnozstvi
        {
            get
            {
                return Paleta == null ? 0 : Paleta.Sum(x => x.Mnozstvi);
            }
        }

        public bool PodPojistnymMnozstvim
        {
            get
            {
                return CelkoveMnozstvi < MnozPoj;
            }
        }


    }
}

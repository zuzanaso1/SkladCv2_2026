using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Data
{
    [AddINotifyPropertyChangedInterface] //automatický notifikace
    [Table("Material")]

    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        [StringLength(60)]
        public string Nazev { get; set; } = String.Empty;   //musíme nějak nadefinovat string, aby věděl že nějaký string je (viz meme) undefined 

        public int MnozPoj { get; set; } = 0; //dáváme nulu, aby tam něco bylo a nebyl undefined

        public int MnozDoPal{ get; set; } = 0;

        [Column(TypeName = "date")]
        public DateTime Datum { get; set; } = DateTime.Now; //abychom pořád nemuseli psát datum a čas

        public string Komentar { get; set; } = String.Empty; 

        public int MernaJednotkaID { get; set; }

        [ForeignKey(nameof(MernaJednotkaID))] 
        public virtual MernaJednotka MernaJednotka { get; set; } = null!; 

    }
}

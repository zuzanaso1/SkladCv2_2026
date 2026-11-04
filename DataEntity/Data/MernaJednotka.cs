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
    [Table("MernaJednotka")]    //nezapomenout přejmenovat 

    public class MernaJednotka : Base.BaseModel
    {
        [Key]       //primární klíč
        public int MernaJednotkaID { get; set; }

        [StringLength(50, ErrorMessage = "Název nesmí být delší než 50 znaků.")]    //chybová hláška 
        public string Popis { get; set; } = String.Empty;   

        public virtual ObservableCollection<Material> Material{ get; set; } = null!;    

    }
}

using System;
using System.Collections.Generic;

namespace DefisStrategie.Models
{
    public partial class Auteurs
    {
        public Auteurs()
        {
            Films = new HashSet<Films>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? EstActif { get; set; }
        public string ModifierPar { get; set; }
        public string Userid { get; set; }

        public virtual ICollection<Films> Films { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DefisStrategie.Models
{
    public partial class Utilisateurs
    {
        public Utilisateurs()
        {
            Locations = new HashSet<Locations>();
        }

        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenoms { get; set; }
        public string AdresseGeographique { get; set; }
        public string Telephone { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? EstActif { get; set; }
        public string ModifierPar { get; set; }
        public string Userid { get; set; }

        public virtual ICollection<Locations> Locations { get; set; }
    }
}

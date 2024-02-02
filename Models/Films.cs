using System;
using System.Collections.Generic;

namespace DefisStrategie.Models
{
    public partial class Films
    {
        public Films()
        {
            Locations = new HashSet<Locations>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int? Duree { get; set; }
        public bool? EstDisponible { get; set; }
        public int? CategorieId { get; set; }
        public int? AuteurId { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? EstActif { get; set; }
        public string ModifierPar { get; set; }
        public string Userid { get; set; }

        public virtual Auteurs Auteur { get; set; }
        public virtual Categories Categorie { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DefisStrategie.Models
{
    public partial class Locations
    {
        public Guid Id { get; set; }
        public int? FilmId { get; set; }
        public Guid? UtilisateurId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? EstActif { get; set; }
        public string ModifierPar { get; set; }
        public string Userid { get; set; }

        public virtual Films Film { get; set; }
        public virtual Utilisateurs Utilisateur { get; set; }
    }
}

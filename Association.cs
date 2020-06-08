using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssisesSportLorrain
{
    public class Association
    {
        // Propriétés privées
        // Liste (collection) des Ateliers
        // Une collection est un "tableau dynamique" d'objets,
        // ici d'objets de type Atelier

        private string nomAssociation;
        private List<Atelier> lesAteliers;

        public Association(String nomAssociation)
        {
            this.nomAssociation = nomAssociation;
        }

        public List<Atelier> LesAteliers
        {
            get { return lesAteliers; }
            set { lesAteliers = value; }
        }

        public string NomAssociation
        {
            get { return nomAssociation; }
            set { nomAssociation = value; }
        }

        public int nbAteliers
        {
            get { return lesAteliers.Count; }
        }

        


        // Ajout d'un atelier
        public void ajouterAtelier(Atelier unAtelier)
        {
            lesAteliers.Add(unAtelier);
        }

        // Suppression d'un atelier
        public void supprimerAtelier(Atelier unTheme)
        {
            lesAteliers.Remove(unTheme);
        }

    }
}
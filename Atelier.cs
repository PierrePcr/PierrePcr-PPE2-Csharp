using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssisesSportLorrain
{
    public class Atelier
    {
        private int idAtelier;
        private string libelleAtelier;
        private int participantAtelier;


        public int IdAtelier
        {
            get { return idAtelier; }
            set { idAtelier = value; }
        }

        public string LibelleAtelier
        {
            get { return libelleAtelier; }
            set { libelleAtelier = value; }
        }

        public int ParticipantAtelier
        {
            get { return participantAtelier; }
            set { participantAtelier = value; }
        }


        public Atelier(int idAtelier, string libelleAtelier, int participantAtelier)
        {
            this.idAtelier = idAtelier;
            this.libelleAtelier = libelleAtelier;
            this.participantAtelier = participantAtelier;
        }


        public Atelier(int numAtelier, string nomAtelier)
        {
            this.idAtelier = numAtelier;
            this.libelleAtelier = nomAtelier;
        }
        

        



        public static List<Atelier> listeAteliers()
        {
            return DAOAtelier.getAllAteliers();
        }


        
        // Ajout d'un atelier
        public void ajouterAtelier()
        {
            DAOAtelier.creerAtelier(this);
        }

        public void ajouterAtelier3()
        {
            DAOAtelier.creerAtelier3(this);
        }


        public void modifierAtelier(int idAtelier, string libelleAtelier, int participantAtelier)
        {
            this.idAtelier = idAtelier + 1;
            this.libelleAtelier = libelleAtelier;
            this.participantAtelier = participantAtelier;
            DAOAtelier.modifierAtelier(this);
        }

        // Supprimer d'un atelier
        public void supprimerAtelier()
        {
            DAOAtelier.supprimerAtelier(this);

        }





        /*
                // Suppression d'un thème de l'atelier
                public void supprimerAtelier(Atelier unAtelier)
                {
                    lesAteliers.Remove(unAtelier);
                }


                // Ajout d'un thème à l'atelier
                public void ajouterTheme(Theme unTheme)
                {
                    lesThemes.Add(unTheme);
                }

                // Suppression d'un thème de l'atelier
                public void supprimerTheme(Theme unTheme)
                {
                    lesThemes.Remove(unTheme);
                }
                */
    }
}
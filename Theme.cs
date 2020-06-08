using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssisesSportLorrain
{
    public class Theme
    {
        private int idTheme;
        private string nomTheme;
        private int idAtelier;

        public Theme(int idTheme, string nomTheme, int idAtelier)
        {
            this.idTheme = idTheme;
            this.nomTheme = nomTheme;
            this.idAtelier = idAtelier;
        }

        #region Accesseurs
        public int IdTheme
        {
            get
            {
                return idTheme;
            }

            set
            {
                idTheme = value;
            }
        }

        public string NomTheme
        {
            get
            {
                return nomTheme;
            }

            set
            {
                nomTheme = value;
            }
        }

        public int IdAtelier
        {
            get
            {
                return idAtelier;
            }

            set
            {
                idAtelier = value;
            }
        }
        #endregion

        #region Méthodes d'appel au DAO métier

        // Méthode statique qui retourne l'ensemble des Themes sous forme de List
        public static List<Theme> listeThemes()
        {
            return DAOTheme.getAllThemes();
        }

        // Fait créer le Theme (objet courant) dans la BDD
        public void ajouterTheme()
        {
            DAOTheme.creerTheme(this);
        }

        // Fait modifier le Theme (objet courant) dans la BDD
        public void modifierTheme(int idTheme, string nomTheme, int idAtelier)
        {
            this.idTheme = idTheme + 1;
            this.nomTheme = nomTheme;
            this.idAtelier = idAtelier;
            DAOTheme.modifierTheme(this);
        }

        // Supprimer un theme
        public void supprimerTheme()
        {
            DAOTheme.supprimerTheme(this);

        }
        #endregion
    }
}
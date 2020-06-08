using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssisesSportLorrain
{
    class DAOTheme
    {
        // Retourne une collection de tous les Themes lus en BDD 
        public static List<Theme> getAllThemes()
        {
            List<Theme> lesThemes = new List<Theme>();
            string req = "select * from theme";
            DAOFactory db = new DAOFactory();
            db.connecter();

            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                Theme at = new Theme(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()));
                lesThemes.Add(at);
            }

            return lesThemes;
        }



        // Créer dans la BDD l'objet Theme passé en paramètre
        public static void creerTheme(Theme unTheme)
        {
            string requete = "insert into theme values('" + unTheme.IdTheme + "','" + unTheme.NomTheme + "','" + unTheme.IdAtelier + "')";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }



        // Modifie dans la BDD le solde de l'objet Theme passé en paramètre
        public static void modifierTheme(Theme unTheme)
        {
            string requete = "update theme set libelle = '" + unTheme.NomTheme + "', id_atelier = " + unTheme.IdAtelier + " where id_theme = '" + unTheme.IdTheme + "'";
            //string requete = "update theme set libelle = 'unlibelle', id_atelier = 3 where id_theme = 1";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }




        // Créer dans la BDD l'objet Theme passé en paramètre
        public static void supprimerTheme(Theme unTheme)
        {
            string requete = "delete from theme where id_theme = '" + unTheme.IdTheme + "'";

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }
    }
}

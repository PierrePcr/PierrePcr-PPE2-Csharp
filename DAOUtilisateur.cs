using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace AssisesSportLorrain
{
    class DAOUtilisateur
    {
        // Retourne une collection de tous les Ateliers lus en BDD 
        public static List<Utilisateur> getAllUtilisateurs()
        {
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
            string req = "select * from mrbs";
            DAOFactory db = new DAOFactory();
            db.connecter();

            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                Utilisateur ut = new Utilisateur(reader[1].ToString(), reader[2].ToString());
                lesUtilisateurs.Add(ut);
            }

            return lesUtilisateurs;

        }
        
        // Retourne une collection de tous les Ateliers lus en BDD 
        public static Utilisateur getlUtilisateur()
        {
            string req = "select * from mrbs where id_Utilisateur=1";
            DAOFactory db = new DAOFactory();
            db.connecter();

            SqlDataReader reader = db.excecSQLRead(req);

            Utilisateur lUtilisateur = new Utilisateur(reader[0].ToString(), reader[1].ToString());
            
            return lUtilisateur;

        }


        /*
        // Créer dans la BDD l'objet Atelier passé en paramètre
        public static bool connexionUtilisateur(Utilisateur unUtilisateur)
        {
            bool statutConnexion;
            string requete = "SELECT COUNT(*) FROM mrbs WHERE login_Utilisateur = '" + unUtilisateur.LoginUtilisateur + "' AND mdp_Utilisateur = '" + unUtilisateur.MdpUtilisateur + "' ";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);

            SqlConnection con = new SqlConnection("Data Source='PC-FIXE-PEDROO';Initial Catalog=M2L;Integrated Security=true;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM mrbs WHERE login_Utilisateur = '" + unUtilisateur.LoginUtilisateur + "' AND mdp_Utilisateur = '" + unUtilisateur.MdpUtilisateur + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows[0][0].ToString() == "1" )
            {
                return statutConnexion = true;
            }
            else
            {
                return statutConnexion = false;
            }    
        }
        */
    }
}

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


        public static Utilisateur getUserPass(Utilisateur unUtilisateur)
        {
            string req = "select login_Utilisateur, mdp_Utilisateur  from mrbs where login_Utilisateur ='" + unUtilisateur.LoginUtilisateur + "' and mdp_Utilisateur = '" + unUtilisateur.MdpUtilisateur + "'";
            DAOFactory db = new DAOFactory();
            db.connecter();



            SqlDataReader reader = db.excecSQLRead(req);
            reader.Read();
            Utilisateur US = new Utilisateur(reader[0].ToString(), reader[1].ToString());



            return US;
        }
    }
}

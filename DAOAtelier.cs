using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssisesSportLorrain
{
    class DAOAtelier
    {
        // Retourne une collection de tous les Ateliers lus en BDD 
        public static List<Atelier> getAllAteliers()
        {
            List<Atelier> lesAteliers = new List<Atelier>();
            string req = "select * from m2l_atelier";
            DAOFactory db = new DAOFactory();
            db.connecter();

            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                Atelier at = new Atelier(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()) );
                //Atelier at = new Atelier(int.Parse(reader[0].ToString()), reader[1].ToString());
                lesAteliers.Add(at);
            }

            return lesAteliers;

        }



        // Créer dans la BDD l'objet Atelier passé en paramètre
        public static void creerAtelier(Atelier unAtelier)
        {
            string requete = "insert into m2l_atelier values('" + unAtelier.IdAtelier + "','" + unAtelier.LibelleAtelier + "')";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }



        // Créer dans la BDD l'objet Atelier passé en paramètre
        public static void creerAtelier3(Atelier unAtelier)
        {
            string requete = "insert into m2l_atelier values('" + unAtelier.IdAtelier + "','" + unAtelier.LibelleAtelier + "','" + unAtelier.ParticipantAtelier + "')";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }





        // Modifie dans la BDD le solde de l'objet Atelier passé en paramètre
        public static void modifierAtelier(Atelier unAtelier)
        {
            string requete = "update m2l_atelier set libelle = '" + unAtelier.LibelleAtelier + "', participant = '" + unAtelier.ParticipantAtelier + "' where id_atelier='" + unAtelier.IdAtelier + "'"; 
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }




        // Créer dans la BDD l'objet Atelier passé en paramètre
        public static void supprimerAtelier(Atelier unAtelier)
        {
            string requete = "delete from m2l_atelier where id_atelier = '" + unAtelier.IdAtelier + "'";
            string requete2 = "delete from theme where id_atelier = '" + unAtelier.IdAtelier + "'";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete2);
            db.execSQLWrite(requete);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssisesSportLorrain
{
    class Utilisateur
    {
        private string loginUtilisateur;
        private string mdpUtilisateur;

       

        public string LoginUtilisateur
        {
            get { return loginUtilisateur; }
            set { loginUtilisateur = value; }
        }

        public string MdpUtilisateur
        {
            get { return mdpUtilisateur; }
            set { mdpUtilisateur = value; }
        }

        

        public Utilisateur(string loginUtilisateur, string mdpUtilisateur)
        {
            this.loginUtilisateur = loginUtilisateur;
            this.mdpUtilisateur = mdpUtilisateur;
        }


        public static List<Utilisateur> listeUtilisateurs()
        {
            return DAOUtilisateur.getAllUtilisateurs();
        }



        public static Utilisateur lUtilisateur()
        {
            return DAOUtilisateur.getlUtilisateur();
        }


        public Utilisateur checkUser()
        {
            return DAOUtilisateur.getUserPass(this);
        }
    }
}

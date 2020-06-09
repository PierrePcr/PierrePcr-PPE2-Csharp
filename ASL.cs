using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssisesSportLorrain
{
    public partial class ASL : Form
    {
        public ASL()
        {
            InitializeComponent();
            tabControl.TabPages.Remove(tabAteliers);
            tabControl.TabPages.Remove(tabThemes);
            btnDeconnexion.Hide();
            labelConnexionOk.Hide();

        }

        #region Onglet Accueil
        // Onglet ACCUEIL
        //====================================================================
        private void tabAccueil_Enter(object sender, EventArgs e)
        {
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            try
            {
                Utilisateur Utilisateur1;
                Utilisateur1 = new Utilisateur(txbLogin.Text, txbMdp.Text);
                Utilisateur Utilisateur2;
                Utilisateur2 = Utilisateur1.checkUser();



                if (Utilisateur1.LoginUtilisateur == Utilisateur2.LoginUtilisateur && Utilisateur1.MdpUtilisateur == Utilisateur2.MdpUtilisateur)
                {
                    labelConnexionOk.Show();
                    txbLogin.Hide();
                    txbMdp.Hide();
                    lblidAccueil.Hide();
                    lblmdpAccueil.Hide();
                    btnConnect.Hide();

                    tabControl.TabPages.Add(tabAteliers);
                    tabControl.TabPages.Add(tabThemes);

                    btnDeconnexion.Show();
                }

            } 
            catch
            {
                if (txbLogin.Text.Length == 0 && txbMdp.Text.Length == 0)
                {
                    MessageBox.Show("Erreur : Veuillez saisir quelque chose avant de cliquer sur ce bouton");
                }
                else
                {
                    MessageBox.Show("Erreur : E-mail ou Mot de passe incorrect");
                }
            }
        
        }


        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            txbLogin.Show();
            txbMdp.Show();
            lblidAccueil.Show();
            lblmdpAccueil.Show();
            btnConnect.Show();

            tabControl.TabPages.Remove(tabAteliers);
            tabControl.TabPages.Remove(tabThemes);

            btnDeconnexion.Hide();
            labelConnexionOk.Hide();
        }



        #endregion




        #region Onglet Atelier
        // Onglet ATELIER
        //====================================================================
        private void tabAteliers_Enter(object sender, EventArgs e)
        {
            //REMPLISSAGE DU DGV ATELIER
            remplirListeAtelier();

            //REMPLISSAGE COMBOBOX MODIFIER ATELIER
            remplirCbxModifierAtelier();

            //REMPLISSAGE COMBOBOX SUPPRIMER ATELIER
            remplirCbxSupprimerAtelier();

            //CACHER TOUS LES MESSAGES
            lblCreerAtelierOK.Hide();
            lblModifierAtelierOK.Hide();
            lblSupprimerAtelierOK.Hide();
        }





            //LES FONCTIONS ET PROCEDURES ONGLET : ATELIER

        //REMPLISSAGE DGV ATELIER
        private void remplirListeAtelier()
        {
            try
            {
                dgvAteliers.Rows.Clear();
                foreach (Atelier unAtelier in Atelier.listeAteliers())
                {
                    dgvAteliers.Rows.Add(unAtelier.IdAtelier, unAtelier.LibelleAtelier, unAtelier.ParticipantAtelier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //REMPLISSAGE COMBOBOX MODIFIER ATELIER
        private void remplirCbxModifierAtelier()
        {
            try
            {
                cbxModifierAteliers.Items.Clear();
                foreach (Atelier unAtelier in Atelier.listeAteliers())
                {
                    cbxModifierAteliers.Items.Add(unAtelier.IdAtelier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //REMPLISSAGE COMBOBOX SUPPRIMER ATELIER
        private void remplirCbxSupprimerAtelier()
        {
            try
            {
                cbxSupprimerAteliers.Items.Clear();
                foreach (Atelier unAtelier in Atelier.listeAteliers())
                {
                    cbxSupprimerAteliers.Items.Add(unAtelier.IdAtelier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }



        private void btnCreerAtelier_Click(object sender, EventArgs e)
        {
            if (txbCréerAtelier1.Text.Length == 0 || txbCréerAtelier2.Text.Length == 0 || txbCréerAtelier3.Text.Length == 0)
            {
                MessageBox.Show("Erreur : Saisis tous les champs !");
                return;
            }
            else
            {
                try
                {
                    Atelier unNewAtelier;
                    unNewAtelier = new Atelier(int.Parse(txbCréerAtelier1.Text), txbCréerAtelier2.Text, int.Parse(txbCréerAtelier3.Text));
                    unNewAtelier.ajouterAtelier3();

      
                    //Vider les tbx.text
                    txbCréerAtelier1.Clear();
                    txbCréerAtelier2.Clear();
                    txbCréerAtelier3.Clear();


                    //Afficher MSG VALIDER
                    lblCreerAtelierOK.Show();

                    //Refresh toutes les données de la page atelier
                    refreshAllAtelier();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbxModifierAteliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = cbxModifierAteliers.SelectedIndex;
                Atelier unAtelier;
                unAtelier = Atelier.listeAteliers().ElementAt(i);

                txbModifierAtelier2.Text = unAtelier.LibelleAtelier;
                txbModifierAtelier3.Text = unAtelier.ParticipantAtelier.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
    
        }


        private void btnModifierAtelier_Click(object sender, EventArgs e)
        {
            if (txbModifierAtelier2.Text.Length != 0 && txbModifierAtelier3.Text.Length != 0)
            {
                try
                {
                    //on récupère l'index de la sélection dans la combobox
                    int i = cbxModifierAteliers.SelectedIndex;
                    Atelier unAtelier;
                    unAtelier = Atelier.listeAteliers().ElementAt(i);

                    unAtelier.modifierAtelier(cbxModifierAteliers.SelectedIndex, txbModifierAtelier2.Text, int.Parse(txbModifierAtelier3.Text));

                    //Vider les textbox apres l'ajout
                    txbModifierAtelier2.Clear();
                    txbModifierAtelier3.Clear();
                    lblModifierAtelierOK.Show();
                    cbxModifierAteliers.SelectedIndex = -1;

                    //Refresh toutes les données de la page atelier
                    refreshAllAtelier();
                }

                catch
                {
                    MessageBox.Show("Erreur : La syntaxe est incorrecte");
                }
                
                    
                
            }
            else
            {
                MessageBox.Show("Erreur : Selectionne un Atelier !");
                return;
            }
        }




        private void btnSupprimerAtelier_Click(object sender, EventArgs e)
        {
            if (this.cbxSupprimerAteliers.SelectedIndex == -1)
            {
                MessageBox.Show("Erreur : Selectionne un Atelier !");
                return;
            }
            else
            {
                try
                {
                    // on récupère l'index de la sélection dans la combobox
                    int i = cbxSupprimerAteliers.SelectedIndex;

                    Atelier unAtelier;
                    unAtelier = Atelier.listeAteliers().ElementAt(i);
                    unAtelier.supprimerAtelier();

                    lblSupprimerAtelierOK.Show();
                    cbxSupprimerAteliers.SelectedIndex = -1;

                    //Refresh toutes les données de la page atelier
                    refreshAllAtelier();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        //BOUTON TOUT ANNULER ATELIER
        private void btnAnnulerAtelier_Click(object sender, EventArgs e)
        {
            try
            {
                txbCréerAtelier1.Clear();
                txbCréerAtelier2.Clear();
                txbCréerAtelier3.Clear();
                txbModifierAtelier2.Clear();
                txbModifierAtelier3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void refreshAllAtelier()
        {
            try
            {
                //REMPLISSAGE DGV ATELIER
                remplirListeAtelier();

                //REMPLISSAGE COMBOBOX MODIFIER ATELIER
                remplirCbxModifierAtelier();

                //REMPLISSAGE COMBOBOX SUPPRIMER ATELIER
                remplirCbxSupprimerAtelier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    




        }

        private void btnRefreshAtelier_Click(object sender, EventArgs e)
        {
            refreshAllAtelier();
            try
            {
                //CACHER TOUS LES MESSAGES
                lblCreerAtelierOK.Hide();
                lblModifierAtelierOK.Hide();
                lblSupprimerAtelierOK.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        #endregion



        #region Onglet Thème
        // Onglet THEME
        //====================================================================
        private void tabThemes_Enter(object sender, EventArgs e)
        {
            //REMPLISSAGE DU DGV THEME
            remplirDgvTheme();

            //REMPLISSAGE COMBOBOX MODIFIER THEME
            remplirCbxModifierTheme();

            //REMPLISSAGE COMBOBOX SUPPRIMER THEME
            remplirCbxSupprimerTheme();

            //CACHER MESSAGES ERREURS
            lblCreerThemeOK.Hide();
            lblModifierThemeOK.Hide();
            lblSupprimerThemeOK.Hide();
        }





            //LES FONCTIONS ET PROCEDURES ONGLET : THEME
        //REMPLISSAGE DU DGV THEME
        private void remplirDgvTheme()
        {
            try
            {
                dgvThemes.Rows.Clear();
                foreach (Theme unTheme in Theme.listeThemes())
                {
                    //dgvThemes.Rows.Add(unTheme.IdTheme, unTheme.NomTheme);
                    dgvThemes.Rows.Add(unTheme.IdTheme, unTheme.NomTheme, unTheme.IdAtelier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //REMPLISSAGE COMBOBOX MODIFIER THEME
        private void remplirCbxModifierTheme()
        {
            try
            {
                cbxModifierTheme.Items.Clear();
                foreach (Theme unTheme in Theme.listeThemes())
                {
                    cbxModifierTheme.Items.Add(unTheme.IdTheme);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //REMPLISSAGE COMBOBOX SUPPRIMER THEME
        private void remplirCbxSupprimerTheme()
        {
            try
            {
                cbxSupprimerTheme.Items.Clear();
                foreach (Theme unTheme in Theme.listeThemes())
                {
                    cbxSupprimerTheme.Items.Add(unTheme.IdTheme);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCreerTheme_Click(object sender, EventArgs e)
        {
            if (txbCréerTheme1.Text.Length == 0 || txbCréerTheme2.Text.Length == 0 || txbCréerTheme3.Text.Length == 0)
            {
                MessageBox.Show("Erreur : Selectionne un Thème !");
                return;

            }
            else
            {
                try
                {
                    Theme unNewTheme;
                    unNewTheme = new Theme(int.Parse(txbCréerTheme1.Text), txbCréerTheme2.Text, int.Parse(txbCréerTheme3.Text));
                    unNewTheme.ajouterTheme();

                    //Vider les tbx.text
                    txbCréerTheme1.Clear();
                    txbCréerTheme2.Clear();
                    txbCréerTheme3.Clear();


                    //AFFICHER MSG VALIDER
                    lblCreerThemeOK.Show();

                    //RAFRAICHIR DGV
                    refreshAllTheme();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                
            }

        }
        private void cbxModifierTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = cbxModifierTheme.SelectedIndex;
                Theme unTheme;
                unTheme = Theme.listeThemes().ElementAt(i);

                txbModifierTheme2.Text = unTheme.NomTheme;
                txbModifierTheme3.Text = unTheme.IdAtelier.ToString();
                cbxModifierTheme.SelectedIndex = -1;
                cbxModifierTheme.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnModifierTheme_Click(object sender, EventArgs e)
        {

            if (txbModifierTheme2.Text.Length == 0 || txbModifierTheme3.Text.Length == 0)
            {
                MessageBox.Show("Erreur : Un des champs est vide !");
                return;
            }
            else
            {
                try
                {
                    // on récupère l'index de la sélection dans la combobox
                    int i = cbxModifierTheme.SelectedIndex;
                    Theme unTheme;
                    unTheme = Theme.listeThemes().ElementAt(i);
                    unTheme.modifierTheme(cbxModifierTheme.SelectedIndex, txbModifierTheme2.Text, int.Parse(txbModifierTheme3.Text));

                    
                    //recuperer les tbx.text
                    txbModifierTheme2.Clear();
                    txbModifierTheme3.Clear();

                    lblModifierThemeOK.Show();

                    //RAFRAICHIR DGV
                    refreshAllTheme();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur : syntaxe est incorrecte");
                }
            }
        }

        private void btnSupprimerTheme_Click(object sender, EventArgs e)
        {

            if (this.cbxSupprimerTheme.SelectedIndex == -1)
            {
                MessageBox.Show("Erreur : Selectionne un Thème !");
                return;
            }
            else
            {

                try
                {
                    // on récupère l'index de la sélection dans la combobox
                    int i = cbxSupprimerTheme.SelectedIndex;

                    Theme unTheme;
                    unTheme = Theme.listeThemes().ElementAt(i);
                    unTheme.supprimerTheme();

                    lblSupprimerThemeOK.Show();
                    cbxSupprimerTheme.SelectedIndex = -1;

                    //RAFRAICHIR DGV
                    refreshAllTheme();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //BOUTON TOUT ANNULER THEME
        private void btnAnnulerTheme_Click(object sender, EventArgs e)
        {
            try
            {
                txbCréerTheme1.Clear();
                txbCréerTheme2.Clear();
                txbCréerTheme3.Clear();
                txbModifierTheme2.Clear();
                txbModifierTheme3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }


        public void refreshAllTheme()
        {
            //REMPLISSAGE DGV ATELIER
            remplirDgvTheme();

            //REMPLISSAGE COMBOBOX MODIFIER THEME
            remplirCbxModifierTheme();

            //REMPLISSAGE COMBOBOX SUPPRIMER THEME
            remplirCbxSupprimerTheme();
        }


        private void btnRefreshTheme_Click_1(object sender, EventArgs e)
        {
            //RAFRAICHIR DGV
            refreshAllTheme();
        }
        #endregion






        #region Fonction innutiles

        private void dgvAteliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThemes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvAteliers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txbCréerTheme1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void cbxSupprimerTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void dgvThemes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }



        #endregion

        private void tabAccueil_Click(object sender, EventArgs e)
        {

        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;

namespace Aloge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            remplirBDD();
    }

       public class Patient
        {
            public int ID_ { get; set; }
            public string Nom_ { get; set; }
            public string Prenom_ { get; set; }
            public string Adresse { get; set; }
            public string Telephone { get; set; }
            public string Info { get; set; }
        }


        public class RDV
        {
            public int ID { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Adresse { get; set; }
            public string Date { get; set; }
            public string Heure { get; set; }
            public string Objet { get; set; }

        }

        public List<RDV> LS_R = new List<RDV>();
        public List<Patient> LS_P = new List<Patient>();
        int count = 0;
        int countrdv = 0;
        
        public void remplirBDD()
        {
            //les patients
            var random = new Random();
            var nom = new List<string> { "KHEZZANE", "BENDJABALLAL", "AITALI", "TABIN" };
            int index = random.Next(nom.Count);
            var random2 = new Random();
            var prenom = new List<string> { "DALLEL", "OUSSAMA", "AMIRA", "KAMEL" };
            int index1 = random.Next(prenom.Count); 
            var random3 = new Random();
            var info = new List<string> { "DIABETE", "BLOOD PRESSURE", "INTOXICATION", "INCoNNU" , "corona diagnostic" };
            int index2 = random.Next(nom.Count);
            var random4 = new Random();
            var addr = new List<string> { "ALGER", "BABELOUED", "LEBIAR", "ROUIBA" };
            int index3 = random.Next(prenom.Count);

            for (int i = 0;i<10;i++) {
                count++;
                LS_P.Add(new Patient()
                {
                    ID_ = count,
                    Nom_ = nom[index],
                    Prenom_ = prenom[index1],
                    Adresse = addr[index3],
                    Telephone = "0567894532",
                    Info = info[index2]
                });
                index = random.Next(nom.Count);
                index1 = random.Next(prenom.Count);
                index2 = random.Next(info.Count);
                index3 = random.Next(addr.Count);

            }
            //les RDV
                //retirer la date courrante

                DateTime now = DateTime.Now;
                string date = now.GetDateTimeFormats('d')[0];
                string time = now.GetDateTimeFormats('t')[0];
            for (int i = 0; i < 5; i++)
            {
                foreach (Patient a in LS_P)
                {
                    countrdv++;
                    LS_R.Add(new RDV()
                    {
                        ID = countrdv,
                        Nom = a.Nom_,
                        Prenom = a.Prenom_,
                        Adresse = a.Adresse,
                        Date = date,
                        Heure = time,
                        Objet = "cest pas tres urgent"
                    });


                }
            }
            }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Lister par la date courant
                //retirer la date courrante
                DateTime now = DateTime.Now;
                string date = now.GetDateTimeFormats('d')[0];
               
            data.Items.Clear();
             date1.Text = date;
            foreach (RDV a in LS_R)
            {
                if (a.Date.Equals(date) == true) data.Items.Add(a);
            }
        }

        private void CreeB_Click(object sender, RoutedEventArgs e)
        {       //le cas normal d'ajout dun RDV
            if (String.IsNullOrEmpty(id.Text))
            {
                DateTime now = DateTime.Now;
                string date = now.GetDateTimeFormats('d')[0];
                //creation d'un RDV
                string n = a1.Text;
                string p = a2.Text;
                int trouve = 0;
                foreach (Patient a in LS_P)
                {
                    if (a.Nom_.Equals(n) == true && a.Prenom_.Equals(p) == true)
                    {
                        trouve = 1;
                        countrdv++;
                        LS_R.Add(new RDV()
                        {
                            ID = countrdv,
                            Nom = a.Nom_,
                            Prenom = a.Prenom_,
                            Adresse = a.Adresse,
                            Date = a6.Text,
                            Heure = a7.Text,
                            Objet = a8.Text
                        });

                    }
                }
                if (trouve == 0) MessageBox.Show("Patient non trouvé, il faut Ajouter le patient d'abord.");


            }
            //le cas de modification d'un  RDV
            else
            {
                LS_R.Add(new RDV()
                {
                    ID = Convert.ToInt32(id.Text),
                    Nom = a1.Text,
                    Prenom = a2.Text,
                    Adresse = "ALGER",
                    Date = a6.Text,
                    Heure = a7.Text,
                    Objet = a8.Text
                });
                MessageBox.Show("Modification avec succes verifier au niveau des RDV");
            }
}

        private void AjouterPat_Click(object sender, RoutedEventArgs e)
        {
            //Ajouter_patient
            count++;
            LS_P.Add(new Patient()
            {
                ID_ = count,
                Nom_ = a16.Text,
                Prenom_ = a9.Text,
                Adresse = a10.Text,
                Telephone = a11.Text,
                Info = a12.Text
            });
        }

        private void ConsultBtn_Click(object sender, RoutedEventArgs e)
        {
            //Consulter les RDV d'un patient
            string n = no1.Text;
            string p = co1.Text;
            data2.Items.Clear();
            foreach (RDV a in LS_R)
            {
                if (a.Nom.Equals(n) == true && a.Prenom.Equals(p) == true) data2.Items.Add(a);
            }

        }

        private void ListerBtn_Click(object sender, RoutedEventArgs e)
        {
            //Lister les patiets
            data3.Items.Clear();
            foreach (Patient a in LS_P)
            {
               data3.Items.Add(a);
            }
        }


        //Examples:


        private void Exempl_Click(object sender, RoutedEventArgs e)
        {
            LS_P.Add(new Patient()
            {
                ID_ = 1,
                Nom_ = "ouss",
                Prenom_ = "ben",
                Adresse = "setif",
                Telephone = "0555",
                Info = "///"
            });
            LS_P.Add(new Patient()
            {
                ID_ = 2,
                Nom_ = "amani",
                Prenom_ = "benh",
                Adresse = "constantine",
                Telephone = "0333",
                Info = "///"
            });
            LS_P.Add(new Patient()
            {
                ID_ = 3,
                Nom_ = "Hanin",
                Prenom_ = "benhh",
                Adresse = "constantine",
                Telephone = "0554",
                Info = "///"
            });
            LS_P.Add(new Patient()
            {
                ID_ = 4,
                Nom_ = "Djoud",
                Prenom_ = "beng",
                Adresse = "setif",
                Telephone = "0553",
                Info = "///"
            });
            count = 5;
        }


        //gestion des interfaces
        private void No_GotFocus(object sender, RoutedEventArgs e)
        {
            date1.Text = "";
        }      
        private void A1_GotFocus(object sender, RoutedEventArgs e)
        {
            a1.Text = "";
        }
        private void A2_GotFocus(object sender, RoutedEventArgs e)
        {
            a2.Text = "";
        }
        private void A6_GotFocus(object sender, RoutedEventArgs e)
        {
            a6.Text = "";
        }
        private void A7_GotFocus(object sender, RoutedEventArgs e)
        {
            a7.Text = "";
        }
        private void A8_GotFocus(object sender, RoutedEventArgs e)
        {
            a8.Text = "";
        }
        private void A10_GotFocus(object sender, RoutedEventArgs e)
        {
            a10.Text = "";
        }
        private void A11_GotFocus(object sender, RoutedEventArgs e)
        {
            a11.Text = "";
        }
        private void A12_GotFocus(object sender, RoutedEventArgs e)
        {
            a12.Text = "";
        }
        private void A16_GotFocus(object sender, RoutedEventArgs e)
        {
            a16.Text = "";
        }
        private void Co1_GotFocus(object sender, RoutedEventArgs e)
        {
            co1.Text = "";
        }
        private void No1_GotFocus(object sender, RoutedEventArgs e)
        {
            no1.Text = "";
        }
        private void Listpat_Click(object sender, RoutedEventArgs e)
        {
            ListeP.Visibility = Visibility.Visible;
            cree.Visibility = Visibility.Collapsed;
            Conslter.Visibility = Visibility.Collapsed;
            ajouterP.Visibility = Visibility.Collapsed;
        }
        private void Imp_Click(object sender, RoutedEventArgs e)
        {
            ajouterP.Visibility = Visibility.Visible;
            Conslter.Visibility = Visibility.Collapsed;
            cree.Visibility = Visibility.Collapsed;
            ListeP.Visibility = Visibility.Collapsed;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cree.Visibility = Visibility.Collapsed;
            ajouterP.Visibility = Visibility.Collapsed;
            Conslter.Visibility = Visibility.Collapsed;
            ListeP.Visibility = Visibility.Collapsed;

        }
        private void ConsulterB_Click_1(object sender, RoutedEventArgs e)
        {
            Conslter.Visibility = Visibility.Visible;
            cree.Visibility = Visibility.Collapsed;
            ajouterP.Visibility = Visibility.Collapsed;
            ListeP.Visibility = Visibility.Collapsed;

        }
        private void Bcree_Click(object sender, RoutedEventArgs e)
        {
            cree.Visibility = Visibility.Visible;
            Conslter.Visibility = Visibility.Collapsed;
            ajouterP.Visibility = Visibility.Collapsed;
            ListeP.Visibility = Visibility.Collapsed;
        }
        private void A9_GotFocus(object sender, RoutedEventArgs e)
        {
            a9.Text = "";
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (data.SelectedItems.Count > 0)
            {
                for (int i = 0; i < data.SelectedItems.Count; i++)
                {
                    RDV selectedFile = (RDV)data.SelectedItems[i];
                    int str = Convert.ToInt32(selectedFile.ID);
                    MessageBox.Show("Confirmer la Suppression de l'element avec ID =  "+ str);
                    var item = LS_R.Find(x => x.ID == str);
                    LS_R.Remove(item);
                   
                   


                }
                
            }

        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {

            if (data.SelectedItems.Count > 0)
            {
                for (int i = 0; i < data.SelectedItems.Count; i++)
                {    //suppression
                    RDV selectedFile = (RDV)data.SelectedItems[i];
                    int str = Convert.ToInt32(selectedFile.ID);
                    MessageBox.Show("veuillez modifier la date et l'heure seulement ");
                    var item = LS_R.Find(x => x.ID == str);
                    LS_R.Remove(item);

                    //nouvelle creation avec modification
                    cree.Visibility = Visibility.Visible;
                    Conslter.Visibility = Visibility.Collapsed;
                    ajouterP.Visibility = Visibility.Collapsed;
                    ListeP.Visibility = Visibility.Collapsed;

                    a1.Text = Convert.ToString(selectedFile.Nom);
                    a6.Text= Convert.ToString(selectedFile.Date);
                    a2.Text = Convert.ToString(selectedFile.Prenom);

                    a7.Text = Convert.ToString(selectedFile.Heure);
                    a8.Text = Convert.ToString(selectedFile.Objet);
                    id.Text = Convert.ToString(selectedFile.ID);


                }

            }

        }

        private void Imprimer_Click(object sender, RoutedEventArgs e)

        {
            if (data.SelectedItems.Count > 0)
            {
                for (int i = 0; i < data.SelectedItems.Count; i++)
                {
                    RDV selectedFile = (RDV)data.SelectedItems[i];
                    int str = Convert.ToInt32(selectedFile.ID);
                    String fichier = "rdv.txt";
                    String contenu = "/n l'id du RDV"+str+ " /n Nom patient du RDV" + selectedFile.Nom + " /nprenom patient du RDV" + selectedFile.Prenom  + " /n date du RDV" + selectedFile.Date+ " /n heure du RDV" + selectedFile.Heure+ " /n l'objet du RDV" + selectedFile.Objet;
                    File.WriteAllText(fichier,contenu);
                    
                    MessageBox.Show("impression dans le fichier texte rdv.txt qui se trouvra dans le dossier bin avec sucess" );
                    




                }

            }

        }
    }
}


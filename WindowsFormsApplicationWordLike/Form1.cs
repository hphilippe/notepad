using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationWordLike
{
    
    public partial class Form1 : Form
    {
        string path = "";
        bool cplus = false;

        public Form1()
        {
            InitializeComponent();
        }

        /*________________________________________________________________________________________________________________*/
        /*___________________________________Nouveau fichier_____________________________________________________________________________*/


        private void nouveauFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult retour = MessageBox.Show("Ce document n'a pas été enregistré  voulez vous l'enregistrer ?", "Nouveau", MessageBoxButtons.YesNoCancel);
            if (retour == DialogResult.Cancel)
            {

            }
            else
            {
                if (retour == DialogResult.Yes)
                {

                    SaveFileDialog formSaveFile = new SaveFileDialog();

                    formSaveFile.FileName = "text.rtf";
                    formSaveFile.AddExtension = true; // Ajoute une extension si l'utilisateur n'en met pas
                    formSaveFile.DefaultExt = "*.rtf"; //extension par défaut
                    formSaveFile.Filter = "RTF Files (*.rtf)|*.rtf| Text Files (*.txt)|*.txt|  All Files (*.*)|*.*"; // Permet de sauver en txt ou rtf
                    //En affichant seulement les extensions concernées

                    if (formSaveFile.ShowDialog() == DialogResult.OK && formSaveFile.FileName.Length > 0)
                    {
                        richTextBox1.SaveFile(formSaveFile.FileName);
                    }
                    richTextBox1.Text = "";

                }
                else
                {
                    richTextBox1.Text = "";
                }
            }

            this.Text = "ShiShiSon - Nouveau Fichier";
        }

        /*________________________________________________________________________________________________________________*/
        /*___________________________________ouvrir un fichier_____________________________________________________________________________*/

        private void ouvrirUnFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog formOpenFile = new OpenFileDialog(); // déclare existence de la fenetre formopenfile

            formOpenFile.InitialDirectory = "c:\\"; // lien du parcour
            formOpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // format utilise txt ou autre comme rtf
            formOpenFile.FilterIndex = 2; // prise des extensions txt et rtf seulement
            formOpenFile.RestoreDirectory = true; //Obtient ou définit une valeur indiquant si la boîte de dialogue restaure le répertoire actif avant la fermeture.

            if (formOpenFile.ShowDialog() == DialogResult.OK) // affichage de la fenêtre 
            {
                string nomFichier = formOpenFile.FileName.ToString();
                string inputExtension = "";
                string outputExtension = ""; // définie que ceci est une chaine de caractere de variable outputexnsion
                int i = 1;
                while (nomFichier[nomFichier.Length - i] != '.') //On récupère l'extension du fichier (à l'envers vu qu'on part de la fin)
                {
                    inputExtension += nomFichier[nomFichier.Length - i]; //On stocke l'extension du fichier dans un tableau (à l'envers, du coup, ça s'annule)
                    i++;
                }

                for (int j = inputExtension.Length - 1; j >= 0; j--)
                {
                    outputExtension += inputExtension[j]; // on reprend le tableau dans le bon ordre 
                }

                if (outputExtension == "rtf") // si fichier de type rtf
                {
                    richTextBox1.LoadFile(formOpenFile.FileName, RichTextBoxStreamType.RichText); //Spécifie les types de flux d'entrée et de sortie utilisés pour charger et enregistrer les données dans le contrôle RichTextBox. la ici de type rtf
                }
                if (outputExtension == "txt") // si fichier de type txt
                {
                    richTextBox1.LoadFile(formOpenFile.FileName, RichTextBoxStreamType.PlainText); // tout type 
                }


                this.Text = "ShiShiSon - " + formOpenFile.SafeFileName; // charge le fichier avec le nom de titre shishison suivie du nom du fichier

            }

        }

        /*________________________________________________________________________________________________________________*/
        /*_______________________________________________Enregistrer_________________________________________________________________*/

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog formSaveFile = new SaveFileDialog();

            formSaveFile.FileName = "myText.rtf";
            formSaveFile.AddExtension = true;  // Ajoute une extension si l'utilisateur n'en met pas
            formSaveFile.DefaultExt = "*.rtf";  //extension par défaut
            formSaveFile.Filter = "RTF Files (*.rtf)|*.rtf| Text Files (*.txt)|*.txt|  All Files (*.*)|*.*"; // Permet de sauver en txt ou rtf
            //En affichant seulement les extensions concernées

            if (formSaveFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(formSaveFile.FileName, RichTextBoxStreamType.PlainText);
            }
            richTextBox1.Clear();

        }

        /*________________________________________________________________________________________________________________*/
        /*________________________________________________________________________________________________________________*/


        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void annulerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rétablirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FontFamily[] fontfamily;
            System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection();
            fontfamily = ifc.Families;
            int cpt = fontfamily.Length;
            for (int j = 0; j < cpt; j++)
            {
                comboBoxPolice.Items.Add(fontfamily[j].Name);
                //comboBoxPolice.Font = fontfamily[j];
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void couperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // détection de la touche entrer
            {
                int curseur = richTextBox1.SelectionStart - 1; // le curseur revient en arrière d'une case
                richTextBox1.SelectedText = " "; // on ajoute le caractère "espace" 
                
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (cplus == true)  // On active le mode d'éditeur de texte C++ 
            
            {
                int curseurFin;
                int curseurDebut;
                int curseurUser;

                curseurFin = richTextBox1.SelectionStart;
                curseurDebut = curseurFin;
                curseurUser = curseurFin;

                while (curseurDebut > 0 && richTextBox1.Text[curseurDebut - 1] != ' ') // à partir de la fin du mot écrit, on décrémente le curseur début jusqu'a qu'il trouve un espace avant le mot.
                {
                    curseurDebut--;
                }

                while (curseurFin < (richTextBox1.Text.Length) && richTextBox1.Text[curseurFin] != ' ') // si on replace notre curseur fin dans le mot, le curseur fin va aller jusqu'au bout du mot.
                {
                    curseurFin++;
                }


                /* if (richTextBox1.Text.Contains(" "))
                 {
                     curseurEspace++;
                 }*/

                string word = richTextBox1.Text.Substring(curseurDebut, curseurFin - curseurDebut); // on selection le mot de la fin jusqu'au début du mot 

                if (word != "float" && word != "int" && word != "long" && word != "unsigned" && word != "short" && word != "char" && word != "const" && word != "if" && word != "while" && word != "for")
                {
                    richTextBox1.Select(curseurDebut, curseurFin - curseurDebut);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.Select(curseurFin, 0); // on replace notre curseur a la fin du mot pour pouvoir écrire les prochain mots
                    richTextBox1.SelectionColor = Color.Black;
                }
                else
                {
                    richTextBox1.Select(curseurDebut, curseurFin - curseurDebut); // on selection le mot de la fin jusqu'au début du mot 
                    richTextBox1.SelectionColor = Color.Blue; // on colorise tout le mot en bleu
                    richTextBox1.Select(curseurFin, 0); // on replace notre curseur a la fin du mot pour pouvoir écrire les prochain mots
                    richTextBox1.SelectionColor = Color.Black; // on remet la couleur noir de base
                }

                if (word != "{")
                {
                    /*richTextBox1.Select(curseurDebut, curseurFin - curseurDebut);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.Select(curseurFin, 0);
                    richTextBox1.SelectionColor = Color.Black;*/
                }
                else
                {
                    richTextBox1.Select(curseurDebut, curseurFin - curseurDebut);
                    // richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.Select(curseurFin, 0);
                    //richTextBox1.Text += Environment.NewLine;
                    // richTextBox1.SelectionColor = Color.Black;
                    //  AppendText(this.richTextBox1, Color.Red, "}" );
                    AppendText(this.richTextBox1, Color.Black, Environment.NewLine); // on saute une ligne après la 1er accolade
                    // richTextBox1.Text += " " + Environment.NewLine + Environment.NewLine +  " }";
                    AppendText(this.richTextBox1, Color.Black, Environment.NewLine + "}"); // on saute encore une ligne et pose une accolade fermante
                }

               /* if (word == "//")
                {

                }*/

                /* if (word == "//")
                 {
                     richTextBox1.Select(curseurDebut, curseurFin);
                     richTextBox1.SelectionColor = Color.Green;
                     richTextBox1.Select(curseurFin, 0);
                     richTextBox1.SelectionColor = Color.Green;

                     if (Control.ModifierKeys == Keys.Enter)
                     {
                         richTextBox1.Select(curseurDebut, curseurFin);
                         richTextBox1.SelectionColor = Color.Black;
                         richTextBox1.Select(curseurFin, 0);
                         richTextBox1.SelectionColor = Color.Black;
                     }
                 }

                 else
                 {
                
                 } */

                /*---------------------------------------------*/

                /*  if (word == "float")
                  {
                      Font propriFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.SizeInPoints, richTextBox1.SelectionFont.Style);
                      labelStyle.Text = richTextBox1.SelectionFont.Name;
                
                      // this.richTextBox1.SelectionFont.Name = "";
                      //AppendText(this.richTextBox1.SelectionFont.Name"AB\n\tCD");
                  } */

                /* if ((word == "float" || word == "int" || word == "long" && word == "unsigned" && word == "short" && word == "char" && word == "const" && word == "if" && word == "while" && word == "for") ||( word == "//"))
                 {
                     if (word == "float" || word == "int")
                     {
                         richTextBox1.Select(curseurDebut, curseurFin - curseurDebut);
                         richTextBox1.SelectionColor = Color.Blue;
                         richTextBox1.Select(curseurFin, 0);
                         richTextBox1.SelectionColor = Color.Black;
                     }
                     else
                     {
                         richTextBox1.Select(curseurDebut, curseurFin - curseurDebut);
                         richTextBox1.SelectionColor = Color.Black;
                         richTextBox1.Select(curseurFin, 0);
                         richTextBox1.SelectionColor = Color.Black;
                     }

                     if (word == "//")
                     {
                         richTextBox1.Select(curseurDebut, curseurFin - curseurDebut);
                         richTextBox1.SelectionColor = Color.Green;
                         richTextBox1.Select(curseurFin, 0);
                         richTextBox1.SelectionColor = Color.Green;
                     }
                 }*/

                richTextBox1.Select(curseurUser, 0);
            }
            else
            {

            }
        }

        private void copierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void collerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripContainer1_BottomToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Création d'une fenêtre de sélection de couleur.
            ColorDialog ChoixColor = new ColorDialog();

            ChoixColor.AllowFullOpen = true; //Pour autoriser l'utilisation des couleurs personnalisées


            //MyDialog.ShowHelp = true; Autorise l'activation de l'aide dans la fenêtre de choix des couleurs. À régler plus tard.


            ChoixColor.Color = richTextBox1.ForeColor; //On applique la couleur actuellement utilisée par la RichTextBox comme couleur par défaut.

            // On sauvegarde la couleur choisie par l'utilisateur quand celui-ci clique sur OK.
            if (ChoixColor.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = ChoixColor.Color; //On remplace la couleur du texte sélectionné par la nouvelle couleur choisie par l'utilisateur.
                //De plus, le texte qui suivra sera coloré suivant le choix de l'utilisateur.
                labelCouleur.ForeColor = ChoixColor.Color;
                //On indique la couleur utilisée lors de la saisie de texte à l'aide d'un petit rectangle de bon aloi.

                if (richTextBox1.SelectedText != "") //Si du texte est sélectionné, on va changer la couleur de celui-ci et de facto modifier le fichier.
                {
                    //En conséquence, si le fichier était marqué comme étant non modifié, il le devient...
                    this.Text = "* " + this.Text + " *"; //On rajoute deux petites étoiles toutes mignonnes.
                }
            }
            richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }*/

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
         /*   //string mystring = "long";
            int length = richTextBox1.TextLength;  // at end of text
            richTextBox1.AppendText(mystring);
            richTextBox1.SelectionStart = length;
            richTextBox1.SelectionLength = mystring.Length;
            richTextBox1.SelectionColor = Color.Red; */

        /*    if (mystring == "long") 
            {
                richTextBox1.SelectionColor = Color.Red; 
            }
           else
            {
                richTextBox1.SelectionColor = Color.Green;
            }
            richTextBox1.AppendText(mystring); */

           /* AppendText(this.richTextBox1, Color.Empty, "empty");
            AppendText(this.richTextBox1, Color.Red, "AB\n\tCD");
            AppendText(this.richTextBox1, Color.Blue, "blue"); */

            /*------------------------------------------------*/

            cplus = true; // on met a 1 la variable bool cplus qui activera le code de colorisation dans richtextbox1
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textCentre_Click(object sender, EventArgs e)
        {
            Font oldFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.SizeInPoints, richTextBox1.SelectionFont.Style); 
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;  // Set the alignment of the text that follows.
            richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
        }

        private void textGauche_Click(object sender, EventArgs e)
        {
            Font oldFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.SizeInPoints, richTextBox1.SelectionFont.Style);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
        }

        private void textDroite_Click(object sender, EventArgs e)
        {
            Font oldFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.SizeInPoints, richTextBox1.SelectionFont.Style);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxPolice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void Police_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxPolice_SelectionChangeCommitted(object sender, EventArgs e) // si l'utilisateur décide de changer définitivement la valeur (si taille = 10 elle passe a 12)
        {
            if (richTextBox1.SelectedText != "") // si je sélectionne un texte 
            {
                int debut = richTextBox1.SelectionStart; //position de début de la selection
                int longueur = richTextBox1.SelectionLength; //longueur de la selection
                int fin = debut + longueur; //position de fin de la selection
                string nomPolice = comboBoxPolice.SelectedItem.ToString(); // il récupere la police utilisée

                for (int i = debut; i < fin; i++)
                {
                    richTextBox1.SelectionFont = new Font(nomPolice,
                                                          richTextBox1.SelectionFont.SizeInPoints,
                                                          richTextBox1.SelectionFont.Style); // met la nouvelle police, recupère l'ancien style et taille
                }
                richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
            }
            else
            {
                richTextBox1.SelectionFont = new Font(comboBoxPolice.SelectedItem.ToString(),
                                                          richTextBox1.SelectionFont.SizeInPoints,
                                                          richTextBox1.SelectionFont.Style);
                richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
            }
        }

        private void comboBoxTaille_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTaille_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                int debut = richTextBox1.SelectionStart; //position de début de la selection
                int longueur = richTextBox1.SelectionLength; //longueur de la selection
                int fin = debut + longueur; //position de fin de la selection
                Int32 taille = Convert.ToInt32(comboBoxTaillePolice.SelectedItem); // convert string into int
                for (int i = debut; i < fin; i++)
                {
                    richTextBox1.Select(i, 1);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, taille,
                                                      richTextBox1.SelectionFont.Style); // récupère l'ancien nom police, met la nouvelle taille, recupère l'ancien style
                }
                richTextBox1.Select(debut, longueur);
                richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, Convert.ToInt32(comboBoxTaillePolice.SelectedItem),
                                                      richTextBox1.SelectionFont.Style);
            richTextBox1.Focus(); //On redonne le Focus à la RichTextBox pour continuer à écrire sans la resélctionner
        }

        private void buttonRecherche_Click(object sender, EventArgs e)
        {
            int c;
            if (richTextBox1.SelectedText == "")
            {
                c = 0;
            }
            else
            {
                c = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            }
            if (richTextBox1.Find(textBoxRecherche.Text, c, RichTextBoxFinds.None) == -1) //Si aucun résultat n'est retourné
            {
                richTextBox1.Select(0, 0); //On déselectionne tout
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                //System.Drawing.Font currentFont = richTextBox1.SelectionFont; // Représente la police à appliquer à la sélection de texte ou texte saisi après le point d'insertion.
                //System.Drawing.FontStyle newFontStyle; //variable a appliquer au texte selectionné, nouvelle forme 

                // drawing c'est pour du graphique, on va utiliser directement juste les numéros attribué au gras italic etc

                //On récupère toutes les informations de texte (police couleur gras etc ...) dans une variable de type Font
                Font baseFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.SizeInPoints, richTextBox1.SelectionFont.Style);

                int NumStyle = 0; // style = 0 équivaut a aucun style, c'est un style regular 

                if (richTextBox1.SelectionFont.Bold == true)
                {
                    // on fait rien car il est déja en regular de base
                }
                else
                {
                    //newFontStyle = FontStyle.Italic;
                    // newFontStyle = FontStyle.Italic;
                    // NumStyle += (int)FontStyle.Bold;
                    NumStyle += (int)FontStyle.Bold;  // opérateur += équivaut a faire x = x + y donc on ajoute les style
                }

                if (richTextBox1.SelectionFont.Italic == true)
                {
                    NumStyle += (int)FontStyle.Italic;
                }
                //On met à jour le Style
                richTextBox1.SelectionFont = new Font(baseFont.Name, baseFont.SizeInPoints, (FontStyle)NumStyle);

                // richTextBox1.SelectionFont = new Font(currentFont.FontFamily,currentFont.Size,newFontStyle);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionFont != null)
            {
                //System.Drawing.Font currentFont = richTextBox1.SelectionFont; // Représente la police à appliquer à la sélection de texte ou texte saisi après le point d'insertion.
                //System.Drawing.FontStyle newFontStyle; //variable a appliquer au texte selectionné, nouvelle forme 

                // drawing c'est pour du graphique, on va utiliser directement juste les numéros attribué au gras italic etc
                
                //On récupère toutes les informations de texte (police couleur gras etc ...) dans une variable de type Font
                Font baseFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.SizeInPoints, richTextBox1.SelectionFont.Style);

                int NumStyle = 0; // style = 0 équivaut a aucun style, c'est un style regular 

                if (richTextBox1.SelectionFont.Italic == true)
                {
                   // on fait rien car il est déja en regular de base
                }
                else
                {
                    //newFontStyle = FontStyle.Italic;
                   // newFontStyle = FontStyle.Italic;
                   // NumStyle += (int)FontStyle.Bold;
                    NumStyle += (int)FontStyle.Italic;  // opérateur += équivaut a faire x = x + y donc on ajoute les style
                }

                if (richTextBox1.SelectionFont.Bold == true)
                {
                    NumStyle += (int)FontStyle.Bold;
                }
                //On met à jour le Style
                richTextBox1.SelectionFont = new Font(baseFont.Name, baseFont.SizeInPoints, (FontStyle)NumStyle);

               // richTextBox1.SelectionFont = new Font(currentFont.FontFamily,currentFont.Size,newFontStyle);
            }

        }

        private void propriétéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int curseurFin;
            int curseurDebut;

            curseurFin = richTextBox1.SelectionStart;
            curseurDebut = curseurFin;

            while (curseurDebut > 0 && richTextBox1.Text[curseurDebut - 1] != ' ')
            {
                curseurDebut--;
            }

            string word = richTextBox1.Text.Substring(curseurDebut, curseurFin - curseurDebut);

           if (word == " ")
            {
                Font propriFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.SizeInPoints, richTextBox1.SelectionFont.Style);
                labelStyle.Text = richTextBox1.SelectionFont.Name;
                // this.richTextBox1.SelectionFont.Name = "";
               //AppendText(this.richTextBox1.SelectionFont.Name"AB\n\tCD");
            }
        }

        void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }

        private void cToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void envoyerParMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mail fenetreMail = new Mail();  // on met la forms mail dans une variable pour pouvoir l'utiliser
            if (fenetreMail.ShowDialog(this) != DialogResult.Cancel) // fait apparaitre forms mails
            {
                
              
            }
            else
            {
                //ouvre le fenetre de la boite mail par défaut
                try
                {
                    System.Diagnostics.Process.Start("mailto:" + fenetreMail.adresse + "?subject=" + fenetreMail.sujet + "&body=" + richTextBox1.Text); // on lance le programme par défaut et rentre les variables qu'on a récuperé dans le mail
                }
                catch
                {
                    MessageBox.Show("Pas de client mail pa1r défaut ");
                }
            }
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cplus = false; // on remet le code normalement
        }

        private void butonRecherche_Click(object sender, EventArgs e)
        {
            int c;
            if (richTextBox1.SelectedText == "")
            {
                c = 0; // remise a zéro du compteur
            }
            else
            {
                c = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            }
            if (richTextBox1.Find(textBoxRecherche.Text, c, RichTextBoxFinds.None) == -1) //Si aucun résultat n'est retourné
            {
                richTextBox1.Select(0, 0); //On déselectionne tout
            }
        }


    }
}

/*________________________________________________________________________________________________________________*/
/*________________________________________méthode de coloration automatique de message________________________________________________________________________*/

        /*public static class RichTextBoxExtensions*/
       /* public static class AppendTextTest 
        {
         /*   public static void AppendText(this RichTextBox box, string text, Color color)
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = color;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;
            }
       
        /----------------/

        string userid = "USER0001";
        string message = "Access denied";
        string box = new RichTextBox
                      {
                          Dock = DockStyle.Fill,
                          Font = new Font("Courier New", 10)
                      };

        box.AppendText("[" + DateTime.Now.ToShortTimeString() + "]", Color.Red);
        box.AppendText(" ");
        box.AppendText(userid, Color.Green);
        box.AppendText(": ");
        box.AppendText(message, Color.Blue);
        box.AppendText(Environment.NewLine);

        new Form {Controls = {box}}.ShowDialog();*/

    /*-----------------*/

/*     public static void AppendText(this RichTextBox box, string text, Color color, bool AddNewLine = false)
     {
         if (AddNewLine)
         {
             text += Environment.NewLine;
         }

         box.SelectionStart = box.TextLength;
         box.SelectionLength = 0;

         box.SelectionColor = color;
         box.AppendText(text);
         box.SelectionColor = box.ForeColor;
     }
 /*--------------------
  
   void AppendText(RichTextBox box, Color color, string text)
 {
     int start = box.TextLength;
     box.AppendText(text);
     int end = box.TextLength;
            
     // Textbox may transform chars, so (end-start) != text.Length
     box.Select(start, end - start);
     {
         box.SelectionColor = color;
         // could set box.SelectionBackColor, box.SelectionFont too.
     }
     box.SelectionLength = 0; // clear
 }
 
            AppendText(this.m_richTextBox1, Color.Empty, "empty");
            AppendText(this.m_richTextBox1, Color.Red, "AB\n\tCD");
            AppendText(this.m_richTextBox1, Color.Blue, "blue");

 }
}
}*/

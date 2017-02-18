using System;
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
    public partial class Mail : Form
    {
        public string adresse { get; set; } // variable global modifiable et récupérable dans toutes les forms
        public string sujet { get; set; }

        public Mail()
        {
            InitializeComponent();
        }

        private void Mail_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            adresse = textBoxAdresse.Text; // variable adresse prend le texte dans textboxadresse
            sujet = textBoxSujet.Text;
        }

        private void buttonCANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

namespace WindowsFormsApplicationWordLike
{
    partial class Mail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelAdresse = new System.Windows.Forms.Label();
            this.labelSujet = new System.Windows.Forms.Label();
            this.textBoxAdresse = new System.Windows.Forms.TextBox();
            this.textBoxSujet = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAdresse
            // 
            this.labelAdresse.AutoSize = true;
            this.labelAdresse.Location = new System.Drawing.Point(54, 63);
            this.labelAdresse.Name = "labelAdresse";
            this.labelAdresse.Size = new System.Drawing.Size(117, 13);
            this.labelAdresse.TabIndex = 0;
            this.labelAdresse.Text = "Adresse du destinataire";
            // 
            // labelSujet
            // 
            this.labelSujet.AutoSize = true;
            this.labelSujet.Location = new System.Drawing.Point(57, 106);
            this.labelSujet.Name = "labelSujet";
            this.labelSujet.Size = new System.Drawing.Size(31, 13);
            this.labelSujet.TabIndex = 1;
            this.labelSujet.Text = "Sujet";
            // 
            // textBoxAdresse
            // 
            this.textBoxAdresse.Location = new System.Drawing.Point(232, 63);
            this.textBoxAdresse.Name = "textBoxAdresse";
            this.textBoxAdresse.Size = new System.Drawing.Size(242, 20);
            this.textBoxAdresse.TabIndex = 2;
            // 
            // textBoxSujet
            // 
            this.textBoxSujet.Location = new System.Drawing.Point(232, 106);
            this.textBoxSujet.Name = "textBoxSujet";
            this.textBoxSujet.Size = new System.Drawing.Size(242, 20);
            this.textBoxSujet.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(170, 160);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(119, 43);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 229);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxSujet);
            this.Controls.Add(this.textBoxAdresse);
            this.Controls.Add(this.labelSujet);
            this.Controls.Add(this.labelAdresse);
            this.Name = "Mail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Envoyer un Mail";
            this.Load += new System.EventHandler(this.Mail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAdresse;
        private System.Windows.Forms.Label labelSujet;
        private System.Windows.Forms.TextBox textBoxAdresse;
        private System.Windows.Forms.TextBox textBoxSujet;
        private System.Windows.Forms.Button buttonOK;
    }
}
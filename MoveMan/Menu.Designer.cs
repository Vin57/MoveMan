namespace MoveMan
{
    partial class Menu
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
            this.bt_Play = new System.Windows.Forms.Button();
            this.bt_Tutoriel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_Play
            // 
            this.bt_Play.Location = new System.Drawing.Point(102, 59);
            this.bt_Play.Name = "bt_Play";
            this.bt_Play.Size = new System.Drawing.Size(75, 23);
            this.bt_Play.TabIndex = 0;
            this.bt_Play.Text = "Jouer !";
            this.bt_Play.UseVisualStyleBackColor = true;
            this.bt_Play.Click += new System.EventHandler(this.bt_Play_Click);
            // 
            // bt_Tutoriel
            // 
            this.bt_Tutoriel.Location = new System.Drawing.Point(102, 88);
            this.bt_Tutoriel.Name = "bt_Tutoriel";
            this.bt_Tutoriel.Size = new System.Drawing.Size(75, 23);
            this.bt_Tutoriel.TabIndex = 1;
            this.bt_Tutoriel.Text = "Tutoriel";
            this.bt_Tutoriel.UseVisualStyleBackColor = true;
            this.bt_Tutoriel.Click += new System.EventHandler(this.bt_Tutoriel_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MoveMan.Properties.Resources.Img_Tutoriel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.bt_Tutoriel);
            this.Controls.Add(this.bt_Play);
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Play;
        private System.Windows.Forms.Button bt_Tutoriel;
    }
}
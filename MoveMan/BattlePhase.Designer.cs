namespace MoveMan
{
    partial class BattlePhase
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PVdefenseur = new System.Windows.Forms.Label();
            this.PVattaquant = new System.Windows.Forms.Label();
            this.PAattaquant = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.PAdefenseur = new System.Windows.Forms.Label();
            this.PtsAttaqueAttaquant = new System.Windows.Forms.Label();
            this.PtsDefenseDefenseur = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "FIGHT ! ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "VS";
            // 
            // PVdefenseur
            // 
            this.PVdefenseur.AutoSize = true;
            this.PVdefenseur.Location = new System.Drawing.Point(244, 195);
            this.PVdefenseur.Name = "PVdefenseur";
            this.PVdefenseur.Size = new System.Drawing.Size(27, 13);
            this.PVdefenseur.TabIndex = 4;
            this.PVdefenseur.Text = "PV :";
            // 
            // PVattaquant
            // 
            this.PVattaquant.AutoSize = true;
            this.PVattaquant.Location = new System.Drawing.Point(12, 195);
            this.PVattaquant.Name = "PVattaquant";
            this.PVattaquant.Size = new System.Drawing.Size(27, 13);
            this.PVattaquant.TabIndex = 5;
            this.PVattaquant.Text = "PV :";
            // 
            // PAattaquant
            // 
            this.PAattaquant.AutoSize = true;
            this.PAattaquant.Location = new System.Drawing.Point(12, 208);
            this.PAattaquant.Name = "PAattaquant";
            this.PAattaquant.Size = new System.Drawing.Size(27, 13);
            this.PAattaquant.TabIndex = 6;
            this.PAattaquant.Text = "PA :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 21);
            this.button2.TabIndex = 7;
            this.button2.Text = "FUIR !";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PAdefenseur
            // 
            this.PAdefenseur.AutoSize = true;
            this.PAdefenseur.Location = new System.Drawing.Point(244, 208);
            this.PAdefenseur.Name = "PAdefenseur";
            this.PAdefenseur.Size = new System.Drawing.Size(27, 13);
            this.PAdefenseur.TabIndex = 8;
            this.PAdefenseur.Text = "PA :";
            // 
            // PtsAttaqueAttaquant
            // 
            this.PtsAttaqueAttaquant.AutoSize = true;
            this.PtsAttaqueAttaquant.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtsAttaqueAttaquant.ForeColor = System.Drawing.Color.Red;
            this.PtsAttaqueAttaquant.Location = new System.Drawing.Point(9, 221);
            this.PtsAttaqueAttaquant.Name = "PtsAttaqueAttaquant";
            this.PtsAttaqueAttaquant.Size = new System.Drawing.Size(132, 17);
            this.PtsAttaqueAttaquant.TabIndex = 9;
            this.PtsAttaqueAttaquant.Text = "Points d\'attaque :";
            // 
            // PtsDefenseDefenseur
            // 
            this.PtsDefenseDefenseur.AutoSize = true;
            this.PtsDefenseDefenseur.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtsDefenseDefenseur.ForeColor = System.Drawing.Color.Red;
            this.PtsDefenseDefenseur.Location = new System.Drawing.Point(220, 221);
            this.PtsDefenseDefenseur.Name = "PtsDefenseDefenseur";
            this.PtsDefenseDefenseur.Size = new System.Drawing.Size(138, 17);
            this.PtsDefenseDefenseur.TabIndex = 10;
            this.PtsDefenseDefenseur.Text = "Points de défense :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(153, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(244, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 150);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "text info";
            this.label2.Visible = false;
            // 
            // BattlePhase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 243);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.PtsDefenseDefenseur);
            this.Controls.Add(this.PtsAttaqueAttaquant);
            this.Controls.Add(this.PAdefenseur);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PAattaquant);
            this.Controls.Add(this.PVattaquant);
            this.Controls.Add(this.PVdefenseur);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "BattlePhase";
            this.Text = "BattlePhase";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label PVdefenseur;
        private System.Windows.Forms.Label PVattaquant;
        private System.Windows.Forms.Label PAattaquant;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label PAdefenseur;
        private System.Windows.Forms.Label PtsAttaqueAttaquant;
        private System.Windows.Forms.Label PtsDefenseDefenseur;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
    }
}
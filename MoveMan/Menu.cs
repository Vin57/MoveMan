using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMan
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void bt_Play_Click(object sender, EventArgs e)
        {
            JoueurLanceDe carte1 = new JoueurLanceDe();
            carte1.ShowDialog();
        }

        private void bt_Tutoriel_Click(object sender, EventArgs e)
        {
            Tutoriel tuto = new Tutoriel();
            tuto.ShowDialog();
        }
    }
}

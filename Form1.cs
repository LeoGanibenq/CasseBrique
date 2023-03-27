using System;
using System.Windows.Forms;

namespace CasseBriques {
	public partial class CB : Form {

		public CB() {
			InitializeComponent();
            this.Icon = new System.Drawing.Icon("C:/Users/GANIBENQ/source/repos/CasseBrique/icon.ico");
		}

		private void nouveauToolStripMenuItem_Click(object sender, EventArgs e) {
			int level = 1;
			EspaceJeu.initialiseNiveau(level, "lvl");
			this.Text = "CassesBriques - Lvl:"+level;
		}

		private void quitterToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

        private void modeInfinityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int level = 1;
            EspaceJeu.initialiseNiveau(level, "inf");
            this.Text = "CassesBriques - Infinity: " + level;
        }

        public void setTitle(string title)
        {
			this.Text = title;
        }

        private void CB_Load(object sender, EventArgs e)
        {

        }

        private void EspaceJeu_MouseMove(object sender, MouseEventArgs e)
        {
            EspaceJeu.EspaceJeu_MouseMove(sender, e);
        }

        private void EspaceJeu_MouseClick(object sender, MouseEventArgs e)
        {
            EspaceJeu.EspaceJeu_MouseClick(sender, e);
        }
    }
}

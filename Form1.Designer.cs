namespace CasseBriques {
	partial class CB {
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CB));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeInfinityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.publierRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pseudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EspaceJeu = new CasseBriques.Jeu();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jeuToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // jeuToolStripMenuItem
            // 
            resources.ApplyResources(this.jeuToolStripMenuItem, "jeuToolStripMenuItem");
            this.jeuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.modeInfinityToolStripMenuItem,
            this.toolStripMenuItem2,
            this.publierRecordToolStripMenuItem,
            this.pseudoToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.jeuToolStripMenuItem.Name = "jeuToolStripMenuItem";
            // 
            // nouveauToolStripMenuItem
            // 
            resources.ApplyResources(this.nouveauToolStripMenuItem, "nouveauToolStripMenuItem");
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // modeInfinityToolStripMenuItem
            // 
            resources.ApplyResources(this.modeInfinityToolStripMenuItem, "modeInfinityToolStripMenuItem");
            this.modeInfinityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem});
            this.modeInfinityToolStripMenuItem.Name = "modeInfinityToolStripMenuItem";
            this.modeInfinityToolStripMenuItem.Click += new System.EventHandler(this.modeInfinityToolStripMenuItem_Click);
            // 
            // levelToolStripMenuItem
            // 
            resources.ApplyResources(this.levelToolStripMenuItem, "levelToolStripMenuItem");
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Click += new System.EventHandler(this.levelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // publierRecordToolStripMenuItem
            // 
            resources.ApplyResources(this.publierRecordToolStripMenuItem, "publierRecordToolStripMenuItem");
            this.publierRecordToolStripMenuItem.Name = "publierRecordToolStripMenuItem";
            this.publierRecordToolStripMenuItem.Click += new System.EventHandler(this.publierRecordToolStripMenuItem_Click);
            // 
            // pseudoToolStripMenuItem
            // 
            resources.ApplyResources(this.pseudoToolStripMenuItem, "pseudoToolStripMenuItem");
            this.pseudoToolStripMenuItem.Name = "pseudoToolStripMenuItem";
            this.pseudoToolStripMenuItem.Click += new System.EventHandler(this.pseudoToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            resources.ApplyResources(this.quitterToolStripMenuItem, "quitterToolStripMenuItem");
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // EspaceJeu
            // 
            resources.ApplyResources(this.EspaceJeu, "EspaceJeu");
            this.EspaceJeu.Name = "EspaceJeu";
            this.EspaceJeu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EspaceJeu_MouseClick);
            this.EspaceJeu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EspaceJeu_MouseMove);
            // 
            // CB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EspaceJeu);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CB";
            this.Load += new System.EventHandler(this.CB_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem jeuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
		private Jeu EspaceJeu;
        private System.Windows.Forms.ToolStripMenuItem modeInfinityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publierRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pseudoToolStripMenuItem;
    }
}


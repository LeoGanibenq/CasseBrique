using CassesBriques;
using MySqlConnector;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CasseBriques {
	public partial class CB : Form {
        private bool isPaused = false;

        public CB() {
			InitializeComponent();
            this.Icon = new System.Drawing.Icon("icon.ico");
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e) {
            int level = 1;
			EspaceJeu.initialiseNiveau(level, "lvl");
			this.Text = "CassesBriques - Lvl:"+level;
            this.Activated += onResume;
            this.Deactivate += onPause;
        }

        private void onResume(object sender, EventArgs e)
        {
            if(isPaused)
            {
                isPaused = false;
                MessageBox.Show("Vous allez ailleurs");
            }
        }

        private void onPause(object sender, EventArgs e)
        {
            if (isPaused)
            {
                isPaused = false;
                MessageBox.Show("resalut");
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

        private void modeInfinityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int level = 1;
            EspaceJeu.initialiseNiveau(level, "inf");

            string jsonStr = File.ReadAllText("config.json");
            JObject config = JObject.Parse(jsonStr);
            int points = (int) config["points"];

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

        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mur mur = new Mur();
            int level = mur.getLvlMax();
            this.Text = "CassesBriques - Infinity: " + level;
            EspaceJeu.initialiseNiveau(level, "inf");
        }

        private void publierRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region coBDD
            string connectionString = "server=mysql-clh.alwaysdata.net;uid=clh;pwd=tT2VIC65;database=clh_cassebrique;";
            #endregion

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;

                    string jsonStr = File.ReadAllText("config.json");
                    JObject config = JObject.Parse(jsonStr);
                    int record = (int) config["niveauMaxReussi"];

                    if((string) config["pseudo"] == "Anonyme")
                    {
                        string userInput = "";
                        
                        Form prompt = new Form()
                        {
                            Width = 500,
                            Height = 150,
                            FormBorderStyle = FormBorderStyle.FixedDialog,
                            Text = "Nom d'utilisateur"
                        };

                        Label textLabel = new Label() { Left = 50, Top = 20, Text = "Entrez votre nom :" };
                        TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                        Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                        confirmation.Click += (s, eventArgs) => { prompt.Close(); };

                        prompt.Controls.Add(textBox);
                        prompt.Controls.Add(confirmation);
                        prompt.Controls.Add(textLabel);
                        prompt.AcceptButton = confirmation;prompt.ShowDialog();

                        if (prompt.DialogResult == DialogResult.OK)
                        {
                            userInput = textBox.Text;
                            config["pseudo"] = userInput;
                            File.WriteAllText("config.json", jsonStr);
                            cmd.CommandText = "INSERT INTO highscore (pseudo, record) VALUES ('" + userInput + "', " + record.ToString() + ")";
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Record publié");
                        }                   
                    }
                    else
                    {
                        File.WriteAllText("config.json", jsonStr);
                        cmd.CommandText = "INSERT INTO highscore (pseudo, record) VALUES ('" + config["pseudo"] + "', " + record.ToString() + ")";
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record publié");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la publication: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion à la base de données : " + ex.Message, "BDD");
            }
        }

        private void pseudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userInput = "";

            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Nom d'utilisateur"
            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Entrez votre nom :" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (s, eventArgs) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation; prompt.ShowDialog();

            if (prompt.DialogResult == DialogResult.OK)
            {
                userInput = textBox.Text;
                string jsonStr = File.ReadAllText("config.json");
                JObject config = JObject.Parse(jsonStr);
                config["pseudo"] = userInput;
                File.WriteAllText("config.json", config.ToString());

                MessageBox.Show("Pseudo modifié avec succès", "Changement pseudo");
            }
        }

        private void EspaceJeu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EspaceJeu.EspaceJeu_MouseDClick(sender, e);
            MessageBox.Show("cheat");
        }
    }
}
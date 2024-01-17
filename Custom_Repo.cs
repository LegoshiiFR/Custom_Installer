using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Innstaller
{
    public partial class Custom_Repo : Form
    {
        private const string UrlDuTelechargement = "https://archive.legoshii.fr/money-app/download/MoneyApp-Setup.zip"; // Remplacez par l'URL réel du téléchargement
        private const string CheminDossierTelechargement = @"C:\Users\Utilisateur\AppData\Roaming\Custom_Installer"; // Remplacez par le chemin où vous souhaitez télécharger et extraire l'archive
        public Custom_Repo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomArchive = "MoneyApp-Setup"; // Remplacez par le nom réel de votre archive
            string destination = Path.Combine(CheminDossierTelechargement, $"{nomArchive}.zip");
            string emplacementTelechargement = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(emplacementTelechargement))
            {
                MessageBox.Show("Veuillez entrer un emplacement de téléchargement valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(emplacementTelechargement))
            {
                Directory.CreateDirectory(emplacementTelechargement);
            }
            if (string.IsNullOrEmpty(emplacementTelechargement))
            {
                MessageBox.Show("Veuillez entrer un emplacement de téléchargement valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(emplacementTelechargement))
            {
                Directory.CreateDirectory(emplacementTelechargement);
            }

            // Téléchargement du fichier
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, args) =>
                {
                    progressBar1.Value = args.ProgressPercentage;
                };

                client.DownloadFileCompleted += (s, args) =>
                {
                    // Extraction de l'archive
                    ZipFile.ExtractToDirectory(destination, "File Download");

                    // Affichage du message de fin
                    label4.Text = "Succesful Download";

                    // Vous pouvez ajouter d'autres actions ici si nécessaire

                    // Optionnel : Supprimer l'archive téléchargée après extraction
                    //File.Delete(destination);
                };

                client.DownloadFileAsync(new Uri(UrlDuTelechargement), destination);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

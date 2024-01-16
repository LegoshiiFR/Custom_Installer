using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace SetupApplication
{
    public partial class MainForm : Form
    {
        private WebClient webClient;
        private string downloadUrl = "URL_DE_L_ARCHIVE"; // Remplacez par l'URL réelle de l'archive
        private string downloadPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialiser la barre de progression
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Permet à l'utilisateur de sélectionner le dossier de destination
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDownloadPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // Vérifier si l'URL et le chemin de téléchargement sont spécifiés
            if (string.IsNullOrEmpty(downloadUrl) || string.IsNullOrEmpty(txtDownloadPath.Text))
            {
                MessageBox.Show("Veuillez spécifier l'URL de téléchargement et le chemin de destination.");
                return;
            }

            // Démarrer le téléchargement dans un thread séparé pour ne pas bloquer l'interface utilisateur
            downloadPath = txtDownloadPath.Text;
            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            try
            {
                // Lancer le téléchargement
                webClient.DownloadFileAsync(new Uri(downloadUrl), Path.Combine(downloadPath, "archive.zip"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du téléchargement : {ex.Message}");
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Mettre à jour la barre de progression pendant le téléchargement
            progressBar.Value = e.ProgressPercentage;
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Le téléchargement est terminé
            if (e.Error == null)
            {
                // Extraire l'archive (vous devez ajouter la logique d'extraction ici)
                MessageBox.Show("Téléchargement terminé avec succès.");
            }
            else
            {
                MessageBox.Show($"Erreur lors du téléchargement : {e.Error.Message}");
            }
        }
    }
}

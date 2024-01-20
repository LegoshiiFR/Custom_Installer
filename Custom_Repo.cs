using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Custom_Innstaller
{
    public partial class Custom_Repo : Form
    {
        private const string UrlDuTelechargement = ""; // Remplacez par l'URL réel du téléchargement
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
            string nomArchive = ""; // Remplace ce nom par celui de ton archive que tu veux télécharger
            string destination = Path.Combine(textBox1.Text.Trim(), $"{nomArchive}.zip");
            string emplacementTelechargement = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(emplacementTelechargement))
            {
                MessageBox.Show("Entre un emplacement de téléchargement valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(emplacementTelechargement))
            {
                Directory.CreateDirectory(emplacementTelechargement);
            }

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, args) =>
                {
                    progressBar1.Value = args.ProgressPercentage;
                };

                client.DownloadFileCompleted += (s, args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show($"Erreur de téléchargement : {args.Error.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (args.Cancelled)
                    {
                        MessageBox.Show("Téléchargement annulé.", "Annulé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    try
                    {
                        ZipFile.ExtractToDirectory(destination, emplacementTelechargement);
                        label4.Text = "Succesful Download";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                client.DownloadFileAsync(new Uri(UrlDuTelechargement), destination);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

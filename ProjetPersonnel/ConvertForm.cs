using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace SuperAudioPlayer
{
    public partial class ConvertForm : Form
    {
        public ConvertForm()
        {
            InitializeComponent();
            mp3_files_listview.View = View.Details;
        }

        private void browse_convert_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            fileDialog.ShowDialog();
            string selectedPath = fileDialog.SelectedPath;
            directory_textbox.Text = selectedPath;

            string[] songFilesList = System.IO.Directory.GetFiles(@selectedPath, "*.mp3");

            foreach (var song in songFilesList)
            {
                mp3_files_listview.Items.Add(song);
            }

        }

        public void Mp3ToWav(string mp3File, string outputFile)
        {
            using (Mp3FileReader reader = new Mp3FileReader(mp3File))
            {
                WaveFileWriter.CreateWaveFile(outputFile, reader);
            }
        }
    }
}

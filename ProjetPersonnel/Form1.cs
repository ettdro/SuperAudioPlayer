using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using NAudio.Wave;

namespace SuperAudioPlayer
{
    public partial class Form1 : Form
    {

        private string selectedPath;
        private int numberOfSongs;
        private string[] listeChemins;
        private SoundPlayer soundPlayer;
        private FolderBrowserDialog folderBrowser;

        public Form1()
        {
            InitializeComponent();
            folderBrowser = new FolderBrowserDialog();
            backgroundWorker1.WorkerReportsProgress = true;
        }

        
        /// <summary>
        /// Gets the time length of the music.
        /// </summary>
        /// <param name="fullPath">The full path of the music file.</param>
        /// <returns>String of the music time length.</returns>
        private Tuple<int, int> getMusicLength(string fullPath)
        {
            WaveFileReader waveReader = new WaveFileReader(fullPath);
            TimeSpan totalTime = waveReader.TotalTime;
            int minutes = totalTime.Minutes;
            int secondes = totalTime.Seconds;
            string totalMusicTime = totalTime.Minutes + ":" + totalTime.Seconds;
            
            return new Tuple<int,int>(minutes, secondes);
        }


        private void getMusicTime(string fullPath)
        {
            WaveFileReader waveReader = new WaveFileReader(fullPath);
            int seconds = waveReader.CurrentTime.Seconds;
            Console.WriteLine(seconds);
        }

        private void button_FileDialog_Click(object sender, EventArgs e)
        {
            int totalMinutes = 0;
            int totalSeconds = 0;
            int totalHours = 0;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                selectedPath = folderBrowser.SelectedPath;
                textBox_Path.Text = selectedPath.ToString();
            }

            listeChemins = System.IO.Directory.GetFiles(@selectedPath, "*.wav");

            foreach (string chemin in listeChemins)
            {
                string fichier = System.IO.Path.GetFileName(chemin);
                music_list.Items.Add(fichier);
                Tuple<int,int> totalTime = getMusicLength(chemin);
                totalMinutes = totalMinutes + totalTime.Item1;
                totalSeconds = totalSeconds + totalTime.Item2;
            }

            numberOfSongs = music_list.Items.Count;
            label_number_songs.Text = numberOfSongs.ToString();
            label_total_time_playlist.Text = totalHours.ToString() + ":" + totalMinutes.ToString() + ":" + totalSeconds.ToString();
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            if (music_list.SelectedItems.Count > 0)
            {
                string fullMusicPath = selectedPath + "\\" + music_list.SelectedItems[0].Text;
                soundPlayer = new SoundPlayer(fullMusicPath);
                Tuple<int,int> musicTimeLength = getMusicLength(fullMusicPath);

                music_bar.Maximum = 100;
                music_bar.Step = 1;
                music_bar.Value = 0;

                label_time_end.Text = musicTimeLength.Item1 + ":" + musicTimeLength.Item2;
                label_song_playing.Text = music_list.SelectedItems[0].Text;
                //int songIndex = music_list.SelectedIndices[0];
                //Console.WriteLine(songIndex);
                soundPlayer.Play();
            }
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(100);
                // Report progress.
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            music_bar.Value = e.ProgressPercentage;
            // Set the text.
            label_time_beginning.Text = e.ProgressPercentage.ToString();
        }

        private void next_button_Click(object sender, EventArgs e)
        {

            int nextSongIndex = music_list.SelectedIndices[0] + 1;
            Console.WriteLine(nextSongIndex);
            Console.WriteLine(music_list.SelectedItems[nextSongIndex - 1]);
            SoundPlayer nextSoundPlayer = new SoundPlayer(selectedPath + music_list.SelectedItems[nextSongIndex].Text);
            soundPlayer.Play();
        }
    }
}

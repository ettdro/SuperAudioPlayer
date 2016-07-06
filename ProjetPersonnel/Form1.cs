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
        /// <summary>
        /// The path of the music file (without the music file).
        /// </summary>
        private string selectedPath;

        private int numberOfSongs;
        private string[] songList;
        private SoundPlayer soundPlayer;
        private FolderBrowserDialog folderBrowser;

        public Form1()
        {
            InitializeComponent();
            folderBrowser = new FolderBrowserDialog();
            music_list.View = View.Details;
            music_list.Columns.Add("Nom chanson", 200);
            music_list.Columns.Add("Durée", 79);
            backgroundWorker1.WorkerReportsProgress = true;
        }

        
        /// <summary>
        /// Gets the time length of one song.
        /// </summary>
        /// <param name="fullPath">The full path of the song file.</param>
        /// <returns>String of the song time length.</returns>
        private Tuple<int, int> getSongLength(string fullPath)
        {
            WaveFileReader waveReader = new WaveFileReader(fullPath);
            TimeSpan totalTime = waveReader.TotalTime;
            int minutes = totalTime.Minutes;
            int secondes = totalTime.Seconds;
            string totalMusicTime = totalTime.Minutes + ":" + totalTime.Seconds;
            
            return new Tuple<int,int>(minutes, secondes);
        }

        /// <summary>
        /// Gets the total time duration of the playlist.
        /// </summary>
        /// <param name="fullPath">The full path of the music file.</param>
        /// <returns></returns>
        private Tuple<double, double, double> getTotalPlaylistTime(string fullPath)
        {
            int totalPlaylistHours = 0;
            int totalPlaylistMinutes = 0;
            double totalPlaylistSeconds = 0;

            Tuple<int, int> totalTime = getSongLength(fullPath);
            totalPlaylistSeconds = (totalPlaylistSeconds + totalTime.Item2) / 60;
            totalPlaylistMinutes = totalPlaylistMinutes + totalTime.Item1;

            return new Tuple<double, double, double>(totalPlaylistHours, totalPlaylistMinutes, totalPlaylistSeconds);
        }

        private Tuple<string, string, string> CheckTime(double totalHours, double totalMinutes, double totalSeconds)
        {
            string totalHoursString;
            string totalMinutesString;
            string totalSecondsString;

            if (totalHours < 10)
            {
                totalHoursString = totalHours.ToString().PadLeft(2, '0');
            }
            else
            {
                totalHoursString = totalHours.ToString();
            }

            if (totalMinutes < 10)
            {
                totalMinutesString = totalMinutes.ToString().PadLeft(2, '0');
            }
            else
            {
                totalMinutesString = totalMinutes.ToString();
            }

            if (totalSeconds < 10)
            {
                totalSecondsString = totalSeconds.ToString().PadLeft(2, '0');
            }
            else
            {
                totalSecondsString = totalSeconds.ToString();
            }

            return new Tuple<string, string, string>(totalHoursString, totalMinutesString, totalSecondsString);
        }

        private void PlaySong(string fullPath)
        {
            soundPlayer = new SoundPlayer(fullPath);
            soundPlayer.Play();
        }

        private void button_FileDialog_Click(object sender, EventArgs e)
        {
            double totalHours = 0;
            double totalMinutes = 0;
            double totalSeconds = 0;
            string totalTimeString;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                selectedPath = folderBrowser.SelectedPath;
                textBox_Path.Text = selectedPath.ToString();
            }

            songList = System.IO.Directory.GetFiles(@selectedPath, "*.wav");
            music_list.Items.Clear();

            // A for loop that adds song names and song duration in the listview columns.
            foreach (string chemin in songList)
            {
                string fichier = System.IO.Path.GetFileName(chemin);
                totalHours = getTotalPlaylistTime(chemin).Item1 + totalHours;
                totalMinutes = getTotalPlaylistTime(chemin).Item2 + totalMinutes;
                totalSeconds = getTotalPlaylistTime(chemin).Item3 + totalSeconds;

                Tuple<int, int> musicTimeLength = getSongLength(chemin);
                Tuple<string, string, string> songDuration = CheckTime(0, musicTimeLength.Item1, musicTimeLength.Item2);

                totalTimeString = songDuration.Item1 + ":" + songDuration.Item2 + ":" + songDuration.Item3;
                ListViewItem item = new ListViewItem();
                item.Text = fichier;                            // Name of songs column.
                item.SubItems.Add(totalTimeString);             // Duration of songs column.

                music_list.Items.Add(item);
            }

            numberOfSongs = music_list.Items.Count;

            if (numberOfSongs == 0)
            {
                music_list.Items.Add("Aucune chanson répertoriée.");
                music_list.Enabled = false;
            }
            else
            {
                totalMinutes = totalMinutes + Math.Truncate(totalSeconds);
                totalSeconds = Math.Round((totalSeconds % Math.Truncate(totalSeconds)) * 60);

                Tuple<string, string, string> totalPlaylistTime = CheckTime(totalHours, totalMinutes, totalSeconds);

                label_number_songs.Text = numberOfSongs.ToString();
                label_total_time_playlist.Text = totalPlaylistTime.Item1 + ":" + totalPlaylistTime.Item2 + ":" + totalPlaylistTime.Item3;
                music_list.Enabled = true;
            }
        }


        private void play_button_Click(object sender, EventArgs e)
        {
            if (numberOfSongs > 0)
            {
                string fullMusicPath = selectedPath + "\\" + music_list.SelectedItems[0].Text;
                
                Tuple<int,int> musicTimeLength = getSongLength(fullMusicPath);

                music_bar.Maximum = 100;
                music_bar.Step = 1;
                music_bar.Value = 0;

                label_time_end.Text = musicTimeLength.Item1 + ":" + musicTimeLength.Item2;
                label_song_playing.Text = music_list.SelectedItems[0].Text;

                PlaySong(fullMusicPath);
            }
            else
            {
                label_song_playing.Text = "Aucune chanson sélectionnée.";
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

        /// <summary>
        /// Represents the index of the previous song to be played in the listView.
        /// </summary>
        private int previousSongIndex;

        /// <summary>
        /// Plays the previous song in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previous_button_Click(object sender, EventArgs e)
        {
            string fullMusicPath = "";

            var indexCurrentSong = music_list.SelectedIndices;
            previousSongIndex = indexCurrentSong[0] - 1;
            if (previousSongIndex < 0)
            {
                fullMusicPath = selectedPath + "\\" + music_list.Items[indexCurrentSong[0]].Text;
            } else
            {
                music_list.Items[previousSongIndex].Selected = true;
                fullMusicPath = selectedPath + "\\" + music_list.Items[previousSongIndex].Text;

                Tuple<int, int> musicTimeLength = getSongLength(fullMusicPath);

                label_time_end.Text = musicTimeLength.Item1 + ":" + musicTimeLength.Item2;
                label_song_playing.Text = music_list.Items[previousSongIndex].Text;
            }
            
            PlaySong(fullMusicPath);
        }

        /// <summary>
        /// Represents the index of the next song to be played in the listView.
        /// </summary>
        private int nextSongIndex;

        /// <summary>
        /// Plays the next song in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_button_Click(object sender, EventArgs e)
        {
            string fullMusicPath = "";

            var indexCurrentSong = music_list.SelectedIndices;
            nextSongIndex = indexCurrentSong[0] + 1;
            if (nextSongIndex > music_list.Items.Count - 1)
            {
            } else
            {
                music_list.Items[nextSongIndex].Selected = true;

                fullMusicPath = selectedPath + "\\" + music_list.Items[nextSongIndex].Text;

                Tuple<int, int> musicTimeLength = getSongLength(fullMusicPath);

                label_time_end.Text = musicTimeLength.Item1 + ":" + musicTimeLength.Item2;
                label_song_playing.Text = music_list.Items[nextSongIndex].Text;

                PlaySong(fullMusicPath);
            }
        }

        /// <summary>
        /// Makes the columns of the list view not resizable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void music_list_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.music_list.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
    }
}

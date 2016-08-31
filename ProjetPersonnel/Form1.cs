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
using System.Data.SQLite;

namespace SuperAudioPlayer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The path of the music file (without the music file).
        /// </summary>
        private string selectedPath;
        private int numberOfSongs;
        private string[] songFilesList;
        private FolderBrowserDialog folderBrowser;
        private string filePath;
        private string currentSongPath;
        Database database;
        WaveOutEvent player = new WaveOutEvent();

        public Form1()
        {
            InitializeComponent();
            folderBrowser = new FolderBrowserDialog();
            database = new Database();

            database.OpenDB();

            music_list.View = View.Details;
            music_list.Columns.Add("Nom chanson", 233);
            music_list.Columns.Add("Album", 180);
            music_list.Columns.Add("Groupe", 180);
            music_list.Columns.Add("Durée", 79);
            music_list.Columns.Add("Type de fichier", 80);

            // Setting properties of Form1.
            this.CenterToScreen();
            music_list.FullRowSelect = true;
            music_list.Enabled = false;
            this.Text = "SuperAudioPlayer";
            player.Volume = 0.1f;
        }

        
        /// <summary>
        /// Gets the time length of one song to insert in the database. Use getSongLength in the Database class to get a song length.
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
            WaveStream mainOutputStream = new WaveFileReader(fullPath);
            WaveChannel32 waveChannel = new WaveChannel32(mainOutputStream);

            if (player.PlaybackState == PlaybackState.Playing)
            {
                player.Stop();
            }

            if (player.PlaybackState == PlaybackState.Stopped)
            {
                player.Init(waveChannel);
                player.Play();
                backgroundWorker1.RunWorkerAsync();
            }
            
            if (player.PlaybackState == PlaybackState.Paused)
            {
                player.Play();
            }

            Tuple<int, int> musicTimeLength = getSongLength(fullPath);

            Tuple<string, string, string> songLength = CheckTime(0, musicTimeLength.Item1, musicTimeLength.Item2);

            label_time_end.Text = songLength.Item2 + ":" + songLength.Item3;
            label_song_playing.Text = database.getSongTitle(fullPath);
            currentSongPath = fullPath;
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

                database.CreateTable();

                songFilesList = System.IO.Directory.GetFiles(@selectedPath, "*.wav");
                music_list.Items.Clear();

                // A for loop that adds song names and song duration in the listview columns.
                foreach (string file in songFilesList)
                {
                    string filename = System.IO.Path.GetFileNameWithoutExtension(file);
                    string fileExtension = System.IO.Path.GetExtension(file);
                    filePath = System.IO.Path.GetFullPath(file);

                    totalHours = getTotalPlaylistTime(file).Item1 + totalHours;
                    totalMinutes = getTotalPlaylistTime(file).Item2 + totalMinutes;
                    totalSeconds = getTotalPlaylistTime(file).Item3 + totalSeconds;

                    Tuple<int, int> musicTimeLength = getSongLength(file);
                    Tuple<string, string, string> songDuration = CheckTime(0, musicTimeLength.Item1, musicTimeLength.Item2);

                    totalTimeString = songDuration.Item1 + ":" + songDuration.Item2 + ":" + songDuration.Item3;

                    database.InsertSongDB(filename, "", "", totalTimeString, fileExtension, filePath);

                }

                List<List<string>> songsDBList = database.ReadDataDB();

                foreach (var songs in songsDBList)
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = songs[0];                                       // Name of songs column.
                    item.SubItems.Add(songs[1]);                              // Duration of songs column.
                    item.SubItems.Add(songs[2]);
                    item.SubItems.Add(songs[3]);
                    item.SubItems.Add(songs[4]);

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
            } else
            {
            }
        }


        private void play_button_Click(object sender, EventArgs e)
        {
            if (numberOfSongs > 0)
            {
                string songPath = database.getSongPath(music_list.SelectedItems[0].Text);

                PlaySong(songPath);
            }
            else
            {
                label_song_playing.Text = "Aucune chanson sélectionnée.";
            }
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (player.PlaybackState == PlaybackState.Paused)
            {
                player.Play();
            }
            else
            {
                player.Pause();
            }
        }

        private int minutes = 0;
        private int seconds = 0;

        private Tuple<int,int> getCurrentTime()
        {
            seconds++;

            if (seconds < 59)
            {
            } else
            {
                minutes++;
                seconds = 0;
            }

            return new Tuple<int, int>(minutes,seconds);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(1000);
                // Report progress.
                backgroundWorker1.ReportProgress(i);
            }
        }

        int i = 0;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            i++;
            WaveStream mainOutputStream = new WaveFileReader(currentSongPath);
            WaveChannel32 waveChannel = new WaveChannel32(mainOutputStream);

            Tuple<int,int> currentTime = getCurrentTime();
            Tuple<string,string,string> currentTimeStr = CheckTime(0, currentTime.Item1, currentTime.Item2);
            label_time_beginning.Text = currentTimeStr.Item2 + ":" + currentTimeStr.Item3;

            // Change the value of the ProgressBar to the BackgroundWorker progress.
            music_bar.Value = e.ProgressPercentage;
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
            var indexCurrentSong = database.getSongId(currentSongPath) - 1;
            previousSongIndex = indexCurrentSong - 1;
            if (previousSongIndex < 0)
            {
            } else
            {
                music_list.Items[previousSongIndex].Selected = true;
                filePath = database.getNextOrPreviousSongPath(previousSongIndex); ;

                Tuple<int, int> musicTimeLength = getSongLength(filePath);

                label_time_end.Text = musicTimeLength.Item1 + ":" + musicTimeLength.Item2;
                label_song_playing.Text = music_list.Items[previousSongIndex].Text;

                PlaySong(filePath);
            }
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
            var indexCurrentSong = database.getSongId(currentSongPath) - 1;
            nextSongIndex = indexCurrentSong + 1;
            if (nextSongIndex > music_list.Items.Count - 1)
            {
            } else
            {
                music_list.Items[nextSongIndex].Selected = true;

                filePath = database.getNextOrPreviousSongPath(nextSongIndex);

                Tuple<int, int> musicTimeLength = getSongLength(filePath);

                label_time_end.Text = musicTimeLength.Item1 + ":" + musicTimeLength.Item2;
                label_song_playing.Text = music_list.Items[nextSongIndex].Text;

                PlaySong(filePath);
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

        private void convert_button_Click(object sender, EventArgs e)
        {
            this.Refresh();
            ConvertForm convertForm = new ConvertForm();
        }

        private void music_list_DoubleClick(object sender, EventArgs e)
        {
            music_list.LabelEdit = true;
            music_list.SelectedItems[0].BeginEdit();
        }

        private void music_list_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string currentSongTitle = music_list.SelectedItems[0].Text;
            database.updateData(currentSongTitle, e.Label);
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            if (player.PlaybackState == PlaybackState.Stopped)
            {
            }
            else
            {
                player.Stop();
            }
        }

        private void volume_bar_Scroll(object sender, EventArgs e)
        {
            // Obsolete but functionnal.
            volume_number_label.Text = volume_bar.Value.ToString();
            if (player.Volume < 0.9)
            {
                player.Volume = player.Volume + 0.1f;
            } else
            {
            }
        }

        private void mP3ToWAVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertForm convertForm = new ConvertForm();
            convertForm.Show();
        }
    }
}

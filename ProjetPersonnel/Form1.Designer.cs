namespace SuperAudioPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_FileDialog = new System.Windows.Forms.Button();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.music_list = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.play_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.pause_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.music_bar = new System.Windows.Forms.ProgressBar();
            this.label_time_beginning = new System.Windows.Forms.Label();
            this.label_time_end = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_current_song = new System.Windows.Forms.Label();
            this.label_song_playing = new System.Windows.Forms.Label();
            this.label_text_number_songs = new System.Windows.Forms.Label();
            this.label_text_total_time_playlist = new System.Windows.Forms.Label();
            this.label_number_songs = new System.Windows.Forms.Label();
            this.label_total_time_playlist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_FileDialog
            // 
            this.button_FileDialog.Location = new System.Drawing.Point(387, 20);
            this.button_FileDialog.Name = "button_FileDialog";
            this.button_FileDialog.Size = new System.Drawing.Size(75, 23);
            this.button_FileDialog.TabIndex = 0;
            this.button_FileDialog.Text = "Browse";
            this.button_FileDialog.UseVisualStyleBackColor = true;
            this.button_FileDialog.Click += new System.EventHandler(this.button_FileDialog_Click);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(13, 23);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.ReadOnly = true;
            this.textBox_Path.Size = new System.Drawing.Size(368, 20);
            this.textBox_Path.TabIndex = 1;
            // 
            // music_list
            // 
            this.music_list.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.music_list.GridLines = true;
            this.music_list.Location = new System.Drawing.Point(13, 48);
            this.music_list.Margin = new System.Windows.Forms.Padding(0);
            this.music_list.MultiSelect = false;
            this.music_list.Name = "music_list";
            this.music_list.Size = new System.Drawing.Size(283, 435);
            this.music_list.TabIndex = 2;
            this.music_list.UseCompatibleStateImageBehavior = false;
            this.music_list.View = System.Windows.Forms.View.List;
            this.music_list.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.music_list_ColumnWidthChanging);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chemin du fichier audio:";
            // 
            // play_button
            // 
            this.play_button.Location = new System.Drawing.Point(425, 290);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(132, 69);
            this.play_button.TabIndex = 4;
            this.play_button.Text = "Play";
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // previous_button
            // 
            this.previous_button.Location = new System.Drawing.Point(376, 290);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(43, 107);
            this.previous_button.TabIndex = 5;
            this.previous_button.Text = "««";
            this.previous_button.UseVisualStyleBackColor = true;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(563, 290);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(43, 107);
            this.next_button.TabIndex = 6;
            this.next_button.Text = "»»";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(425, 366);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(63, 31);
            this.pause_button.TabIndex = 7;
            this.pause_button.Text = "Pause";
            this.pause_button.UseVisualStyleBackColor = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(494, 365);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(63, 31);
            this.stop_button.TabIndex = 8;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            // 
            // music_bar
            // 
            this.music_bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.music_bar.Location = new System.Drawing.Point(376, 261);
            this.music_bar.Name = "music_bar";
            this.music_bar.Size = new System.Drawing.Size(230, 23);
            this.music_bar.TabIndex = 9;
            // 
            // label_time_beginning
            // 
            this.label_time_beginning.AutoSize = true;
            this.label_time_beginning.Location = new System.Drawing.Point(373, 245);
            this.label_time_beginning.Name = "label_time_beginning";
            this.label_time_beginning.Size = new System.Drawing.Size(28, 13);
            this.label_time_beginning.TabIndex = 10;
            this.label_time_beginning.Text = "0:00";
            // 
            // label_time_end
            // 
            this.label_time_end.AutoSize = true;
            this.label_time_end.Location = new System.Drawing.Point(578, 245);
            this.label_time_end.Name = "label_time_end";
            this.label_time_end.Size = new System.Drawing.Size(28, 13);
            this.label_time_end.TabIndex = 11;
            this.label_time_end.Text = "0:00";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(376, 425);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(230, 45);
            this.trackBar1.TabIndex = 12;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // label_current_song
            // 
            this.label_current_song.AutoSize = true;
            this.label_current_song.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_current_song.Location = new System.Drawing.Point(462, 207);
            this.label_current_song.Name = "label_current_song";
            this.label_current_song.Size = new System.Drawing.Size(61, 13);
            this.label_current_song.TabIndex = 13;
            this.label_current_song.Text = "En cours:";
            // 
            // label_song_playing
            // 
            this.label_song_playing.AutoSize = true;
            this.label_song_playing.Location = new System.Drawing.Point(379, 225);
            this.label_song_playing.Name = "label_song_playing";
            this.label_song_playing.Size = new System.Drawing.Size(0, 13);
            this.label_song_playing.TabIndex = 14;
            // 
            // label_text_number_songs
            // 
            this.label_text_number_songs.AutoSize = true;
            this.label_text_number_songs.Location = new System.Drawing.Point(10, 486);
            this.label_text_number_songs.Name = "label_text_number_songs";
            this.label_text_number_songs.Size = new System.Drawing.Size(111, 13);
            this.label_text_number_songs.TabIndex = 15;
            this.label_text_number_songs.Text = "Nombre de chansons:";
            // 
            // label_text_total_time_playlist
            // 
            this.label_text_total_time_playlist.AutoSize = true;
            this.label_text_total_time_playlist.Location = new System.Drawing.Point(56, 503);
            this.label_text_total_time_playlist.Name = "label_text_total_time_playlist";
            this.label_text_total_time_playlist.Size = new System.Drawing.Size(65, 13);
            this.label_text_total_time_playlist.TabIndex = 16;
            this.label_text_total_time_playlist.Text = "Temps total:";
            // 
            // label_number_songs
            // 
            this.label_number_songs.AutoSize = true;
            this.label_number_songs.Location = new System.Drawing.Point(124, 487);
            this.label_number_songs.Name = "label_number_songs";
            this.label_number_songs.Size = new System.Drawing.Size(13, 13);
            this.label_number_songs.TabIndex = 17;
            this.label_number_songs.Text = "0";
            // 
            // label_total_time_playlist
            // 
            this.label_total_time_playlist.AutoSize = true;
            this.label_total_time_playlist.Location = new System.Drawing.Point(124, 504);
            this.label_total_time_playlist.Name = "label_total_time_playlist";
            this.label_total_time_playlist.Size = new System.Drawing.Size(49, 13);
            this.label_total_time_playlist.TabIndex = 18;
            this.label_total_time_playlist.Text = "00:00:00";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(675, 531);
            this.Controls.Add(this.label_total_time_playlist);
            this.Controls.Add(this.label_number_songs);
            this.Controls.Add(this.label_text_total_time_playlist);
            this.Controls.Add(this.label_text_number_songs);
            this.Controls.Add(this.label_song_playing);
            this.Controls.Add(this.label_current_song);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label_time_end);
            this.Controls.Add(this.label_time_beginning);
            this.Controls.Add(this.music_bar);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.pause_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.play_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.music_list);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.button_FileDialog);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_FileDialog;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.ListView music_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button play_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.ProgressBar music_bar;
        private System.Windows.Forms.Label label_time_beginning;
        private System.Windows.Forms.Label label_time_end;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_current_song;
        private System.Windows.Forms.Label label_song_playing;
        private System.Windows.Forms.Label label_text_number_songs;
        private System.Windows.Forms.Label label_text_total_time_playlist;
        private System.Windows.Forms.Label label_number_songs;
        private System.Windows.Forms.Label label_total_time_playlist;
    }
}


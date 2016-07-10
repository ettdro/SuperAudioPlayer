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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_current_song = new System.Windows.Forms.Label();
            this.label_song_playing = new System.Windows.Forms.Label();
            this.label_text_number_songs = new System.Windows.Forms.Label();
            this.label_text_total_time_playlist = new System.Windows.Forms.Label();
            this.label_number_songs = new System.Windows.Forms.Label();
            this.label_total_time_playlist = new System.Windows.Forms.Label();
            this.volume_bar = new System.Windows.Forms.TrackBar();
            this.volume_text_label = new System.Windows.Forms.Label();
            this.volume_number_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mP3ToWAVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aIFFToWAVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.volume_bar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_FileDialog
            // 
            this.button_FileDialog.Location = new System.Drawing.Point(383, 60);
            this.button_FileDialog.Name = "button_FileDialog";
            this.button_FileDialog.Size = new System.Drawing.Size(79, 20);
            this.button_FileDialog.TabIndex = 0;
            this.button_FileDialog.Text = "Parcourir";
            this.button_FileDialog.UseVisualStyleBackColor = true;
            this.button_FileDialog.Click += new System.EventHandler(this.button_FileDialog_Click);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(9, 60);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.ReadOnly = true;
            this.textBox_Path.Size = new System.Drawing.Size(368, 20);
            this.textBox_Path.TabIndex = 1;
            // 
            // music_list
            // 
            this.music_list.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.music_list.GridLines = true;
            this.music_list.Location = new System.Drawing.Point(9, 83);
            this.music_list.Margin = new System.Windows.Forms.Padding(0);
            this.music_list.MultiSelect = false;
            this.music_list.Name = "music_list";
            this.music_list.Size = new System.Drawing.Size(756, 180);
            this.music_list.TabIndex = 2;
            this.music_list.UseCompatibleStateImageBehavior = false;
            this.music_list.View = System.Windows.Forms.View.List;
            this.music_list.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.music_list_AfterLabelEdit);
            this.music_list.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.music_list_ColumnWidthChanging);
            this.music_list.DoubleClick += new System.EventHandler(this.music_list_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chemin du fichier audio:";
            // 
            // play_button
            // 
            this.play_button.Location = new System.Drawing.Point(330, 367);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(132, 69);
            this.play_button.TabIndex = 4;
            this.play_button.Text = "Play";
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // previous_button
            // 
            this.previous_button.Location = new System.Drawing.Point(281, 367);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(43, 107);
            this.previous_button.TabIndex = 5;
            this.previous_button.Text = "««";
            this.previous_button.UseVisualStyleBackColor = true;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(468, 367);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(43, 107);
            this.next_button.TabIndex = 6;
            this.next_button.Text = "»»";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(330, 443);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(63, 31);
            this.pause_button.TabIndex = 7;
            this.pause_button.Text = "Pause";
            this.pause_button.UseVisualStyleBackColor = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(399, 442);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(63, 31);
            this.stop_button.TabIndex = 8;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // music_bar
            // 
            this.music_bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.music_bar.Location = new System.Drawing.Point(281, 338);
            this.music_bar.Name = "music_bar";
            this.music_bar.Size = new System.Drawing.Size(230, 23);
            this.music_bar.TabIndex = 9;
            // 
            // label_time_beginning
            // 
            this.label_time_beginning.AutoSize = true;
            this.label_time_beginning.Location = new System.Drawing.Point(278, 322);
            this.label_time_beginning.Name = "label_time_beginning";
            this.label_time_beginning.Size = new System.Drawing.Size(28, 13);
            this.label_time_beginning.TabIndex = 10;
            this.label_time_beginning.Text = "0:00";
            // 
            // label_time_end
            // 
            this.label_time_end.AutoSize = true;
            this.label_time_end.Location = new System.Drawing.Point(483, 322);
            this.label_time_end.Name = "label_time_end";
            this.label_time_end.Size = new System.Drawing.Size(28, 13);
            this.label_time_end.TabIndex = 11;
            this.label_time_end.Text = "0:00";
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
            this.label_current_song.Location = new System.Drawing.Point(364, 284);
            this.label_current_song.Name = "label_current_song";
            this.label_current_song.Size = new System.Drawing.Size(61, 13);
            this.label_current_song.TabIndex = 13;
            this.label_current_song.Text = "En cours:";
            // 
            // label_song_playing
            // 
            this.label_song_playing.AutoSize = true;
            this.label_song_playing.Location = new System.Drawing.Point(302, 303);
            this.label_song_playing.Name = "label_song_playing";
            this.label_song_playing.Size = new System.Drawing.Size(0, 13);
            this.label_song_playing.TabIndex = 14;
            // 
            // label_text_number_songs
            // 
            this.label_text_number_songs.AutoSize = true;
            this.label_text_number_songs.Location = new System.Drawing.Point(600, 35);
            this.label_text_number_songs.Name = "label_text_number_songs";
            this.label_text_number_songs.Size = new System.Drawing.Size(111, 13);
            this.label_text_number_songs.TabIndex = 15;
            this.label_text_number_songs.Text = "Nombre de chansons:";
            // 
            // label_text_total_time_playlist
            // 
            this.label_text_total_time_playlist.AutoSize = true;
            this.label_text_total_time_playlist.Location = new System.Drawing.Point(646, 48);
            this.label_text_total_time_playlist.Name = "label_text_total_time_playlist";
            this.label_text_total_time_playlist.Size = new System.Drawing.Size(65, 13);
            this.label_text_total_time_playlist.TabIndex = 16;
            this.label_text_total_time_playlist.Text = "Temps total:";
            // 
            // label_number_songs
            // 
            this.label_number_songs.AutoSize = true;
            this.label_number_songs.Location = new System.Drawing.Point(707, 35);
            this.label_number_songs.Name = "label_number_songs";
            this.label_number_songs.Size = new System.Drawing.Size(13, 13);
            this.label_number_songs.TabIndex = 17;
            this.label_number_songs.Text = "0";
            // 
            // label_total_time_playlist
            // 
            this.label_total_time_playlist.AutoSize = true;
            this.label_total_time_playlist.Location = new System.Drawing.Point(707, 48);
            this.label_total_time_playlist.Name = "label_total_time_playlist";
            this.label_total_time_playlist.Size = new System.Drawing.Size(49, 13);
            this.label_total_time_playlist.TabIndex = 18;
            this.label_total_time_playlist.Text = "00:00:00";
            // 
            // volume_bar
            // 
            this.volume_bar.Location = new System.Drawing.Point(281, 492);
            this.volume_bar.Name = "volume_bar";
            this.volume_bar.Size = new System.Drawing.Size(230, 45);
            this.volume_bar.TabIndex = 19;
            this.volume_bar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volume_bar.Scroll += new System.EventHandler(this.volume_bar_Scroll);
            // 
            // volume_text_label
            // 
            this.volume_text_label.AutoSize = true;
            this.volume_text_label.Location = new System.Drawing.Point(279, 540);
            this.volume_text_label.Name = "volume_text_label";
            this.volume_text_label.Size = new System.Drawing.Size(45, 13);
            this.volume_text_label.TabIndex = 20;
            this.volume_text_label.Text = "Volume:";
            // 
            // volume_number_label
            // 
            this.volume_number_label.AutoSize = true;
            this.volume_number_label.Location = new System.Drawing.Point(323, 540);
            this.volume_number_label.Name = "volume_number_label";
            this.volume_number_label.Size = new System.Drawing.Size(13, 13);
            this.volume_number_label.TabIndex = 21;
            this.volume_number_label.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_bar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_bar
            // 
            this.menu_bar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mP3ToWAVToolStripMenuItem,
            this.aIFFToWAVToolStripMenuItem});
            this.menu_bar.Name = "menu_bar";
            this.menu_bar.Size = new System.Drawing.Size(68, 20);
            this.menu_bar.Text = "Convertir";
            // 
            // mP3ToWAVToolStripMenuItem
            // 
            this.mP3ToWAVToolStripMenuItem.Name = "mP3ToWAVToolStripMenuItem";
            this.mP3ToWAVToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.mP3ToWAVToolStripMenuItem.Text = "MP3 to WAV";
            this.mP3ToWAVToolStripMenuItem.Click += new System.EventHandler(this.mP3ToWAVToolStripMenuItem_Click);
            // 
            // aIFFToWAVToolStripMenuItem
            // 
            this.aIFFToWAVToolStripMenuItem.Name = "aIFFToWAVToolStripMenuItem";
            this.aIFFToWAVToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.aIFFToWAVToolStripMenuItem.Text = "AIFF to WAV";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(778, 566);
            this.Controls.Add(this.volume_number_label);
            this.Controls.Add(this.volume_text_label);
            this.Controls.Add(this.volume_bar);
            this.Controls.Add(this.label_total_time_playlist);
            this.Controls.Add(this.label_number_songs);
            this.Controls.Add(this.label_text_total_time_playlist);
            this.Controls.Add(this.label_text_number_songs);
            this.Controls.Add(this.label_song_playing);
            this.Controls.Add(this.label_current_song);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volume_bar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_current_song;
        private System.Windows.Forms.Label label_song_playing;
        private System.Windows.Forms.Label label_text_number_songs;
        private System.Windows.Forms.Label label_text_total_time_playlist;
        private System.Windows.Forms.Label label_number_songs;
        private System.Windows.Forms.Label label_total_time_playlist;
        private System.Windows.Forms.TrackBar volume_bar;
        private System.Windows.Forms.Label volume_text_label;
        private System.Windows.Forms.Label volume_number_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_bar;
        private System.Windows.Forms.ToolStripMenuItem mP3ToWAVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aIFFToWAVToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}


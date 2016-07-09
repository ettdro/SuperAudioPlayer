namespace SuperAudioPlayer
{
    partial class ConvertForm
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
            this.browse_convert_button = new System.Windows.Forms.Button();
            this.directory_textbox = new System.Windows.Forms.TextBox();
            this.mp3_files_listview = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // browse_convert_button
            // 
            this.browse_convert_button.Location = new System.Drawing.Point(268, 36);
            this.browse_convert_button.Name = "browse_convert_button";
            this.browse_convert_button.Size = new System.Drawing.Size(128, 32);
            this.browse_convert_button.TabIndex = 0;
            this.browse_convert_button.Text = "Parcourir";
            this.browse_convert_button.UseVisualStyleBackColor = true;
            this.browse_convert_button.Click += new System.EventHandler(this.browse_convert_button_Click);
            // 
            // directory_textbox
            // 
            this.directory_textbox.Location = new System.Drawing.Point(115, 74);
            this.directory_textbox.Name = "directory_textbox";
            this.directory_textbox.ReadOnly = true;
            this.directory_textbox.Size = new System.Drawing.Size(454, 20);
            this.directory_textbox.TabIndex = 1;
            // 
            // mp3_files_listview
            // 
            this.mp3_files_listview.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mp3_files_listview.FullRowSelect = true;
            this.mp3_files_listview.Location = new System.Drawing.Point(115, 100);
            this.mp3_files_listview.Name = "mp3_files_listview";
            this.mp3_files_listview.Size = new System.Drawing.Size(454, 184);
            this.mp3_files_listview.TabIndex = 2;
            this.mp3_files_listview.UseCompatibleStateImageBehavior = false;
            // 
            // ConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 531);
            this.Controls.Add(this.mp3_files_listview);
            this.Controls.Add(this.directory_textbox);
            this.Controls.Add(this.browse_convert_button);
            this.Name = "ConvertForm";
            this.Text = "ConvertForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse_convert_button;
        private System.Windows.Forms.TextBox directory_textbox;
        private System.Windows.Forms.ListView mp3_files_listview;
    }
}
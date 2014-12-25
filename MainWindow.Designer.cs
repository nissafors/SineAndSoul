namespace SineAndSoul
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MixerGroupBox = new System.Windows.Forms.GroupBox();
            this.PlaybackGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComputerKeyboardOctaveNumeric = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.PlaybackGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComputerKeyboardOctaveNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.importToolStripMenuItem.Text = "Import frequencies";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.ImportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // MixerGroupBox
            // 
            this.MixerGroupBox.Location = new System.Drawing.Point(13, 28);
            this.MixerGroupBox.Name = "MixerGroupBox";
            this.MixerGroupBox.Size = new System.Drawing.Size(704, 382);
            this.MixerGroupBox.TabIndex = 2;
            this.MixerGroupBox.TabStop = false;
            this.MixerGroupBox.Text = "Overtone Mixer";
            // 
            // PlaybackGroupBox
            // 
            this.PlaybackGroupBox.Controls.Add(this.ComputerKeyboardOctaveNumeric);
            this.PlaybackGroupBox.Controls.Add(this.label1);
            this.PlaybackGroupBox.Location = new System.Drawing.Point(13, 417);
            this.PlaybackGroupBox.Name = "PlaybackGroupBox";
            this.PlaybackGroupBox.Size = new System.Drawing.Size(704, 100);
            this.PlaybackGroupBox.TabIndex = 3;
            this.PlaybackGroupBox.TabStop = false;
            this.PlaybackGroupBox.Text = "Playback";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.MaximumSize = new System.Drawing.Size(100, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Computer keyboard playback octave";
            // 
            // ComputerKeyboardOctaveNumeric
            // 
            this.ComputerKeyboardOctaveNumeric.Location = new System.Drawing.Point(23, 56);
            this.ComputerKeyboardOctaveNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.ComputerKeyboardOctaveNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.ComputerKeyboardOctaveNumeric.Name = "ComputerKeyboardOctaveNumeric";
            this.ComputerKeyboardOctaveNumeric.Size = new System.Drawing.Size(96, 20);
            this.ComputerKeyboardOctaveNumeric.TabIndex = 1;
            this.ComputerKeyboardOctaveNumeric.ValueChanged += new System.EventHandler(this.ComputerKeyboardOctaveNumeric_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 530);
            this.Controls.Add(this.PlaybackGroupBox);
            this.Controls.Add(this.MixerGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Sine & Soul";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PlaybackGroupBox.ResumeLayout(false);
            this.PlaybackGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComputerKeyboardOctaveNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.GroupBox MixerGroupBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox PlaybackGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ComputerKeyboardOctaveNumeric;

    }
}


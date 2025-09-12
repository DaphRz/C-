namespace Butterfly_Catching_Game_MOO_ICT
{
    partial class GameWindow
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            lblTime = new Label();
            lblCaught = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(-56, 491);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(889, 42);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = Color.White;
            lblTime.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTime.Location = new Point(12, 497);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(185, 25);
            lblTime.TabIndex = 1;
            lblTime.Text = "Tempo Restante: 00";
            // 
            // lblCaught
            // 
            lblCaught.AutoSize = true;
            lblCaught.BackColor = Color.White;
            lblCaught.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblCaught.Location = new Point(686, 497);
            lblCaught.Name = "lblCaught";
            lblCaught.Size = new Size(129, 25);
            lblCaught.TabIndex = 2;
            lblCaught.Text = "Borboletas: 0";
            lblCaught.Click += lblCaught_Click;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(824, 531);
            Controls.Add(lblCaught);
            Controls.Add(lblTime);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Name = "GameWindow";
            Text = "Game Window: Butterfly Catching Game MOO ICT";
            Load += GameWindow_Load;
            Click += FormClickEvent;
            Paint += FormPaintEvent;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblTime;
        private Label lblCaught;
        private System.Windows.Forms.Timer GameTimer;
    }
}
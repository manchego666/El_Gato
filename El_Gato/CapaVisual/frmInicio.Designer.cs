namespace El_Gato
{
    partial class frmInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            btnJugarCPP = new Button();
            btnJugarBot = new Button();
            btnJugarOnline = new Button();
            btnSalir = new Button();
            btnSource = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.Anime_style_illustra;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(958, 803);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnJugarCPP
            // 
            btnJugarCPP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnJugarCPP.BackColor = Color.White;
            btnJugarCPP.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnJugarCPP.ForeColor = Color.Black;
            btnJugarCPP.Location = new Point(32, 552);
            btnJugarCPP.Name = "btnJugarCPP";
            btnJugarCPP.Size = new Size(163, 53);
            btnJugarCPP.TabIndex = 1;
            btnJugarCPP.Text = "JUGAR C++";
            btnJugarCPP.UseVisualStyleBackColor = false;
            btnJugarCPP.Click += btnJugarCPP_Click;
            // 
            // btnJugarBot
            // 
            btnJugarBot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnJugarBot.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnJugarBot.Location = new Point(32, 630);
            btnJugarBot.Name = "btnJugarBot";
            btnJugarBot.Size = new Size(163, 53);
            btnJugarBot.TabIndex = 2;
            btnJugarBot.Text = "JUGAR VS BOT";
            btnJugarBot.UseVisualStyleBackColor = true;
            btnJugarBot.Click += btnJugarBot_Click;
            // 
            // btnJugarOnline
            // 
            btnJugarOnline.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnJugarOnline.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnJugarOnline.Location = new Point(32, 714);
            btnJugarOnline.Name = "btnJugarOnline";
            btnJugarOnline.Size = new Size(163, 53);
            btnJugarOnline.TabIndex = 3;
            btnJugarOnline.Text = "JUGAR ONLINE";
            btnJugarOnline.UseVisualStyleBackColor = true;
            btnJugarOnline.Click += btnJugarOnline_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(848, 753);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(99, 36);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnSource
            // 
            btnSource.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSource.Font = new Font("Arial", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSource.Location = new Point(724, 753);
            btnSource.Name = "btnSource";
            btnSource.Size = new Size(99, 36);
            btnSource.TabIndex = 5;
            btnSource.Text = "GITHUB SOURCE";
            btnSource.UseVisualStyleBackColor = true;
            btnSource.Click += btnSource_Click;
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 801);
            Controls.Add(btnSource);
            Controls.Add(btnSalir);
            Controls.Add(btnJugarOnline);
            Controls.Add(btnJugarBot);
            Controls.Add(btnJugarCPP);
            Controls.Add(pictureBox1);
            Name = "frmInicio";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnJugarCPP;
        private Button btnJugarBot;
        private Button btnJugarOnline;
        private Button btnSalir;
        private Button btnSource;
    }
}

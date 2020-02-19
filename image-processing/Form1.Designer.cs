namespace image_processing
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.choosePictureBtn = new System.Windows.Forms.Button();
            this.brightnessLbl = new System.Windows.Forms.Label();
            this.contrastLbl = new System.Windows.Forms.Label();
            this.konturaLbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.konturaCmb = new System.Windows.Forms.ComboBox();
            this.colorLbl = new System.Windows.Forms.Label();
            this.sizeLbl = new System.Windows.Forms.Label();
            this.sizeNum = new System.Windows.Forms.NumericUpDown();
            this.btnDetectObjects = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.trbBrightness = new System.Windows.Forms.TrackBar();
            this.trbContrast = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(180, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(608, 426);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // choosePictureBtn
            // 
            this.choosePictureBtn.Location = new System.Drawing.Point(12, 12);
            this.choosePictureBtn.Name = "choosePictureBtn";
            this.choosePictureBtn.Size = new System.Drawing.Size(162, 23);
            this.choosePictureBtn.TabIndex = 1;
            this.choosePictureBtn.Text = "Odaberite sliku";
            this.choosePictureBtn.UseVisualStyleBackColor = true;
            this.choosePictureBtn.Click += new System.EventHandler(this.choosePictureBtn_Click);
            // 
            // brightnessLbl
            // 
            this.brightnessLbl.AutoSize = true;
            this.brightnessLbl.Location = new System.Drawing.Point(9, 47);
            this.brightnessLbl.Name = "brightnessLbl";
            this.brightnessLbl.Size = new System.Drawing.Size(56, 13);
            this.brightnessLbl.TabIndex = 2;
            this.brightnessLbl.Text = "Brightness";
            // 
            // contrastLbl
            // 
            this.contrastLbl.AutoSize = true;
            this.contrastLbl.Location = new System.Drawing.Point(9, 91);
            this.contrastLbl.Name = "contrastLbl";
            this.contrastLbl.Size = new System.Drawing.Size(46, 13);
            this.contrastLbl.TabIndex = 3;
            this.contrastLbl.Text = "Contrast";
            // 
            // konturaLbl
            // 
            this.konturaLbl.AutoSize = true;
            this.konturaLbl.Location = new System.Drawing.Point(9, 177);
            this.konturaLbl.Name = "konturaLbl";
            this.konturaLbl.Size = new System.Drawing.Size(31, 13);
            this.konturaLbl.TabIndex = 4;
            this.konturaLbl.Text = "Oblik";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // konturaCmb
            // 
            this.konturaCmb.FormattingEnabled = true;
            this.konturaCmb.Location = new System.Drawing.Point(74, 174);
            this.konturaCmb.Name = "konturaCmb";
            this.konturaCmb.Size = new System.Drawing.Size(100, 21);
            this.konturaCmb.TabIndex = 7;
            this.konturaCmb.SelectedIndexChanged += new System.EventHandler(this.konturaCmb_SelectedIndexChanged);
            // 
            // colorLbl
            // 
            this.colorLbl.AutoSize = true;
            this.colorLbl.Location = new System.Drawing.Point(9, 230);
            this.colorLbl.Name = "colorLbl";
            this.colorLbl.Size = new System.Drawing.Size(28, 13);
            this.colorLbl.TabIndex = 10;
            this.colorLbl.Text = "Boja";
            // 
            // sizeLbl
            // 
            this.sizeLbl.AutoSize = true;
            this.sizeLbl.Location = new System.Drawing.Point(9, 277);
            this.sizeLbl.Name = "sizeLbl";
            this.sizeLbl.Size = new System.Drawing.Size(44, 13);
            this.sizeLbl.TabIndex = 11;
            this.sizeLbl.Text = "Velicina";
            // 
            // sizeNum
            // 
            this.sizeNum.Location = new System.Drawing.Point(74, 275);
            this.sizeNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sizeNum.Name = "sizeNum";
            this.sizeNum.Size = new System.Drawing.Size(100, 20);
            this.sizeNum.TabIndex = 12;
            this.sizeNum.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnDetectObjects
            // 
            this.btnDetectObjects.Location = new System.Drawing.Point(12, 361);
            this.btnDetectObjects.Name = "btnDetectObjects";
            this.btnDetectObjects.Size = new System.Drawing.Size(162, 77);
            this.btnDetectObjects.TabIndex = 14;
            this.btnDetectObjects.Text = "Detektuj";
            this.btnDetectObjects.UseVisualStyleBackColor = true;
            this.btnDetectObjects.Click += new System.EventHandler(this.btnDetectObjects_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Red;
            this.btnColor.Location = new System.Drawing.Point(74, 225);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 23);
            this.btnColor.TabIndex = 16;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // trbBrightness
            // 
            this.trbBrightness.Location = new System.Drawing.Point(70, 47);
            this.trbBrightness.Maximum = 255;
            this.trbBrightness.Name = "trbBrightness";
            this.trbBrightness.Size = new System.Drawing.Size(104, 45);
            this.trbBrightness.TabIndex = 17;
            this.trbBrightness.Value = 128;
            this.trbBrightness.Scroll += new System.EventHandler(this.trbBrightness_Scroll);
            // 
            // trbContrast
            // 
            this.trbContrast.Location = new System.Drawing.Point(70, 91);
            this.trbContrast.Maximum = 255;
            this.trbContrast.Name = "trbContrast";
            this.trbContrast.Size = new System.Drawing.Size(104, 45);
            this.trbContrast.TabIndex = 18;
            this.trbContrast.Value = 128;
            this.trbContrast.Scroll += new System.EventHandler(this.trbContrast_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trbContrast);
            this.Controls.Add(this.trbBrightness);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnDetectObjects);
            this.Controls.Add(this.sizeNum);
            this.Controls.Add(this.sizeLbl);
            this.Controls.Add(this.colorLbl);
            this.Controls.Add(this.konturaCmb);
            this.Controls.Add(this.konturaLbl);
            this.Controls.Add(this.contrastLbl);
            this.Controls.Add(this.brightnessLbl);
            this.Controls.Add(this.choosePictureBtn);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Detekcija oblika";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button choosePictureBtn;
        private System.Windows.Forms.Label brightnessLbl;
        private System.Windows.Forms.Label contrastLbl;
        private System.Windows.Forms.Label konturaLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox konturaCmb;
        private System.Windows.Forms.Label colorLbl;
        private System.Windows.Forms.Label sizeLbl;
        private System.Windows.Forms.NumericUpDown sizeNum;
        private System.Windows.Forms.Button btnDetectObjects;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TrackBar trbBrightness;
        private System.Windows.Forms.TrackBar trbContrast;
    }
}


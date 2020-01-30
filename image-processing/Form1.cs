using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace image_processing
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> image;

        int brightness;
        int contrast;
        string shape = "Pravougaonik";
        Color color = Color.Red;
        int size = 1;

        public Form1()
        {
            InitializeComponent();

            konturaCmb.DataSource = new string[] { "Pravougaonik", "Krug", "Trougao" };
            konturaCmb.SelectedItem = shape;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Image<Bgr, byte>(Properties.Resources.slika);
            pictureBox.Image = image.ToBitmap();
        }

        private void choosePictureBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                image = new Image<Bgr, byte>(openFileDialog1.FileName);
                pictureBox.Image = image.ToBitmap();
            }
        }

        private void konturaCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.shape = konturaCmb.SelectedItem.ToString();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                color = colorDialog1.Color;
            }
        }

        private void trbBrightness_Scroll(object sender, EventArgs e)
        {
            Bitmap tmpBmp = new Bitmap(image.Width, image.Height);
            //pictureBox.Image = tmpBmp;
        }

        private void trbContrast_Scroll(object sender, EventArgs e)
        {
            Bitmap tmpBmp = new Bitmap(image.Width, image.Height);
            //pictureBox.Image = tmpBmp;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size = (int)sizeNum.Value;
        }

        private void btnDetectObjects_Click(object sender, EventArgs e)
        {
            var tmpImage = image.Copy();

            Bgr lowerLimit = new Bgr(0, 0, 0);
            Bgr upperLimit = new Bgr(color.B, color.G, color.R);
            Image<Gray, byte> grayImage = tmpImage.InRange(lowerLimit, upperLimit);

            VectorOfVectorOfPoint shapes = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(grayImage, shapes, new Mat(), RetrType.External, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < shapes.Size; i++)
            {
                double shapePerimiter = CvInvoke.ArcLength(shapes[i], true);
                VectorOfPoint approx = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(shapes[i], approx, 0.03 * shapePerimiter, true);

                MCvMoments moments = CvInvoke.Moments(shapes[i]);
                int x = (int)(moments.M10 / moments.M00) - 60;
                int y = (int)(moments.M01 / moments.M00);

                if (shape.Equals("Pravougaonik") && ShapeFits(shapePerimiter) && approx.Size == 4)
                {
                    CvInvoke.PutText(tmpImage, "Pravougaonik", new Point(x, y), FontFace.HersheyTriplex, 0.6, new MCvScalar(0, 0, 0), 1);
                }
                else if (shape.Equals("Krug") && ShapeFits(shapePerimiter) && approx.Size > 6)
                {
                    CvInvoke.PutText(tmpImage, "Krug", new Point(x, y), FontFace.HersheyTriplex, 0.6, new MCvScalar(0, 0, 0), 1);
                }
                else if (shape.Equals("Trougao") && ShapeFits(shapePerimiter) && approx.Size == 3)
                {
                    CvInvoke.PutText(tmpImage, "Trougao", new Point(x, y), FontFace.HersheyTriplex, 0.6, new MCvScalar(0, 0, 0), 1);
                }

                pictureBox.Image = tmpImage.ToBitmap();
            }
        }

        private bool ShapeFits(double shapeSize)
        {
            if (size == 0)
                return true;
            if (size == 1 && shapeSize > 100)
                return true;
            if (size == 2 && shapeSize > 200)
                return true;
            if (size == 3 && shapeSize > 300)
                return true;
            if (size == 4 && shapeSize > 400)
                return true;
            if (size == 5 && shapeSize > 500)
                return true;
            if (size == 6 && shapeSize > 600)
                return true;
            if (size == 7 && shapeSize > 700)
                return true;
            if (size == 8 && shapeSize > 800)
                return true;
            if (size == 9 && shapeSize > 900)
                return true;
            return false;
        }
    }

}

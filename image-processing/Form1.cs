﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace image_processing
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> image;
        private float brightness = 0f;
        private float contrast = 1f;
        private string shape = "Pravougaonik";
        private Color color = Color.Red;
        private int size = 0;

        public Form1()
        {
            InitializeComponent();

            konturaCmb.DataSource = new string[] { "Pravougaonik", "Krug", "Trougao" };
            konturaCmb.SelectedItem = shape;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Image<Bgr, byte>(Properties.Resources.slika);
            pictureBox.Image = image.Bitmap;
        }

        private void choosePictureBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                image = new Image<Bgr, byte>(openFileDialog1.FileName);
                pictureBox.Image = image.Bitmap;
            }
        }

        private void konturaCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            shape = konturaCmb.SelectedItem.ToString();
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
            brightness = trbBrightness.Value / 255.0f * 2 - 1;

            var tmpImage = image.Copy();
            Bitmap bitmap = tmpImage.Bitmap;

            pictureBox.Image = GetBitmapWithFiltersApplied(bitmap);
        }

        private void trbContrast_Scroll(object sender, EventArgs e)
        {
            contrast = trbContrast.Value / 128.0f;

            var tmpImage = image.Copy();
            Bitmap bitmap = tmpImage.Bitmap;

            pictureBox.Image = GetBitmapWithFiltersApplied(bitmap);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size = (int)sizeNum.Value;
        }

        private void btnDetectObjects_Click(object sender, EventArgs e)
        {
            var tmpImage = image.Copy();

            Image<Gray, byte> grayImage = tmpImage.InRange(new Bgr(color), new Bgr(color));

            VectorOfVectorOfPoint shapes = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(grayImage, shapes, new Mat(), RetrType.External, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < shapes.Size; i++)
            {
                double shapePerimiter = CvInvoke.ArcLength(shapes[i], true);

                if (shapePerimiter >= size)
                {
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(shapes[i], approx, shapePerimiter * 0.03, true);

                    MCvMoments moments = CvInvoke.Moments(shapes[i]);
                    Point shapeCenter = new Point((int)(moments.M10 / moments.M00), (int)(moments.M01 / moments.M00));
                    MCvScalar textColor = new MCvScalar(0, 0, 0);
                    MCvScalar borderColor = new MCvScalar(0, 0, 0);

                    if (shape.Equals("Pravougaonik") && approx.Size == 4)
                    {
                        CvInvoke.DrawContours(tmpImage, shapes, i, borderColor, 3);
                        CvInvoke.PutText(tmpImage, "Pravougaonik", shapeCenter, FontFace.HersheyTriplex, 0.6, textColor, 2);
                    }
                    else if (shape.Equals("Trougao") && approx.Size == 3)
                    {
                        CvInvoke.DrawContours(tmpImage, shapes, i, borderColor, 3);
                        CvInvoke.PutText(tmpImage, "Trougao", shapeCenter, FontFace.HersheyTriplex, 0.6, textColor, 2);

                    }
                    else if (shape.Equals("Krug") && approx.Size > 4)
                    {
                        CvInvoke.DrawContours(tmpImage, shapes, i, borderColor, 3);
                        CvInvoke.PutText(tmpImage, "Krug", shapeCenter, FontFace.HersheyTriplex, 0.6, textColor, 2);
                    }
                }
            }
            pictureBox.Image = GetBitmapWithFiltersApplied(tmpImage.Bitmap);
        }
 
        private Bitmap GetBitmapWithFiltersApplied(Bitmap bitmap)
        {
            float b = brightness;
            //float[][] brightnessMatrix = new float[][]
            //{
            //    new float[] {1, 0, 0, 0, 0},
            //    new float[] {0, 1, 0, 0, 0},
            //    new float[] {0, 0, 1, 0, 0},
            //    new float[] {0, 0, 0, 1, 0},
            //    new float[] {b, b, b, 0, 1},
            //};
 
            float c = contrast;
            float t = 0.5f * (1f - contrast);
            //float[][] contrastMatrix = new float[][]
            //{
            //    new float[] {c, 0, 0, 0, 0},
            //    new float[] {0, c, 0, 0, 0},
            //    new float[] {0, 0, c, 0, 0},
            //    new float[] {0, 0, 0, 1, 0},
            //    new float[] {t, t, t, 0, 1},
            //};

            float[][] combinedBrightnessContrastMatrix = new float[][]
            {
                new float[] {c, 0, 0, 0, 0},
                new float[] {0, c, 0, 0, 0},
                new float[] {0, 0, c, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {b * c + t, b * c + t, b * c + t, 0, 1},
            };

            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(new ColorMatrix(combinedBrightnessContrastMatrix));

            Point[] points =
            {
                new Point(0, 0),
                new Point(bitmap.Width, 0),
                new Point(0, bitmap.Height)
            };
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            Bitmap res = new Bitmap(bitmap.Width, bitmap.Height);
            using (Graphics gr = Graphics.FromImage(res))
            {
                gr.DrawImage(bitmap, points, rect, GraphicsUnit.Pixel, ia);
            }
            return res;
        }
    }

}

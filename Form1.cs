using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.Util;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;

namespace ID_Card_segmentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image<Gray, byte> srcImg;
        string path;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return;
            }
            srcImg = new Image<Gray, byte>(path);
            Image<Gray, byte>  src_cpy = srcImg.Copy();
            //pictureBoxOri.Image = srcImg.Bitmap;

            Image<Gray, byte> adap = preprocess(srcImg);

            Image<Gray, byte> morp = morphologyEx(adap);
            //pictureBoxMorp.Image = morp.Bitmap;

            Image<Gray, byte> copy = morp.Copy();



            int w = copy.Width;
            int h = copy.Height;

            if(w<h)
            {
                MessageBox.Show("Only accept image with width > height");
                return;
            }

            //X axis
            int[] hist_x = new int[w];

            for (int i = 0; i < w; i++)
            {
                double sum = 0;
                for (int j = 0; j < h; j++)
                {
                    sum = sum + copy[j, i].Intensity;
                    
                }
                hist_x[i] = (int)sum;
            }

            int max_x = hist_x.Max();
            int max_x_index = hist_x.ToList().IndexOf(max_x);

            int thresh_val_x = 80000;
            List<int> list_x = hist_x.ToList<int>();

            //lọc các cột lấy phần có tổng giá trị pixel > ngưỡng (chứa 2 vân tay)
            int[] pack_x = list_x.Select((v, i) => new { v, i }).Where(x => x.v > thresh_val_x).Select(x => x.i).ToArray(); //lấy index chứ k lấy value

            List<List<int>> arr_good_x = new List<List<int>>();//chứa tất cả các cột > ngưỡng
            List<int> g_x = new List<int>();//list tạm thời dùng trong vòng for ở dưới
            for (int i = 0; i < pack_x.Length-1; i++)
            {
                if ((pack_x[i+1]-pack_x[i])==1)//nếu liền kề thì để vào 1 list
                {
                    g_x.Add(pack_x[i + 1]);
                }
                else//tách đc hết các pixel liền kề vào 1 list
                {
                    arr_good_x.Add(g_x);
                    g_x = new List<int>();
                }

                if(i == (pack_x.Length-2))//trong trường hợp pixel liền kề đến cuối mảng
                {
                    arr_good_x.Add(g_x);
                }
                    
            }

            List<int> slice_x = new List<int>();
            foreach (List<int> arr in arr_good_x)
            {
                if(arr.Contains(max_x_index)) //list nào có chứa max_index thì chứa vân tay
                {
                    slice_x = arr;
                }
            }


            int start_x = slice_x.First();
            int stop_x = slice_x.Last();

            Rectangle roi = new Rectangle(start_x, 0, stop_x - start_x, h);

            Image<Gray, byte> crop_x = new Image<Gray, byte>(w, h);
            Image<Gray, byte> small = morp.Copy(roi);

            crop_x.ROI = roi;
            CvInvoke.cvCopy(small, crop_x, IntPtr.Zero); // xóa phần ko nằm trong start_x->start_y

            crop_x.ROI = Rectangle.Empty; 
            //pictureBoxMorp.Image = crop_x.Bitmap;


            //Y axis
            int[] hist_y = new int[h];

            for (int i = 0; i < h; i++)
            {
                double sum = 0;
                for (int j = 0; j < w; j++)
                {
                    sum = sum + crop_x[i, j].Intensity;

                }
                hist_y[i] = (int)sum;
            }

            int max_y = hist_y.Max();
            //int max_y_index = hist_y.ToList().IndexOf(max_y);

            int thresh_val_y = 20000;
            List<int> list_y = hist_y.ToList<int>();
            int[] pack_y = list_y.Select((v, i) => new { v, i }).Where(y => y.v > thresh_val_y).Select(y => y.i).ToArray();

            List<List<int>> arr_good_y = new List<List<int>>();
            List<int> g_y = new List<int>();
            for (int i = 0; i < pack_y.Length - 1; i++)
            {
                if ((pack_y[i + 1] - pack_y[i]) == 1)
                {
                    g_y.Add(pack_y[i + 1]);

                }
                else
                {
                    arr_good_y.Add(g_y);
                    g_y = new List<int>();
                }

                if (i == (pack_y.Length - 2))
                {
                    arr_good_y.Add(g_y);
                }
            }

            List<List<int>> slice_y = new List<List<int>>();
            List<int> del_y = new List<int>();
            foreach (List<int> arr in arr_good_y)
            {
                if (arr.Count > 100 && !(arr.Contains(0)||arr.Contains(h-1)))//điều kiện lấy 2 vân tay độ dài > 100pixel + ko phải phần gần mép của ảnh 
                {
                    slice_y.Add(arr);
                }
                else if (arr.Contains(1)||arr.Contains(h-1)) //lấy để xóa (hiển thị ra cho vui)
                {
                    del_y = arr;
                }
            }

            Rectangle roi2 = new Rectangle(0, del_y.First(), w, del_y.Last()-del_y.First());

            Image<Gray, byte> crop_y = crop_x.Copy();
            Image<Gray, byte> small2 = new Image<Gray, byte>(w, del_y.Last() - del_y.First());

            crop_y.ROI = roi2;
            CvInvoke.cvCopy(small2, crop_y, IntPtr.Zero); // xóa phần gần mép ảnh

            crop_y.ROI = Rectangle.Empty; 

            // get boxes

            int[] start_y = new int[2];
            int[] stop_y = new int[2];

            List<Rectangle> box = new List<Rectangle>();
            for (int i = 0 ; i < slice_y.Count ; i++)
            {
                start_y[i] = slice_y[i].First();
                stop_y[i] = slice_y[i].Last();
                Rectangle rect =  new Rectangle(start_x,start_y[i],stop_x-start_x,stop_y[i]-start_y[i]);
                box.Add(rect);

                CvInvoke.Rectangle(srcImg, rect, new MCvScalar(0), 2);
            }

            // copy to 416x416 format
            List<Image<Gray, byte>> fingers = new List<Image<Gray,byte>>();

            for (int i = 0; i < 2; i++)
            {
                //Image<Gray, byte> template = new Image<Gray, byte>(416, 416, new Gray(255));
                Image<Gray, byte> finger = src_cpy.Copy(box[i]);

                //Rectangle rec = new Rectangle();
                //if (finger.Width < 416 && finger.Height < 416)
                //{
                //    rec.X = (int)(416 - finger.Width) / 2;
                //    rec.Y = (int)(416 - finger.Height) / 2;
                //    rec.Width = finger.Width;
                //    rec.Height = finger.Height;
                //    template.ROI = rec;
                //    finger.CopyTo(template);
                //    template.ROI = Rectangle.Empty;
                //}

                fingers.Add(finger);
            }


            //rotate finger template
            if (del_y.Contains(h - 1))
            {

                fingers[0] = fingers[0].Rotate(90, new Gray(255));
                fingers[1] = fingers[1].Rotate(90, new Gray(255));
            }
            else if (del_y.Contains(1))
            {
                fingers[0] = fingers[0].Rotate(270, new Gray(255));
                fingers[1] = fingers[1].Rotate(270, new Gray(255));
            }

            //display

            pictureBoxFin1.Image = fingers[0].Bitmap;
            pictureBoxFin2.Image = fingers[1].Bitmap;


            pictureBoxOri.Image = srcImg.Bitmap;
            pictureBoxMorp.Image = crop_y.Bitmap;

            button2.Enabled = true;

        }

        private Image<Gray, byte> preprocess(Image<Gray, byte> input)
        {
            Image<Gray, byte> copy = input.Copy();
            CvInvoke.Blur(copy, copy, new Size(5, 5), new Point(-1, -1));
            CvInvoke.AdaptiveThreshold(copy, copy, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.BinaryInv, 11, 2);
            return copy;
        }

        private Image<Gray, byte> morphologyEx(Image<Gray, byte> input)
        {
            Image<Gray, byte> copy = input.Copy();
            Mat kernel =  CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(copy, copy, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0));
            CvInvoke.Dilate(copy, copy, kernel, new Point(-1, -1), 8, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0));
            CvInvoke.Erode(copy, copy, kernel, new Point(-1, -1), 7, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0));
            return copy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Bitmap Image (.bmp)|*.bmp";
            if(sfd.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    pictureBoxFin1.Image.Save(sfd.FileName + "_left.bmp" , ImageFormat.Bmp);
                    pictureBoxFin2.Image.Save(sfd.FileName + "_right.bmp" , ImageFormat.Bmp);
                    MessageBox.Show("Successfully saved the images");
                }
                catch
                {
                    MessageBox.Show("Error saving images! Try again!");
                }
                    
            }

        }


    }
}

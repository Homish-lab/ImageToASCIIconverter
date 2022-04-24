using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageToASCIIconverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadnew();
        }

        private void loadnew()
        {
            btnConvertToAscii.Enabled = false;
        }

        private string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };
        private string _Content;
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private Bitmap image;
        private void btnConvertToAscii_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                var l = MessageBox.Show("�� �� ������������� ��� �� ����� ��������. \r\n ������ ������� �������� ��� ��������������?", "������",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (l == DialogResult.Yes)
                {
                    openFileDialog1.FileName = "";
                    openFileDialog1.Title = "�������� ����";
                    openFileDialog1.Filter = "��� �����������|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = openFileDialog1.FileName;
                    }
                }
            }
            else
            {
                btnConvertToAscii.Enabled = true;
                btnConvertToAscii.Enabled = false;
                //�������� ����������� � ���������� ����
                image = new Bitmap(txtPath.Text, true);
                //��������� ������ �����������...
                //� ����������� trackBar ��� �������� ������� ���������� / ���������� ��������
                //��� �������� ������ WIDTH "������" � ���������� �������� ���������� �����������
                image = GetReSizedImage(image, this.trackBar.Value);

                //������������ ���������� ����������� � ASCII
                _Content = ConvertToAscii(image);

                //��������� ��������� ������ ����� ������ <pre> , ����� ��������� �� ��������������
                //� ��������� ��� � ���������� ���������
                browserMain.DocumentText = "<pre>" + "<Font size=0>" + _Content + "</Font></pre>";
                btnConvertToAscii.Enabled = true;
            }

        }

        private string ConvertToAscii(Bitmap image)
        {
            Boolean toggle = false;
            StringBuilder sb = new StringBuilder();

            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    Color pixelColor = image.GetPixel(w, h);
                    //���������� ����������� RGB, ����� ����� ����� ����
                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(red, green, blue);

                    //���� ������������, ����� �������������� ���������� �� ������
                    if (!toggle)
                    {
                        int index = (grayColor.R * 10) / 255;
                        sb.Append(_AsciiChars[index]);
                    }
                }
                if (!toggle)
                {
                    sb.Append("<BR>");
                    toggle = true;
                }
                else
                {
                    toggle = false;
                }
            }

            return sb.ToString();
        }

        private Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth)
        {
            int asciiHeight = 0;
            //��������� ����� ������ ����������� �� ��� ������
            asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);
            //������ ����� Bitmap "��������� �����������" � ���������� ��� ����������
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((Image)result);
            //����� ������������ ��������� �������� ����������� �������� ��������
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return result;
        }



        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "�������� ����";
            openFileDialog1.Filter = "��� �����������|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp|JPEG �����������|*.jpg|PNG �����������|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Content != null)
            {
                string x = _Content.Replace("&nbsp;", " ").Replace("<BR>", "\r\n");
                var image2 = new Bitmap(image.Width + 9, image.Height + 11);
                image2 = GetReSizedImage(image2, this.trackBar.Value * 26);
                int c = 46;
                var font = new Font("Consolas", c, FontStyle.Regular, GraphicsUnit.Pixel);
                var graphics = Graphics.FromImage(image2);
                graphics.DrawString(x, font, Brushes.White, new Point(0, 0));
                saveFileDialog1.FileName = "Image_To_ASCII";
                saveFileDialog1.Filter = "��������� ����(*.TXT)|.txt|HTML(*.HTML)|.html|�����������(*.BMP)|*.bmp|�����������(*.JPG)|*.jpg|�����������(*.GIF)|*.gif|�����������(*.PNG)|*.png";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FilterIndex == 1)
                    {
                        try
                        {
                            //���� ������ ��� ���������� HTML
                            //�������� ��� HTML - ������� �� �����������
                            //� ��� linebreaks � CarriageReturn, LineFeed

                            _Content = _Content.Replace("&nbsp;", " ").Replace("<BR>", "\r\n");
                            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                            sw.Write(_Content);
                            sw.Flush();
                            sw.Close();
                        }
                        catch
                        {
                            MessageBox.Show("���������� ��������� ��������� ����", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (saveFileDialog1.FilterIndex == 2)
                    {
                        try
                        {
                            //����������� ��� <pre></pre> ��� ���������� �������������� ��� ��������� ��� � ��������
                            _Content = "<pre>" + _Content + "</pre>";
                            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                            sw.Write(_Content);
                            sw.Flush();
                            sw.Close();
                        }
                        catch
                        {
                            MessageBox.Show("���������� ��������� HTML ��������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            image2.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        catch
                        {
                            MessageBox.Show("���������� ��������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            else
            {
                var l = MessageBox.Show("�� �� ������������� ��� �� ����� ��������. \r\n ������ ������� �������� ��� ��������������?", "������",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (l == DialogResult.Yes)
                {
                    openFileDialog1.FileName = "";
                    openFileDialog1.Title = "�������� ����";
                    openFileDialog1.Filter = "��� �����������|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp|JPEG �����������|*.jpg|PNG �����������|*.png";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = openFileDialog1.FileName;
                    }
                }
            }
        }
    
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 s = new AboutBox1();
            s.ShowDialog();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
        }
    }
}
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
                var l = MessageBox.Show("Вы не преобразовали ещё не одной картинки. \r\n Хотите выбрать картинку для преобразования?", "Ошибка",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (l == DialogResult.Yes)
                {
                    openFileDialog1.FileName = "";
                    openFileDialog1.Title = "Выберите файл";
                    openFileDialog1.Filter = "Все изображения|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp";
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
                //Загрузка изображение с указанного пути
                image = new Bitmap(txtPath.Text, true);
                //Изменение размер изображения...
                //Я использовал trackBar для эмуляции функции увеличения / уменьшения масштаба
                //Это значение задает WIDTH "ШИРИНУ" и количество символов текстового изображения
                image = GetReSizedImage(image, this.trackBar.Value);

                //Преобразуйте измененное изображение в ASCII
                _Content = ConvertToAscii(image);

                //Заключите последнюю строку между тегами <pre> , чтобы сохранить ее форматирование
                //и загрузите его в управление браузером
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
                    //Усреднение компонентов RGB, чтобы найти серый цвет
                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(red, green, blue);

                    //Флаг переключения, чтобы минимизировать растяжение по высоте
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
            //Вычисляем новую высоту изображения по его ширине
            asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);
            //Создаём новое Bitmap "растровое изображение" и определите его разрешение
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((Image)result);
            //Режим интерполяции позволяет получать изображения высокого качества
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return result;
        }



        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите файл";
            openFileDialog1.Filter = "Все изображения|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp|JPEG изображения|*.jpg|PNG изображения|*.png";
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
                saveFileDialog1.Filter = "Текстовый файл(*.TXT)|.txt|HTML(*.HTML)|.html|Изображение(*.BMP)|*.bmp|Изображение(*.JPG)|*.jpg|Изображение(*.GIF)|*.gif|Изображение(*.PNG)|*.png";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FilterIndex == 1)
                    {
                        try
                        {
                            //Если формат для сохранения HTML
                            //Замените все HTML - пробелы на стандартные
                            //и все linebreaks к CarriageReturn, LineFeed

                            _Content = _Content.Replace("&nbsp;", " ").Replace("<BR>", "\r\n");
                            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                            sw.Write(_Content);
                            sw.Flush();
                            sw.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить текстовый файл", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (saveFileDialog1.FilterIndex == 2)
                    {
                        try
                        {
                            //используйте тег <pre></pre> для сохранения форматирования при просмотре его в браузере
                            _Content = "<pre>" + _Content + "</pre>";
                            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                            sw.Write(_Content);
                            sw.Flush();
                            sw.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить HTML страницу", "Ошибка",
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
                            MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            else
            {
                var l = MessageBox.Show("Вы не преобразовали ещё не одной картинки. \r\n Хотите выбрать картинку для преобразования?", "Ошибка",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (l == DialogResult.Yes)
                {
                    openFileDialog1.FileName = "";
                    openFileDialog1.Title = "Выберите файл";
                    openFileDialog1.Filter = "Все изображения|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp|JPEG изображения|*.jpg|PNG изображения|*.png";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = openFileDialog1.FileName;
                    }
                }
            }
        }
    
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 s = new AboutBox1();
            s.ShowDialog();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
        }
    }
}
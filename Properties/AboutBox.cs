using System;
using System.Reflection;
using System.Windows.Forms;

namespace ImageToASCIIconverter
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("О программе {0}", AssemblyTitle);
            this.labelProductName.Text = String.Format("Название продукта: {0}", AssemblyProduct);
            this.labelVersion.Text = String.Format("Версия: {0}", AssemblyVersion);
            this.labelCopyright.Text = String.Format("Авторские права: {0}", AssemblyCopyright);
            this.labelCompanyName.Text = String.Format("Название организации: {0}", AssemblyCompany);
            this.textBoxDescription.Text = String.Format("Описание: {0} {1} {2}", AssemblyDescription, "\r\nТеперь можно сохранить в виде картинки УРАААААААА", "\r\n И да, я не программист", "");
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.yametekudasaicat);
            sp.Play();
            sp.Dispose();
            MessageBox.Show("Шалун зазазазазаззза");
        }
    }
}

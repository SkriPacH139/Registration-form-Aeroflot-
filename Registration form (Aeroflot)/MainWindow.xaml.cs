using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registration_form__Aeroflot_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string,string> cuptchaDict = new Dictionary<string,string>();
        private string cuptchaAnsw;
       
        private void dictInit()
        {
            cuptchaDict.Add("Pages/Resources/Captcha/234546.png", "234546");
            cuptchaDict.Add("Pages/Resources/Captcha/706DE.png", "706DE");
            cuptchaDict.Add("Pages/Resources/Captcha/8P347.png", "8P347");
            cuptchaDict.Add("Pages/Resources/Captcha/GM36I.png", "GM36I");
            cuptchaDict.Add("Pages/Resources/Captcha/ReCAPtCha.png", "ReCAPtCha");
            cuptchaDict.Add("Pages/Resources/Captcha/redsous.png", "redsous");
        }

        private void captchaRand()
        {
            Random random = new Random();
            int randomIndex = random.Next(cuptchaDict.Count);
                       
            BitmapImage bitmapImage = new BitmapImage(new Uri(cuptchaDict.Keys.ElementAt(randomIndex), UriKind.RelativeOrAbsolute));
            cuptchaImg.Source = bitmapImage;

            cuptchaAnsw=cuptchaDict.Values.ElementAt(randomIndex);
        }

        public MainWindow()
        {
            InitializeComponent();
            dictInit();
            captchaRand();
        }

        private void regBut_Click(object sender, RoutedEventArgs e)
        {
            if (cuptchaAnsTB.Text == cuptchaAnsw)
            {
                MessageBox.Show("Капча введена правильно!");
                cuptchaAnsTB.Text = "";
            }
            else
            {
                MessageBox.Show("Капча введена неправильно!");
                cuptchaAnsTB.Text = "";
            }
            captchaRand();
        }
    }
}

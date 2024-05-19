using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Registration_form__Aeroflot_.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public List<string> countryPhoneCod = new List<string>() 
        {   "+61",
            "+54",
            "+55",
            "+91",
            "+62",
            "+1",
            "+86",
            "+52",
            "+7",
            "+1"
        };

        private string charactersPassword = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+=-`~|}{[]:;?><,./";

        public RegPage()
        {
            InitializeComponent(); 
         
        }

        private void loadStack(StackPanel stack, RowDefinition[] rows, Button but )
        {          

            stack.Width = stack.Width == 0 ? RegFrame.ActualWidth : 0;

            if (stack.Width == 0)
            {
                

                but.Content = "▲";

                foreach (RowDefinition row in rows){
                    
                    row.Height = new GridLength(0);
                }
               
            }

            else
            {                
                but.Content = "▼";

                foreach (RowDefinition row in rows)
                {
                    row.Height = GridLength.Auto;
                }               
            }
        }
             

        private void openCardStackBut_Click(object sender, RoutedEventArgs e)
        {
            
            loadStack(cardStack, new RowDefinition[5] { CardGrd1, CardGrd2, CardGrd3, CardGrd4, CardGrd5 }, arrCardBut);
        }

        private void arrCardBut_Click(object sender, RoutedEventArgs e)
        {
            
            loadStack(cardStack, new RowDefinition[5] { CardGrd1, CardGrd2, CardGrd3, CardGrd4, CardGrd5 }, arrCardBut);
        }

        private void openPersDataStackBut_Click(object sender, RoutedEventArgs e)
        {
           
            loadStack(persDataStack, new RowDefinition[5] { PersDataGrd1, PersDataGrd2, PersDataGrd3, PersDataGrd4, PersDataGrd5 }, arrPersDataBut);
        }

        private void arrPersDataBut_Click(object sender, RoutedEventArgs e)
        {
            
            loadStack(persDataStack, new RowDefinition[5] { PersDataGrd1, PersDataGrd2, PersDataGrd3, PersDataGrd4, PersDataGrd5 }, arrPersDataBut);
        }

        private void openPassportStackBut_Click(object sender, RoutedEventArgs e)
        {
            
            loadStack(passportStack, new RowDefinition[5] { PassportGrd1, PassportGrd2, PassportGrd3, PassportGrd4, PassportGrd5 }, arrPassportDataBut);
        }

        private void arrPassportDataBut_Click(object sender, RoutedEventArgs e)
        {
            
            loadStack(passportStack, new RowDefinition[5] { PassportGrd1, PassportGrd2, PassportGrd3, PassportGrd4, PassportGrd5 }, arrPassportDataBut);
        }

        private void addMorePassportBut_Click(object sender, RoutedEventArgs e)
        {
            addMorePassportBut.Visibility = Visibility.Hidden;

            documentTypeLab.Visibility = Visibility.Visible;
            documentTypeCB.Visibility = Visibility.Visible;

            countryLab.Visibility = Visibility.Visible;
            countryCB.Visibility = Visibility.Visible;

            seriesNumberLab.Visibility = Visibility.Visible;
            seriesNumberTB.Visibility = Visibility.Visible;

            addPassportLab.Visibility = Visibility.Visible;
            addPassportDP.Visibility = Visibility.Visible;

            indefinitelyBut.Visibility = Visibility.Visible;

            CansAddPassport.Visibility = Visibility.Visible;

          
        }

        private void CansAddPassport_Click(object sender, RoutedEventArgs e)
        {
            documentTypeLab.Visibility = Visibility.Hidden;
            documentTypeCB.Visibility = Visibility.Hidden;

            countryLab.Visibility = Visibility.Hidden;
            countryCB.Visibility = Visibility.Hidden;

            seriesNumberLab.Visibility = Visibility.Hidden;
            seriesNumberTB.Visibility = Visibility.Hidden;

            addPassportLab.Visibility = Visibility.Hidden;
            addPassportDP.Visibility = Visibility.Hidden;

            indefinitelyBut.Visibility = Visibility.Hidden;

            CansAddPassport.Visibility = Visibility.Hidden;


            addMorePassportBut.Visibility = Visibility.Visible;          

        }

        private void hyperButPass_Click(object sender, RoutedEventArgs e)
        {
            hyperButPass.Content = (string)hyperButPass.Content == "Бессрочно" ? "Указать срок" : "Бессрочно";

            passportDP.IsEnabled = (string)hyperButPass.Content == "Бессрочно" ? true : false;
        }

        private void indefinitelyBut_Click(object sender, RoutedEventArgs e)
        {

            indefinitelyBut.Content = (string)indefinitelyBut.Content == "Бессрочно" ? "Указать срок" : "Бессрочно";

            addPassportDP.IsEnabled = (string)indefinitelyBut.Content == "Бессрочно" ? true : false;
        }

        private void countryPhoneCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (countryPhoneTB != null)            
                countryPhoneTB.Text = countryPhoneCod[countryPhoneCB.SelectedIndex];
            
        }


        private void placeholdVisability(TextBlock tblItem, TextBox tbItem = null, PasswordBox pbItem = null)
        {
            if (tbItem == null && pbItem == null)
                tblItem.Visibility = Visibility.Hidden;

            else if (tbItem == null)            
                tblItem.Visibility = pbItem.Password == "" ? Visibility.Visible : Visibility.Hidden;               
            
            else
                tblItem.Visibility = tbItem.Text == "" ? Visibility.Visible : Visibility.Hidden;
            
        }

        private void emailTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(emailTBL);
        }

        private void emailTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(emailTBL,emailTB);
        }

        private void surnameTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(surnameTBL);
        }

        private void surnameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(surnameTBL, surnameTB);
        }

        private void nameTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(nameTBL);
        }

        private void nameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(nameTBL, nameTB);
        }

        private void passwordPB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(passwordTBL);
        }

        private void passwordPB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(passwordTBL, null, passwordPB);
        }

        private void repeatPasswordPB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(repeatPasswordTBL);
        }

        private void repeatPasswordPB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(repeatPasswordTBL, null, repeatPasswordPB);
        }

        private void answerToQuestionTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(answerToQuestionTBL);
        }

        private void answerToQuestionTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(answerToQuestionTBL, answerToQuestionTB);
        }

        private void extraNameTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(extraNameTBL);
        }

        private void extraNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(extraNameTBL, extraNameTB);
        }

        private void extraSurnameTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(extraSurnameTBL);
        }

        private void extraSurnameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(extraSurnameTBL, extraSurnameTB);
        }

        private void patronymicTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(patronymicTBL);
        }

        private void patronymicTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(patronymicTBL, patronymicTB);
        }

        private void passwordTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(passwordTBL);
        }

        private void passwordTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(passwordTBL, passwordTB);
        }

        private void repeatPasswordTB_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(repeatPasswordTBL);
        }

        private void repeatPasswordTB_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholdVisability(repeatPasswordTBL, repeatPasswordTB);
        }


        private void passwordPB_KeyDown(object sender, KeyEventArgs e)
        {
            showPasswordBUT.IsEnabled = true;
            showPasswordBUT.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x4A, 0x90, 0xE2));
        }

        private void repeatPasswordPB_KeyDown(object sender, KeyEventArgs e)
        {
            showRepeatPasswordBUT.IsEnabled = true;
            showRepeatPasswordBUT.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x4A, 0x90, 0xE2));
        }

        private void showPasswordBUT_Click(object sender, RoutedEventArgs e)
        {
            if ((string)showPasswordBUT.Content=="Показать")
            {
                showPasswordBUT.Content = "Скрыть";     
                passwordTB.Text=passwordPB.Password.ToString();

                passwordPB.Visibility = Visibility.Hidden;
                passwordTB.Visibility = Visibility.Visible;
            }
            else
            {
                showPasswordBUT.Content = "Показать";
                passwordPB.Password = passwordTB.Text;

                passwordTB.Visibility = Visibility.Hidden;
                passwordPB.Visibility = Visibility.Visible;
                
            }
            
        }

        private void showRepeatPasswordBUT_Click(object sender, RoutedEventArgs e)
        {
            if ((string)showRepeatPasswordBUT.Content == "Показать")
            {
                showRepeatPasswordBUT.Content = "Скрыть";
                repeatPasswordTB.Text = repeatPasswordPB.Password.ToString();

                repeatPasswordPB.Visibility = Visibility.Hidden;
                repeatPasswordTB.Visibility = Visibility.Visible;
            }
            else
            {
                showRepeatPasswordBUT.Content = "Показать";
                repeatPasswordPB.Password = repeatPasswordTB.Text;

                repeatPasswordTB.Visibility = Visibility.Hidden;
                repeatPasswordPB.Visibility = Visibility.Visible;

            }
        }

        private void generatePasswordBut_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string randomPasswordString = "";
            int randomLength = new Random().Next(8, 21);


            for (int i = 0; i < randomLength; i++)
            {
                int randomIndex = random.Next(0, charactersPassword.Length);
                randomPasswordString += charactersPassword[randomIndex];
            }

            passwordTB.Text = randomPasswordString;
            repeatPasswordTB.Text = randomPasswordString;

            showPasswordBUT.IsEnabled = true;
            showPasswordBUT.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x4A, 0x90, 0xE2));

            showRepeatPasswordBUT.IsEnabled = true;
            showRepeatPasswordBUT.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x4A, 0x90, 0xE2));

            showRepeatPasswordBUT.Content = "Скрыть";
            showPasswordBUT.Content = "Скрыть";

            passwordTBL.Visibility = Visibility.Hidden;
            repeatPasswordTBL.Visibility = Visibility.Hidden;

            passwordPB.Visibility = Visibility.Hidden;
            repeatPasswordPB.Visibility = Visibility.Hidden;

            passwordTB.Visibility = Visibility.Visible;
            repeatPasswordTB.Visibility = Visibility.Visible;

        }

        private void countryPhoneTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) && e.Text[0] != '+') 
                e.Handled = true;
            else if (countryPhoneTB.Text.Length + e.Text.Length > 12) 
                e.Handled = true;
            else if (e.Text == "+" && countryPhoneTB.Text.Contains("+"))
                e.Handled = true;
        }
    }
}

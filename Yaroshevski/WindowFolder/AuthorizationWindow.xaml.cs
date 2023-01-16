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
using System.Windows.Shapes;
using Yaroshevski.ClassFolder;
using Yaroshevski.DataFolder;

namespace Yaroshevski.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(LoginTb.Text))
                {
                    MBClass.ErrorMB("Введите логин");
                    LoginTb.Focus();
                }
                if (string.IsNullOrEmpty(PasswordPsb.Password))
                {
                    MBClass.ErrorMB("Введите пароль");
                    PasswordPsb.Focus();
                }
                else
                {
                    try
                    {
                        var user = DBEntities.GetContext().User.FirstOrDefault
                            (u => u.Login == LoginTb.Text);
                        if (user == null)
                        {
                            MBClass.ErrorMB("Пользователь не найден");
                            LoginTb.Focus();
                            return;
                        }
                        if (user.Password != PasswordPsb.Password)
                        {
                            MBClass.ErrorMB("Введен не правильный пароль");
                            PasswordPsb.Focus();
                            return;
                        }
                        else
                        {
                            switch (user.IdRole)
                            {
                                case 1:
                                    MBClass.InformationMB("Вы зашли под админом");
                                    this.Close();
                                    break;
                                case 2:
                                    MBClass.InformationMB("Вы зашли под юзером");
                                    this.Close();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MBClass.ErrorMB(ex);
                    }
                }
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().ShowDialog();
        }
    }
}

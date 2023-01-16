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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }
            else if (DBEntities.GetContext()
                .User.FirstOrDefault(
                u => u.Login == LoginTb.Text) != null)
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPsb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(RepeatPasswordPsb.Password))
            {
                MBClass.ErrorMB("Введите повторно пароль");
                RepeatPasswordPsb.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().User.Add(new User()
                    {
                        Login=LoginTb.Text,
                        Password=PasswordPsb.Password,
                        IdRole=4
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Пользователь успешно зарегестрирован");
        }
                catch
                {
                   
                }
            }
}

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

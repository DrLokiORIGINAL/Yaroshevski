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
using Yaroshevski.PageFolder;

namespace Yaroshevski.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.ListPage());
            MaiFrame.Navigate(new PageFolder.AddPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void AddAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new AddPage());
        }

        private void ListAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListPage());
        }
    }
}

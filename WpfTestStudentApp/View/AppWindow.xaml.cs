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
using WpfTestStudentApp.Service;
using WpfTestStudentApp.View.Login;
using WpfTestStudentApp.View.Student;
using WpfTestStudentApp.View.Teacher;

namespace WpfTestStudentApp.View
{
    /// <summary>
    /// Логика взаимодействия для AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            PageManager.Frame = MainFrame;
            if (Session.Student == null)
            {
                AdminPanel.Visibility = Visibility.Visible;
                StudentPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Collapsed;
                StudentPanel.Visibility = Visibility.Visible;
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = Session.UserName;
        }

        private void LeaveClick(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void TeacherTestClick(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new TestIndexPage());
        }

        private void TeacherTestResultClick(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new ResultPage());
        }

        private void StudentTestClick(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new TestsPage());
        }
    }
}

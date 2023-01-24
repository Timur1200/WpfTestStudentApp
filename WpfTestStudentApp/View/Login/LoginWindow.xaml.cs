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
using WpfTestStudentApp.Model;
using WpfTestStudentApp.Service;

namespace WpfTestStudentApp.View.Login
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
           var students = StudentTestEntities.GetContext().Student.ToList();
            if (TBoxPhone.Text == "1" && PassBox.Password == "1")
            {
                Session.Student = null;
                AppWindow appWindow = new AppWindow();
                appWindow.Show();
                this.Close();
                return;
            }
            foreach (var item in students)
            {
               
                if (TBoxPhone.Text == item.Phone && PassBox.Password == item.Password)
                {
                    Session.Student = item;
                    AppWindow appWindow = new AppWindow();
                    appWindow.Show();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Неверно введен логин или пароль!");
        }
    }
}

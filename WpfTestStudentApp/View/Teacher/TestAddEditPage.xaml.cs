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
using WpfTestStudentApp.Model;
using WpfTestStudentApp.Service;

namespace WpfTestStudentApp.View.Teacher
{
    /// <summary>
    /// Логика взаимодействия для TestAddEditPage.xaml
    /// </summary>
    public partial class TestAddEditPage : Page
    {
        public TestAddEditPage(Test test)
        {
            InitializeComponent();
            if (test == null)
            {
                _test = new Test();
            }
            else
            {
                _test = test;
            }
            DataContext = _test;
        }
        Test _test { get; set; }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_test.Name) ||  _test.Amount <=0 ) 
            {
                MessageBox.Show("Поля необходимо заполнить");
                return;
            }
            if (_test.Id == 0)
            {
                StudentTestEntities.GetContext().Test.Add(_test);
            }
            StudentTestEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
            PageManager.Back();
        }
    }
}

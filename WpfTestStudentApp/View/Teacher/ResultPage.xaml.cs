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

namespace WpfTestStudentApp.View.Teacher
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
            
           
        }
        List<TestResult> testResult;
        private void ReloadClick(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = testResult;
        }

        private void TypeComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Select();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Select();
        }

        private void Select()
        {
            var a = testResult;
            if (TypeComBox.SelectedItem != null)
            {
                Test test = TypeComBox.SelectedItem as Test; 
                a = a.Where(q=>q.Test.Id == test.Id).ToList();
            }
            string text = SearchTextBox.Text;
            if (string.IsNullOrEmpty(text))
            {
                a = a.Where(q=>q.Student.FullName.ToLower().Contains(text.ToLower())).ToList();
            }
            DGridClient.ItemsSource = a;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            testResult = StudentTestEntities.GetContext().TestResult.ToList();
            TypeComBox.ItemsSource = StudentTestEntities.GetContext().Test.ToList();
            DGridClient.ItemsSource = testResult;
           
        }

      
    }
}

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
    /// Логика взаимодействия для TestIndexPage.xaml
    /// </summary>
    public partial class TestIndexPage : Page
    {
        public TestIndexPage()
        {
            InitializeComponent();
        }
        private List<Test> _tests;
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            _tests = StudentTestEntities.GetContext().Test.ToList();
            DGridClient.ItemsSource = _tests;
        }
        

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new TestAddEditPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            Test t = DGridClient.SelectedItem as Test;
            PageManager.Frame.Navigate(new TestAddEditPage(t));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = SearchTextBox.Text;
            if (text.Length == 0)
            {
                DGridClient.ItemsSource = _tests;
                
            }
            else
            {
                DGridClient.ItemsSource = _tests.Where(q=>q.Name.ToLower().Contains(text.ToLower())).ToList();
            }
        }

        private void DetalTestClick(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new TestDetalPage(DGridClient.SelectedItem as Test));
        }
    }
}

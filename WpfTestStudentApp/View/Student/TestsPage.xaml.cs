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

namespace WpfTestStudentApp.View.Student
{
    /// <summary>
    /// Логика взаимодействия для TestsPage.xaml
    /// </summary>
    public partial class TestsPage : Page
    {
        public TestsPage()
        {
            InitializeComponent();
            thisPage = this;
        }
        private List<Test> _tests;
        public static TestsPage thisPage;
        public static void Load()
        {
            thisPage.PageLoaded(null, null);
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            _tests = StudentTestEntities.GetContext().Test.ToList();
            DGridClient.ItemsSource = _tests;
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
                DGridClient.ItemsSource = _tests.Where(q => q.Name.ToLower().Contains(text.ToLower())).ToList();
            }
        }

        private void GoTestClick(object sender, RoutedEventArgs e)
        {
            RunningTestsWindow r = new RunningTestsWindow(DGridClient.SelectedItem as Test);
            r.ShowDialog();
        }
    }
}

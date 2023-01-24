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
    /// Логика взаимодействия для TestDetalPage.xaml
    /// </summary>
    public partial class TestDetalPage : Page
    {
        public TestDetalPage(Test t)
        {
            InitializeComponent();
            _test = t;
           
        }
        Test _test { get; set; }
        Question _question { get; set; }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            LBoxQuestion.ItemsSource = StudentTestEntities.GetContext().Question.Where(q=>q.TestId == _test.Id).ToList();
            _question = new Question {TestId = _test.Id };
            DataContext = _question;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageLoaded(null, null);
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (LBoxQuestion.SelectedItem == null) return;
            Question q = LBoxQuestion.SelectedItem as Question;
            StudentTestEntities.GetContext().Question.Remove(q);
            StudentTestEntities.GetContext().SaveChanges();
            PageLoaded(null, null);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_question.Id == 0)
            {
                StudentTestEntities.GetContext().Question.Add(_question);
            }
            StudentTestEntities.GetContext().SaveChanges();
            PageLoaded(null, null);
            if (CheckBoxNoSelectAns.IsChecked.Value)
            {
                AnsPanel.IsEnabled = false;
            }
            else
            {
                AnsPanel.IsEnabled = true;
            }
        }

        private void LBoxQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBoxQuestion.SelectedItem == null)
            {
                return;
            }
            DataContext = LBoxQuestion.SelectedItem as Question;
            _question = LBoxQuestion.SelectedItem as Question;
            if (CheckBoxNoSelectAns.IsChecked.Value)
            {
                AnsPanel.IsEnabled = false;
            }
            else
            {
                AnsPanel.IsEnabled = true;
            }
        }

        private void CheckBoxNoSelectAns_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxNoSelectAns.IsChecked.Value)
            {
                AnsPanel.IsEnabled = false;
            }
            else
            {
                AnsPanel.IsEnabled = true;
            }
        }
    }
}

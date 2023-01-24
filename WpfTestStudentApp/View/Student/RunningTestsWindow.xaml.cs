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

namespace WpfTestStudentApp.View.Student
{
    /// <summary>
    /// Логика взаимодействия для RunningTestsWindow.xaml
    /// </summary>
    public partial class RunningTestsWindow : Window
    {
        public RunningTestsWindow(Test test)
        {
            InitializeComponent();
            _test = test;
            _Allquestions = StudentTestEntities.GetContext().Question.Where(q=>q.TestId== test.Id).ToList();
            if (_Allquestions.Count < _test.Amount)
            {
                MessageBox.Show("Тест еще не доступен!");
                this.Close();
                return;
            }
            else if (_Allquestions.Count == _test.Amount)
            {
                _CurrentQuestions = _Allquestions;
            }
            else
            {
                var random = new Random();
                _CurrentQuestions = _Allquestions.OrderBy(q => random.Next()).Take(test.Amount.Value).ToList();
            }
           
            Start();

        }
        Test _test;
        List<Question> _Allquestions;
        List<Question> _CurrentQuestions;
        int i = 1;
        int right = 0;
        Question _thisQuestion;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Start()
        {
            TBoxInfo.Text = $"Вопросов {i} из {_test.Amount}";
            Question q = _CurrentQuestions[i-1];
            TBoxQuestion.Text = q.Title;
            if (q.IsMulti)
            {
                checkBoxPanel.Visibility = Visibility.Visible;
                radioBtnPanel.Visibility = Visibility.Collapsed;
                TBoxAns.Visibility = Visibility.Collapsed;
                cBox1.Content = q.Ans1;
                cBox2.Content = q.Ans2;
                cBox3.Content = q.Ans3;
                cBox4.Content = q.Ans4;
                cBox5.Content = q.Ans5;
            }
            else if (q.IsTextAns)
            {
                checkBoxPanel.Visibility = Visibility.Collapsed;
                radioBtnPanel.Visibility = Visibility.Collapsed;
                TBoxAns.Visibility = Visibility.Visible;
            }
            else
            {
                checkBoxPanel.Visibility = Visibility.Collapsed;
                radioBtnPanel.Visibility = Visibility.Visible;
                TBoxAns.Visibility = Visibility.Collapsed;
                rBtn1.Content = q.Ans1;
                rBtn2.Content = q.Ans2;
                rBtn3.Content = q.Ans3;
                rBtn4.Content = q.Ans4;
                rBtn5.Content = q.Ans5;
            }
            _thisQuestion = q;
           
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            Question q = _thisQuestion;
            
            if (q.IsMulti)
            {
                bool a1=false, a2=false, a3 = false, a4 = false, a5 = false;
                foreach (var item in q.Ans)
                {
                    if (item == '1') a1 = true;
                    if (item == '2') a2 = true;
                    if (item == '3') a3 = true;
                    if (item == '4') a4 = true;
                    if (item == '5') a5 = true;
                }
                if (a1 == cBox1.IsChecked && a2 == cBox2.IsChecked && a3 == cBox3.IsChecked && a4 == cBox4.IsChecked && a5 == cBox5.IsChecked)
                {
                    right += 1;
                }
                cBox1.IsChecked = false; cBox2.IsChecked = false; cBox3.IsChecked=false; cBox4.IsChecked = false;cBox5.IsChecked = false;
            }
            else if (q.IsTextAns)
            {
                if (q.Ans.ToLower() == TBoxAns.Text.ToLower())
                {
                    right+= 1;
                }
                TBoxAns.Text = "";
            }
            else
            {
                bool a1 = false, a2 = false, a3 = false, a4 = false, a5 = false;
                foreach (var item in q.Ans)
                {
                    if (item == '1') a1 = true;
                    if (item == '2') a2 = true;
                    if (item == '3') a3 = true;
                    if (item == '4') a4 = true;
                    if (item == '5') a5 = true;
                }
                if (a1 == rBtn1.IsChecked && a2 == rBtn2.IsChecked && a3 == rBtn3.IsChecked && a4 == rBtn4.IsChecked && a5 == rBtn5.IsChecked)
                {
                    right += 1;
                }
                rBtn1.IsChecked = false; rBtn2.IsChecked = false ; rBtn3.IsChecked = false ;rBtn4.IsChecked = false; rBtn5.IsChecked = false;
            }
            
           
            if (i == _test.Amount )
            {
                double bals = (double)right / (double)i * 100;
                bals  = Math.Round(bals, 2);
                MessageBox.Show($"Тест завершен у вас {right} правильных ответов из {i}. ", $"{bals}%");
                TestResult testResult = new TestResult
                {
                    Date = DateTime.Now,
                    Test = _test,
                    Student = Session.Student,
                    CorrectAnswer = right,
                    Result = bals,
                };
                StudentTestEntities.GetContext().TestResult.Add(testResult);
                StudentTestEntities.GetContext().SaveChanges();
                TestsPage.Load();
                this.Close();
                return;
            }
            i = i + 1;
            Start();
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestStudentApp.Service;

namespace WpfTestStudentApp.Model
{
    partial class StudentTestEntities
    {
        private static StudentTestEntities _context;

        public static StudentTestEntities GetContext()
        {
            if (_context == null) _context = new StudentTestEntities();
            return _context;
        }
    }

    partial class Test
    {

        public string BestResult
        {
            get
            {
                var a = StudentTestEntities.GetContext().TestResult.Where(q=>q.StudentId==Session.Student.Id && q.TestId == this.Id).OrderByDescending(q=>q.Result).FirstOrDefault();
                if (a == null) return "Тест не пройден";
                return $"{a.CorrectAnswer}/{this.Amount} ({a.Result}%)";
            }
        }
        public string Result
        {
            get
            {
                var a = StudentTestEntities.GetContext().TestResult.Where(q => q.StudentId == Session.Student.Id && q.TestId == this.Id).OrderBy(q => q.Date).FirstOrDefault();
                if (a == null) return "Тест не пройден";
                return $"{a.CorrectAnswer}/{this.Amount} ({a.Result}%)";
            }
        }
    }

   partial class Student
    {
        public string Fio
        {
            get
            {
                return FullName;
            }
        }
    }

    partial class Test
    {
        public int AllQuestion
        {
            get
            {
                var a = StudentTestEntities.GetContext().Question.Where(q => q.TestId == this.Id).Count();
                return a;
            }
        }
    }
}

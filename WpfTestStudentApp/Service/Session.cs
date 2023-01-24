using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestStudentApp.Model;

namespace WpfTestStudentApp.Service
{
    internal class Session
    {
        public static Student Student { get; set; }
        public static string UserName
        {
            get
            {   if (Student == null) return " ";
                //return $"{Student.Surname} {Student.Name} {Student.Patronymic}";
                return Student.FullName;
            }
        }
    }
}

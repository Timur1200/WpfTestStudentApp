using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTestStudentApp.Service
{
    internal class PageManager
    {
        public static Frame Frame { get; set; }
        public static void Back()
        {
            if (Frame.CanGoBack) Frame.NavigationService.GoBack();
        }
      
    }
}

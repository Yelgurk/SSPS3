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

namespace GUI_WPF_Demo
{
    /// <summary>
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : UserControl
    {
        IWindowContentService _windowContentService;

        public SecondPage(IWindowContentService windowContentService)
        {
            _windowContentService = windowContentService;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _windowContentService.Set<FirstPage>();
        }
    }
}

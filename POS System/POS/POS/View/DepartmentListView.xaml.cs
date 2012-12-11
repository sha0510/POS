using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using POS.Util;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for DepartmentListView.xaml
    /// </summary>
    public partial class DepartmentListView : UserControl
    {
        public DepartmentListView()
        {
            InitializeComponent();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new DepartmentView());
        }
    }
}

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

namespace LabaBA1
{
    /// <summary>
    /// Логика взаимодействия для UnitazasTypes.xaml
    /// </summary>
    public partial class UnitazasTypes : Page
    {
        private Laba1Entities1 Laba1Entities1 = new Laba1Entities1();
        public UnitazasTypes()
        {
            InitializeComponent();
            datygridy.IsReadOnly = true;
            datygridy.ItemsSource = Laba1Entities1.UnitazTypes.ToList();
        }
    }
}

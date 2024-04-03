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
            FiltrCbox.ItemsSource = Laba1Entities1.UnitazTypes.ToList();
            FiltrCbox.DisplayMemberPath = "UnitazType";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datygridy.ItemsSource = Laba1Entities1.UnitazTypes.ToList().Where(item => item.UnitazType.Contains(SearchTbox.Text));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FiltrCbox.SelectedItem != null)
            {
                var selected = FiltrCbox.SelectedItem as UnitazTypes;
                datygridy.ItemsSource = Laba1Entities1.UnitazTypes.ToList().Where(item => item.UnitazType == selected.UnitazType);
            }
        }

        private void ClearBtm_Click(object sender, RoutedEventArgs e)
        {
            datygridy.ItemsSource = Laba1Entities1.UnitazTypes.ToList();
        }
    }
}

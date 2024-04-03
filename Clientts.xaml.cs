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
    /// Логика взаимодействия для Clientts.xaml
    /// </summary>
    public partial class Clientts : Page
    {
        private Laba1Entities1 Laba1Entities1 = new Laba1Entities1();
        public Clientts()
        {
            InitializeComponent();
            datygridy.IsReadOnly = true;
            datygridy.ItemsSource = Laba1Entities1.Clients.ToList();
            FiltrCbox.ItemsSource = Laba1Entities1.Clients.ToList();
            FiltrCbox.DisplayMemberPath = "ClientName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datygridy.ItemsSource = Laba1Entities1.Clients.ToList().Where(item => item.ClientName.Contains(SearchTbox.Text));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FiltrCbox.SelectedItem != null)
            {
                var selected = FiltrCbox.SelectedItem as Clients;
                datygridy.ItemsSource = Laba1Entities1.Clients.ToList().Where(item => item.ClientName == selected.ClientName);
            }
        }

        private void ClearBtm_Click(object sender, RoutedEventArgs e)
        {
            datygridy.ItemsSource = Laba1Entities1.Clients.ToList();
        }
    }
}

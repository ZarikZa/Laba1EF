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
        }
        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Laba1Entities1.Clients.Remove(datygridy.SelectedItem as Clients);
                Laba1Entities1.SaveChanges();
                datygridy.ItemsSource =  Laba1Entities1.Clients.ToList();

            }
            catch (Exception)
            {
                MessageBox.Show("Нельзя удалить, соrrи");
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (NameTbox.Text != "")
            {
            Clients clients = new Clients();
            clients.ClientName = NameTbox.Text;
            clients.ClientSurname = SurnameTbox.Text;
            clients.ClientMiddleName = MiddleNameTbox.Text;
            Laba1Entities1.Clients.Add(clients);
            Laba1Entities1.SaveChanges();
            datygridy.ItemsSource =  Laba1Entities1.Clients.ToList();
            }
        }

        private void datygridy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cheged = datygridy.SelectedItem as Clients ?? new Clients();

            NameTbox.Text = cheged.ClientName;
            SurnameTbox.Text = cheged.ClientSurname;
            MiddleNameTbox.Text = cheged.ClientMiddleName;
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (NameTbox.Text != "")
            {
                try
                {
                    var selected = datygridy.SelectedItem as Clients;
                    selected.ClientName = NameTbox.Text;
                    selected.ClientSurname = SurnameTbox.Text;
                    selected.ClientMiddleName = MiddleNameTbox.Text;

                    Laba1Entities1.SaveChanges();
                    datygridy.ItemsSource =  Laba1Entities1.Clients.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Такое имя уже существует");
                }
            }
        }
    }
}

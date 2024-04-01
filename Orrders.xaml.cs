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
    /// Логика взаимодействия для Orrders.xaml
    /// </summary>
    public partial class Orrders : Page
    {
        private Laba1Entities1 Laba1Entities1 = new Laba1Entities1();
        public Orrders()
        {
            InitializeComponent();
            datygridy.IsReadOnly = true;
            datygridy.ItemsSource = Laba1Entities1.Orders.ToList();
        }
        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Laba1Entities1.Orders.Remove(datygridy.SelectedItem as Orders);
                Laba1Entities1.SaveChanges();
                datygridy.ItemsSource =  Laba1Entities1.Orders.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Нельзя удалить, соrrи");
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (ID_ClientTbox.Text != "")
            {
                try
                {
                    Orders orders = new Orders();
                    orders.FK_Client = Convert.ToInt32(ID_ClientTbox.Text);
                    orders.FK_Unitaz = Convert.ToInt32(ID_UnitazTbox.Text);
                    Laba1Entities1.Orders.Add(orders);
                    Laba1Entities1.SaveChanges();
                    datygridy.ItemsSource =  Laba1Entities1.Orders.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Указан неверный ID");
                }
            }
        }

        private void datygridy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cheged = datygridy.SelectedItem as Orders ?? new Orders();

            ID_ClientTbox.Text = Convert.ToString(cheged.FK_Client);
            ID_UnitazTbox.Text = Convert.ToString(cheged.FK_Unitaz);
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (ID_ClientTbox.Text != "")
            {
                try
                {
                    var selected = datygridy.SelectedItem as Orders;
                    selected.FK_Client = Convert.ToInt32(ID_ClientTbox.Text);
                    selected.FK_Unitaz = Convert.ToInt32(ID_UnitazTbox.Text);

                    Laba1Entities1.SaveChanges();
                    datygridy.ItemsSource =  Laba1Entities1.Orders.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Такое имя уже существует");
                }
            }
        }
    }
}

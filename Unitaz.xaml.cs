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
    /// Логика взаимодействия для Unitaz.xaml
    /// </summary>
    public partial class Unitaz : Page
    {
        private Laba1Entities1 Laba1Entities1 = new Laba1Entities1();
        public Unitaz()
        {
            InitializeComponent();
            datygridy.IsReadOnly = true;
            datygridy.ItemsSource = Laba1Entities1.Unitazs.ToList();
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Laba1Entities1.Unitazs.Remove(datygridy.SelectedItem as Unitazs);
                Laba1Entities1.SaveChanges();
                datygridy.ItemsSource =  Laba1Entities1.Unitazs.ToList();

            }
            catch (Exception)
            {
                MessageBox.Show("Нельзя удалить, соrrи");
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if(Nazvanie.Text != "")
            {
                try
                {
                    Unitazs unitazTypes = new  Unitazs();
                    unitazTypes.UnitaziName = Nazvanie.Text;
                    unitazTypes.FK_UnitazType = Convert.ToInt32(TypeTbox.Text);
                    unitazTypes.UnitazPrice = Convert.ToDecimal(PriceTbox.Text);
                    Laba1Entities1.Unitazs.Add(unitazTypes);
                    Laba1Entities1.SaveChanges();
                    datygridy.ItemsSource =  Laba1Entities1.Unitazs.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Такое имя уже существует или же указан неверный ID");
                }
            }
        }

        private void datygridy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cheged = datygridy.SelectedItem as Unitazs ?? new Unitazs();

            Nazvanie.Text = cheged.UnitaziName;
            TypeTbox.Text = Convert.ToString(cheged.FK_UnitazType);
            PriceTbox.Text = Convert.ToString(cheged.UnitazPrice);
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if(Nazvanie.Text != "")
            {
                try
                {
                    var selected = datygridy.SelectedItem as Unitazs;
                    selected.UnitaziName = Nazvanie.Text;
                    selected.FK_UnitazType = Convert.ToInt32(TypeTbox.Text);
                    selected.UnitazPrice = Convert.ToDecimal(PriceTbox.Text);

                    Laba1Entities1.SaveChanges();
                    datygridy.ItemsSource =  Laba1Entities1.Unitazs.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Такое имя уже существует");
                }
            }
        }
    }
}

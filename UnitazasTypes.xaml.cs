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

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Laba1Entities1.UnitazTypes.Remove(datygridy.SelectedItem as UnitazTypes);
                Laba1Entities1.SaveChanges();
                datygridy.ItemsSource =  Laba1Entities1.UnitazTypes.ToList();

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
                    UnitazTypes unitazTypes = new UnitazTypes();
                    unitazTypes.UnitazType = Nazvanie.Text;

                    Laba1Entities1.UnitazTypes.Add(unitazTypes);
                    Laba1Entities1.SaveChanges();
                    datygridy.ItemsSource =  Laba1Entities1.UnitazTypes.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Такое имя уже существует");
                }
            }
        }

        private void datygridy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cheged = datygridy.SelectedItem as UnitazTypes ?? new UnitazTypes();
            Nazvanie.Text = cheged.UnitazType;
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if(Nazvanie.Text != "")
            {
                try
                {
                    var selected = datygridy.SelectedItem as UnitazTypes;
                    selected.UnitazType = Nazvanie.Text;

                    Laba1Entities1.SaveChanges();
                    datygridy.ItemsSource =  Laba1Entities1.UnitazTypes.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Такое имя уже существует");
                }
            }
        }
    }
}

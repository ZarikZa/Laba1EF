using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Laba1Entities1 Laba1Entities = new Laba1Entities1();

        public MainWindow()
        {
            InitializeComponent();

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source=DESKTOP-H0SNFQR\SQLEXPRESS;Initial Catalog=Laba1;" +
            "Integrated Security=SSPI;Pooling=False";

            sqlConnection.Open();
            DataTable schema = sqlConnection.GetSchema("Tables");
            List<string> TableNames = new List<string>();
            foreach (DataRow row in schema.Rows)
            {
                if (row[3].ToString() == "BASE TABLE" && row[2].ToString() != "sysdiagrams")
                {
                    TableNames.Add(row[2].ToString());
                }
            }
            sqlConnection.Close();
            TableNameComBox.ItemsSource = TableNames;
            TableNameComBox.SelectedIndex = 0;
        }

        private void TableNameComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string NameTable = TableNameComBox.SelectedItem.ToString();
            if (NameTable == "Unitazs")
            {
                OtobrazenieFrame.Content = new Unitaz();
            }
            else if (NameTable == "Clients")
            {
                OtobrazenieFrame.Content = new Clientts();
            }
            else if(NameTable == "Orders")
            {
                OtobrazenieFrame.Content = new Orrders();
            }
            else if( NameTable == "UnitazTypes") 
            {
                OtobrazenieFrame.Content= new UnitazasTypes();
            }
        }
    }
}

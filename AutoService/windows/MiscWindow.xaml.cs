using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;

namespace AutoService.windows
{

    public class Rootobject
    {
        public bool success { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int Num { get; set; }
        public string Adress { get; set; }
        public string Vid { get; set; }
        public int Rast { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для MiscWindow.xaml
    /// </summary>
    public partial class MiscWindow : Window
    {
        public MiscWindow()
        {
            InitializeComponent();
        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RegexButton_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(EmailTextBox.Text, @"^\w+@\w+\.\w{2,}$", RegexOptions.IgnoreCase))
                ResponseTextBox.Text = "валидная почта";
            else
                ResponseTextBox.Text = "НЕ валидная почта";
        }

        private void TryPostButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ClientServise_Click(object sender, RoutedEventArgs e)
        {
            vis.Visibility = Visibility.Visible;
            vis.ItemsSource = КAdEntities.GetContext().ClientService.Where(b =>b.StartTime>=DateTime.Now).ToList();
        }

  

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

          
                int a = ((sender as Button).DataContext as ClientService).ID;
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ACDHUJ98\SQLEXPRESS;Initial Catalog=КAd;Integrated Security=True");
                con.Open();
                string command = "DELETE FROM [dbo].[ClientService] WHERE ID =" + a + "";
                SqlDataAdapter n = new SqlDataAdapter(command, con);
                DataSet ds = new DataSet();
                n.Fill(ds);
                MessageBox.Show("Продукт удален");
                Window_Loaded(null,null);
            }
            catch (Exception)
            {
                MessageBox.Show("Услуга не может быть удалены, т.к она задействована");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vis.ItemsSource = КAdEntities.GetContext().ClientService.ToList();
        }
    }
}

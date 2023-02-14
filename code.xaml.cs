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
using MySql.Data.MySqlClient;

namespace Personal_Diary_System1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Btncreate_Click(object sender, RoutedEventArgs e)
        {
            string Connectstring = "server=localhost;database=dbpersonaldiary;uid=root;Pwd=Dubudahyun28";

            MySqlConnection connection = new MySqlConnection(Connectstring);
            connection.Open();

            MySqlCommand sql = new MySqlCommand("INSERT INTO user (iduser, date, time, User_name, place, story, realization) VALUES (@iduser, @date, @time, @username, @place, @story, @realization)", connection);

            sql.Parameters.AddWithValue("@iduser", txt_usersname.Text);
            sql.Parameters.AddWithValue("@date", txt_year.Text);
            sql.Parameters.AddWithValue("@time", txt_hour.Text);
            sql.Parameters.AddWithValue("@username", txt_userid.Text);
            sql.Parameters.AddWithValue("@place", txt_place.Text);
            sql.Parameters.AddWithValue("@story", txt_story.Text);
            sql.Parameters.AddWithValue("@realization", txt_realization.Text);

            // MySqlCommand sql = new MySqlCommand("INSERT INTO user (iduser, year, month, day, hour, minute, User_name, place) VALUES (" + txt_usersname.Text + ", " + txt_year.Text + ", " + txt_month.Text + ", " + txt_day.Text + ", " + txt_hour.Text + ", " + txt_minute.Text + ", '" + txt_userid.Text + "');", connection);
            // sql.ExecuteNonQuery();
            // , place, story, realization ?? txt_place.Text + ",'" + txt_story.Text + ",'" + txt_realization.Text +
            int rowsAffected = sql.ExecuteNonQuery();
            MessageBox.Show("Record Created");

            connection.Close();
        }

        private void btnread_Click(object sender, RoutedEventArgs e)
        {
            string Connectstring = "server=localhost;database=dbpersonaldiary;uid=root;Pwd=Dubudahyun28";

            MySqlConnection connection = new MySqlConnection(Connectstring);
            connection.Open();

            MySqlCommand sql = new MySqlCommand("SELECT User_name, date, time, place, story, realization FROM user WHERE iduser = " + txt_usersname.Text, connection);
            MySqlDataReader data = sql.ExecuteReader();
            while (data.Read())
            {
                txt_userid.Text = data[0].ToString();
                txt_year.Text = data[1].ToString();
                txt_hour.Text = data[2].ToString();
                txt_place.Text = data[3].ToString();
                txt_story.Text = data[4].ToString();
                txt_realization.Text = data[5].ToString();
            }
            connection.Close();
        }
    }
}

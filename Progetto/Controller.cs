using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Progetto
{
    static class Controller
    {

        public static string UpdatePrezziAlim(SqlConnection connection, string connectionString)
        {
            string query = "SELECT SUM(prezzo) FROM ArticoliAlimentari";
            string res = null;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    res = command.ExecuteScalar().ToString() + " €";
                }
                catch (SqlException)
                {
                    CustomMessageBox msg = new CustomMessageBox("Errore SQL");
                    msg.Show();
                }
            }

            return res;
        }

        public static string UpdatePrezziSport(SqlConnection connection, string connectionString)
        {

            string query = "SELECT SUM(prezzo) FROM ArticoliSportivi";
            string res = null;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                try
                {
                   res = command.ExecuteScalar().ToString() + " €";
                }
                catch (SqlException)
                {
                    CustomMessageBox msg = new CustomMessageBox("Errore SQL");
                    msg.Show();
                }

            }
            return res;
        }

        public static string UpdatePrezziTotale(SqlConnection connection, string connectionString)
        {
            string query1 = "SELECT SUM(Prezzo) FROM PrezziTot";
            string res = null;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                connection.Open();

                try
                {
                    res = command.ExecuteScalar().ToString() + " €";
                }
                catch (SqlException)
                {
                    CustomMessageBox msg = new CustomMessageBox("Errore SQL seconda query");
                    msg.Show();
                }

            }

            return res;
        }

        public static DataTable PopulateSport(SqlConnection connection, string connectionString)
        {
            string query = "SELECT * FROM ArticoliSportivi";

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable ArticoliSportTabella = new DataTable();
                adapter.Fill(ArticoliSportTabella);

                return ArticoliSportTabella;
            }

        }


        public static DataTable PopulateAlim(SqlConnection connection, string connectionString)
        {
            string query = "SELECT * FROM ArticoliAlimentari";

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable ArticoliAlimTabella = new DataTable();
                adapter.Fill(ArticoliAlimTabella);

                return ArticoliAlimTabella;
            }

        }


        public static void addArticoloSportivo(ArticoloSportivo artSport, SqlConnection connection, string connectionString)
        {

            string query = "INSERT INTO ArticoliSportivi VALUES (@varCodice, @varNome, @varPrezzo, @varSport)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                try
                {
                    command.Parameters.AddWithValue("@varCodice", artSport.Codice);
                    command.Parameters.AddWithValue("@varNome", artSport.Nome);
                    command.Parameters.AddWithValue("@varPrezzo", artSport.Prezzo);
                    command.Parameters.AddWithValue("@varSport", artSport.Sport);

                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    CustomMessageBox msg = new CustomMessageBox("SQL errore, codice identico ad un altro articolo");
                    msg.Show();
                }
            }

        }


        public static void addArticoloAlimentare(ArticoloAlimentare artAlim, SqlConnection connection, string connectionString)
        {
            string query = "INSERT INTO ArticoliAlimentari VALUES (@varCodice, @varNome, @varPrezzo, @varCucina, @varCotto)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                try
                {
                    command.Parameters.AddWithValue("@varCodice", artAlim.Codice);
                    command.Parameters.AddWithValue("@varNome", artAlim.Nome);
                    command.Parameters.AddWithValue("@varPrezzo", artAlim.Prezzo);
                    command.Parameters.AddWithValue("@varCucina", artAlim.Cucina);
                    command.Parameters.AddWithValue("@varCotto", artAlim.Cotto);

                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    CustomMessageBox msg = new CustomMessageBox("SQL errore, codice identico ad un altro articolo");
                    msg.Show();
                }
            }

        }



        public static ArticoloSportivo CreateArticoloSportivo(string nome, string codice, decimal prezzo, string sport)
        {
            return new ArticoloSportivo(nome,codice,prezzo,sport);
        }


        
        public static ArticoloAlimentare CreateArticoloAlimentare(string nome, string codice, decimal prezzo, string cucina, bool cotto)
        {
            return new ArticoloAlimentare(nome, codice, prezzo, cucina, cotto);
        }


        public static void updateView(SqlConnection connection, string connectionString)
        {
            DataGridView ViewSport = (Application.OpenForms[0] as ClasseBase).getViewSport();

            DataGridView ViewAlim = (Application.OpenForms[0] as ClasseBase).getViewAlim();

            ViewSport.DataSource = PopulateSport(connection, connectionString);
            
            ViewAlim.DataSource = PopulateAlim(connection, connectionString);
        }

    }
}

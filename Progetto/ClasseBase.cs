using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Progetto
{
    public partial class ClasseBase : Form
    {

        SqlConnection connection;

        string connectionString;



        public ClasseBase()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["Progetto.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Controller.updateView(connection, connectionString);

            UpdatePrezziSport();
            UpdatePrezziAlim();

            SetTable();

        }

        public DataGridView getViewSport()
        {
            return dataGridSport;
        }

        public DataGridView getViewAlim()
        {
            return dataGridAlim;
        }



        private void SetTable()
        {

            dataGridSport.Columns[2].DefaultCellStyle.Format = "C2";
            dataGridAlim.Columns[2].DefaultCellStyle.Format = "C2";

            foreach (DataGridViewColumn column in dataGridSport.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn column in dataGridAlim.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //Funzioni per popolare le tabelle ----------------------------------------------------------------
        private void UpdatePrezziSport()
        {
            labelPrezzoTotSport.Text = Controller.UpdatePrezziSport(connection, connectionString);

            prezzoTotaleArt.Text = Controller.UpdatePrezziTotale(connection, connectionString);
        }

        private void UpdatePrezziAlim()
        {
            labelPrezzoTotAlim.Text = Controller.UpdatePrezziAlim(connection, connectionString);

            prezzoTotaleArt.Text = Controller.UpdatePrezziTotale(connection, connectionString);
        }


        //------------------------------------------------------------------

        //BOTTONE SPORT
        private void buttonInserisciArtSportivo_Click(object sender, EventArgs e)
        {
            try
            {

                if ((textBoxNomeArtSport.Text == string.Empty))
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if(textBoxNomeArtSport.Text.All(char.IsDigit))
                {
                    throw new Exception("Errore, il campo Nome non può contenere un numero");
                }

                if (textBoxCodiceArtSport.Text == string.Empty)
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if (textBoxPrezzoArtSport.Text == string.Empty)
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if (textBoxPrezzoArtSport.Text.Contains(','))
                {
                    throw new Exception("Errore, il campo 'Prezzo' non è in formato decimale.\n" +
                        "Controllare che sia inserito il punto '.' e non la virgola ','");
                }

                if (!(decimal.TryParse(textBoxPrezzoArtSport.Text, out decimal n)))
                {
                    throw new Exception("Errore, il campo 'Prezzo' non è in formato decimale");
                }

                if (isCorDec(n))
                {
                    throw new Exception("Errore, il campo 'Prezzo' non è nel formato decimale corretto");
                }

                if (textBoxSport.Text == string.Empty)
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if (textBoxSport.Text.All(char.IsDigit))
                {
                    throw new Exception("Errore, lo sport non può essere un numero");
                }

                ArticoloSportivo artSport = Controller.CreateArticoloSportivo(
                textBoxNomeArtSport.Text,
                textBoxCodiceArtSport.Text,
                decimal.Round(decimal.Parse(textBoxPrezzoArtSport.Text, CultureInfo.InvariantCulture.NumberFormat), 2),
                textBoxSport.Text);


                Controller.addArticoloSportivo(artSport, connection, connectionString);

                Controller.updateView(connection, connectionString);


                //Pulisce le text box
                CleanSport();
            }
            catch (Exception ex)
            {
                CustomMessageBox msg = new CustomMessageBox(ex.Message);
                msg.Show();
            }

        }


        //BOTTONE ALIMENTI
        private void buttonInserisciAritAlimentare_Click(object sender, EventArgs e)
        {

            try
            {

                if (textBoxNomeArtAlim.Text == string.Empty)
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if (textBoxNomeArtAlim.Text.All(char.IsDigit))
                {
                    throw new Exception("Errore, il campo Nome non può contenere un numero");
                }

                if (textBoxCodiceArtAlim.Text == string.Empty)
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if (textBoxPrezzoArtAlim.Text == string.Empty)
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if (textBoxPrezzoArtAlim.Text.Contains(','))
                {
                    throw new Exception("Errore, il campo 'Prezzo' non è in formato decimale.\n" +
                        "Controllare che sia inserito il punto '.' e non la virgola ','");
                }

                if (!(decimal.TryParse(textBoxPrezzoArtAlim.Text, out decimal n)))
                {
                    throw new Exception("Errore, il campo 'Prezzo' non è in formato decimale");
                }

                if (isCorDec(n))
                {
                    throw new Exception("Errore, il campo 'Prezzo' non è nel formato decimale corretto");
                }

                if (textBoxCucina.Text == string.Empty)
                {
                    throw new Exception("Errore, almeno un campo è vuoto");
                }

                if (textBoxCucina.Text.All(char.IsDigit))
                {
                    throw new Exception("Errore, il tipo di cucina non può contenere un numero");
                }

                ArticoloAlimentare artAlim = Controller.CreateArticoloAlimentare(
                    textBoxNomeArtAlim.Text,
                    textBoxCodiceArtAlim.Text,
                    decimal.Round(decimal.Parse(textBoxPrezzoArtAlim.Text, CultureInfo.InvariantCulture.NumberFormat), 2),
                    textBoxCucina.Text,
                    checkBoxCotto.Checked);

                Controller.addArticoloAlimentare(artAlim, connection, connectionString);
                //Pulisce le text box
                CleanAlim();

                Controller.updateView(connection, connectionString);

            }
            catch (Exception ex)
            {
                CustomMessageBox msg = new CustomMessageBox(ex.Message);
                msg.Show();
            }

        }




        //UTILITIES
        private bool isCorDec(decimal numero)
        {
            Func<decimal,bool> dec = (num) =>
                Decimal.Round(num, 2) != num;

            return dec(numero);
        }

        private void CleanSport()
        {
            textBoxNomeArtSport.Text = String.Empty;
            textBoxCodiceArtSport.Text = String.Empty;
            textBoxPrezzoArtSport.Text = String.Empty;
            textBoxSport.Text = String.Empty;
        }


        private void CleanAlim()
        {
            textBoxNomeArtAlim.Text = String.Empty;
            textBoxCodiceArtAlim.Text = String.Empty;
            textBoxPrezzoArtAlim.Text = String.Empty;
            textBoxCucina.Text = String.Empty;
        }

        private void buttonDeleteSport_Click(object sender, EventArgs e)
        {

            try
            {
                int selectedrowindex = dataGridSport.SelectedCells[0].RowIndex;
                string myValue = dataGridSport[0, selectedrowindex].Value.ToString();

                string query = "DELETE FROM ArticoliSportivi WHERE Codice = @varCodice";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    try
                    {
                        command.Parameters.AddWithValue("@varCodice", myValue);

                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        CustomMessageBox msg = new CustomMessageBox("SQL errore");
                        msg.Show();
                    }
                }

                Controller.PopulateSport(connection, connectionString);

            }
            catch (Exception)
            {
                CustomMessageBox msg = new CustomMessageBox("Errore, nessuna riga presente");
                msg.Show();
            }
        }


        private void buttonDeleteAlim_Click(object sender, EventArgs e)
        {
            try {
                int selectedrowindex = dataGridAlim.SelectedCells[0].RowIndex;
                string myValue = dataGridAlim[0, selectedrowindex].Value.ToString();

                string query = "DELETE FROM ArticoliAlimentari WHERE Codice = @varCodice";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    try
                    {
                        command.Parameters.AddWithValue("@varCodice", myValue);

                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        CustomMessageBox msg = new CustomMessageBox("SQL errore");
                        msg.Show();
                    }
                }

                Controller.PopulateAlim(connection, connectionString);

            }
            catch (Exception)
            {
                CustomMessageBox msg = new CustomMessageBox("Errore, nessuna riga presente");
                msg.Show();
            }
        }

    }
}

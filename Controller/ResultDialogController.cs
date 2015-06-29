using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Finan.Controller
{
    
    public class ResultDialogController
    {
        private MainController mainController;
        private SqlConnection connection;


        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="mainController"></param>
        public ResultDialogController(MainController mainController)
        {
            this.mainController = mainController;
            this.connection = mainController.dbConnection.connection;
        }

        /// <summary>
        /// Checks if any textboxes are empty.
        /// </summary>
        /// <param name="forms">The forms to check.</param>
        /// <returns>True if any textbox is emty, elsereturns false.</returns>
        public Boolean TextBoxEmpty(TextBoxBase[] forms)
        {
            Boolean empty = false;

            foreach (TextBoxBase tbb in forms)
            {
                if (tbb.Text.Equals("")) { empty = true; }
            }
            return empty;
        }

        /// <summary>
        /// Saves a resultModel to the database
        /// </summary>
        /// <param name="resultModel">The resultModel to save.</param>
        public void ResultModelToDB(ResultModel resultModel)
        {
            // CHECK FOR OPEN CONNECTION
            int connOpen = 0;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                connOpen = 1;
            }

            // STRING WITH QUERY
            string query = @"UPDATE Resultaat SET " +
                "Verdunning = @verdunning, "+
                "Kolonies = @kolonies, "+
                "Temperatuur = @temperatuur, "+
                "Soort = @soort, " +
                "Strain = @strain, " +
                "Tijdsduur = @tijdsduur, " +
                "Voedingsbodem = @voedingsbodem, " +
                "Bron = @bron, " +
                "Medium = @medium, " +
                "Behandeling = @behandeling, " +
                "Path = @path, " +
                "Kolonie_positie = @kolonie_positie " +
                "WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, connection);

            // QUERY PARAMETERS
            command.Parameters.Add(new SqlParameter("verdunning", resultModel.Verdunning));
            command.Parameters.Add(new SqlParameter("kolonies", resultModel.Kolonies));
            command.Parameters.Add(new SqlParameter("temperatuur", resultModel.Temperatuur));
            command.Parameters.Add(new SqlParameter("soort", resultModel.Soort));
            command.Parameters.Add(new SqlParameter("strain", resultModel.Strain));
            command.Parameters.Add(new SqlParameter("tijdsduur", resultModel.Tijdsduur));
            command.Parameters.Add(new SqlParameter("voedingsbodem", resultModel.Voedingsbodem));
            command.Parameters.Add(new SqlParameter("bron", resultModel.Bron));
            command.Parameters.Add(new SqlParameter("medium", resultModel.Medium));
            command.Parameters.Add(new SqlParameter("behandeling", resultModel.Behandeling));
            command.Parameters.Add(new SqlParameter("path", resultModel.FilePath));
            command.Parameters.Add(new SqlParameter("kolonie_positie", resultModel.ColonyListToString()));

            command.Parameters.Add(new SqlParameter("id", resultModel.ID));
            command.ExecuteNonQuery();
            // CLEAR PARAMETERS
            command.Parameters.Clear();

            mainController.resultController.Init();
            // IF OPEN THEN CLOSE
            if (connOpen == 1)
                connection.Close();
        }    
    }
}

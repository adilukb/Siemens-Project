/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TasksServices.Model;

namespace TasksServices.Repository
{
    public class MarkersRepository
    {
        public string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SkyDB;Integrated Security=True";
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;

        public MarkersRepository()
        {
            connection = new SqlConnection(connectionString);
            command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
        }

        private List<MarkerViewModel> GetModel()
        {
            command.CommandText = "SELECT Latitude, Longitude, Title FROM Markers";
            var mvmList = new List<MarkerViewModel>();
            using (connection)
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var mvm = new MarkerViewModel();

                    mvm.Latitude = reader.GetDouble(0);
                    mvm.Longitude = reader.GetDouble(1);
                    mvm.Title =reader.GetString(2);
                    mvmList.Add(mvm);
                }

                return mvmList;
            }
        }

      

        private List<MarkerViewModel> model;
        private static readonly object obj = new object();
        private static MarkersRepository instance = null;
        public static MarkersRepository Instance
        {
            get
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new MarkersRepository();
                    }
                    return instance;
                }
            }
        }

        private List<MarkerViewModel> Model
        {
            get
            {
                if (model == null)
                {
                    model = GetModel();
                }
                return model;
            }
        }


        public List<MarkerViewModel> GetMarkers()
        {
            return Model;
        }


        public MarkerViewModel GetMarker(int pos)
        {
            return Model[pos];
        } 

    }
}
*/
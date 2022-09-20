
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TasksServices.Model;
using System.Data.SqlClient;

namespace TasksServices.Repository
{
    public class MarkersRepository
    {
        public string connectionString =
            @"Data Source=DESKTOP-RPB24GK\SQLEXPRESS;Initial Catalog=SkyLocations;Integrated Security=True";
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
            command.CommandText = "SELECT Latitude, Longitude, Statiune, Partii, Cazare, Imagine FROM SkiTable";
            var mvmList = new List<MarkerViewModel>();
            using (connection)
            {
                connection.Open();
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var mvm = new MarkerViewModel();

                    mvm.Latitude = reader.GetDouble(0);
                    mvm.Longitude = reader.GetDouble(1);
                    mvm.Title = "<strong><center>" + reader.GetString(2) + "</center></strong><p align='left'>Partii:<br>";

                    string s = reader.GetString(3);
                    string[] subs = s.Split('(', ';');

                    for (int i = 0; i < subs.Length; i += 2)
                    {
                        mvm.Title += "<strong>" + subs[i] + "</strong>(" + subs[i + 1] + "<br>";
                    }
                    mvm.Title += @"<button class=""btn btn-success"" onclick=""window.open('" + reader.GetString(4).Replace(Environment.NewLine, "") + @"');"">Cazare " + reader.GetString(2) + @"</button>";
                    mvm.Title += @"<img src=""" + reader.GetString(5) + @""" width = ""300p"" height = ""170p"" alt = Stațiunea " + reader.GetString(2) + @">";

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

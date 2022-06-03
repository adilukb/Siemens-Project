
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TasksServices.Model;

namespace TasksServices.Repository
{
    public class MarkersRepository
    {
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

        private List<MarkerViewModel> GetModel()
        {
            var path = @"C:\Users\adiluk\Desktop\reporepo\LeafletBlazor-main\TasksServices\Resources\markerData.csv"; // Habeeb, "Dubai Media City, Dubai"
            TextFieldParser csvParser = new TextFieldParser(path);
            
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                var mvmList = new List<MarkerViewModel>();
                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    var mvm = new MarkerViewModel();
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                   
                    mvm.Latitude = double.Parse(fields[0]);
                    mvm.Longitude = double.Parse(fields[1]);
                    mvm.Title = fields[2];
                    mvmList.Add(mvm);
                }

                return mvmList;
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

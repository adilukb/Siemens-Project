
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
        private const string data = "markerData.csv";
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
            string path = $"{Directory.GetCurrentDirectory()}\\Resources\\{data}";
            TextFieldParser csvParser = new TextFieldParser(path);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(",");
            csvParser.HasFieldsEnclosedInQuotes = true;

            var mvmList = new List<MarkerViewModel>();
            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                var mvm = new MarkerViewModel();
                string[] fields = csvParser.ReadFields();

                mvm.Latitude = double.Parse(fields[0]);
                mvm.Longitude = double.Parse(fields[1]);
                mvm.Title = "<strong><center>" + fields[2] + "</center></strong><p align='left'>Partii:<br>";

                string s = fields[3];
                string[] subs = s.Split('(', ';');

                for(int i = 0; i < subs.Length; i+=2)
                {
                    mvm.Title += "<strong>" + subs[i] + "</strong>(" + subs[i + 1] + "<br>";
                }
                mvm.Title += @"<button class=""btn btn-success"" onclick=""window.open('" + fields[4] + @"')"">Cazare " + fields[2] + @"</button>";
                mvm.Title += @"<img src=""" + fields[5] + @""" width = ""300p"" height = ""170p"" alt = Stațiunea " + fields[2] + @">";


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

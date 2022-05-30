using System;
using System.Collections.Generic;
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
            List<double> LatitudeList = new List<double>() { 46.358, 45.443, 47.661, 45.60, 47.655, 46.968, 45.508, 45.591, 45.408, 47.574, 47.651, 46.714, 46.679, 42 };
            List<double> LongitudeList = new List<double>() { 22.734, 25.572, 23.696, 24.613, 24.660, 25.55, 25.357, 25.525, 25.515, 25.117, 23.830, 23.639, 25.514, 24.545 };
            //Wellington: 41.2924° S, 174.7787°
            var mvmList = new List<MarkerViewModel>();
            
            //mvm.Latitude = -42;
            //mvm.Longitude = 175;
            for (int i = 0; i < LatitudeList.Count; i++)
            {
                var mvm = new MarkerViewModel();
                mvm.Latitude = LatitudeList[i];
                mvm.Longitude = LongitudeList[i];
                mvm.Title = "Wellington NZ" + i;
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

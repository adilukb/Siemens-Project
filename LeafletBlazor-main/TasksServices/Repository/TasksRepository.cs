using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TasksServices.Model;

namespace TasksServices.Repository
{
    public class TasksRepository
    {
        private const string data = "tasks.csv";
        private List<TaskModel> model;

        private static readonly object obj = new object();
        private static TasksRepository instance = null;
        public static TasksRepository Instance
        {
            get
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new TasksRepository();
                    }
                    return instance;
                }
            }
        }


        private List<TaskModel> ReadDataFile()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\Resources\\{data}";
            string[] readText = File.ReadAllLines(path);
            var csv = readText.Select(s => s.Split(',')).ToArray();
            return GetModel(csv); ;
        }

        private List<TaskModel> GetModel(string[][] csv)
        {
            var model = new List<TaskModel>();

            try
            {
                for (int i = 1; i < csv.Length; i++)
                {
                    model.Add(new TaskModel(
                                    int.Parse(csv[i][0]),
                                    int.Parse(csv[i][1]),
                                    csv[i][2])
                        );


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error read data file: {ex.Message}");
                Console.WriteLine($"Error read input file:  {data} ");
                throw ex;
            }

            return model;
        }

        public List<TaskModel> GetTasks()
        {
            return Model.Where(m => m.ParentId == 0).ToList();
        }

        public List<TaskModel> GetChildren(int nodeId)
        {
            return Model.Where(m => m.ParentId == nodeId).ToList();
        }



        public bool HasChildren(int nodeId)
        {
            return (Model.Count(m => m.ParentId == nodeId) > 0);
        }


        private List<TaskModel> Model
        {
            get
            {
                if (model == null)
                {
                    model = ReadDataFile();
                }
                return model;
            }
        }
    }
}

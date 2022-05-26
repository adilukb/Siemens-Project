namespace TasksServices.Model
{
    public class TaskModel
    {
        public TaskModel(int id, int parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }
        public int Id { get; private set; }
        public int ParentId { get; private set; }
        public string Name { get; private set; }
    }
}

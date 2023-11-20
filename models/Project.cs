namespace projects_api.models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Revenue { get; set; }
        public bool isCompleted { get; set; } = false;

    }
}

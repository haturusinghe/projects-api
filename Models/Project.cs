namespace projects_api.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public double Revenue { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}

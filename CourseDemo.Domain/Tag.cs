namespace CourseDemo.Domain
{
    public abstract class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string GroupName { get; set; }
    }
}
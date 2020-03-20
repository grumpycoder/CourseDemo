namespace CourseDemo.Domain.Dtos
{
    public class CreateClusterDto
    {
        public string ClusterCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BeginYear { get; set; }
        public int EndYear { get; set; }
    }
}
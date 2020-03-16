namespace CourseDemo.Domain
{
    public class CourseType
    {
        public int Id { get; set; }
        public string CourseTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsCore { get; set; }
    }
}
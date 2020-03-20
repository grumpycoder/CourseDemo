using CSharpFunctionalExtensions;

namespace CourseDemo.Domain.Models
{
    public class Cluster
    {
        public int Id { get; private set; }
        public string ClusterCode { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ValidPeriod ValidPeriod { get; private set; }

        protected Cluster(){}

        public Cluster(string name, string description, string clusterCode, ValidPeriod validPeriod)
        {
            ClusterCode = clusterCode;
            UpdateDetails(name, description);
            ChangeValidPeriod(validPeriod);
        }

        public void ChangeValidPeriod(ValidPeriod validPeriod)
        {
            ValidPeriod = validPeriod; 
        }

        public void UpdateDetails(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
    }
}
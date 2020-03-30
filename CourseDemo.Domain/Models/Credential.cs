using CSharpFunctionalExtensions;

namespace CourseDemo.Domain.Models
{
    public class Credential
    {
        public int Id { get; private set; }
        public string CredentialCode { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ValidPeriod ValidPeriod { get; private set; }
        public bool IsReimbursable { get; private set; }

        protected Credential()
        {
        }

        public Credential(string name, string description, string credentialCode, ValidPeriod validPeriod,
            bool isReimbursable)
        {
            CredentialCode = credentialCode;
            UpdateDetails(name, description, isReimbursable);
            ChangeValidPeriod(validPeriod);
        }

        public void ChangeValidPeriod(ValidPeriod validPeriod)
        {
            ValidPeriod = validPeriod;
        }

        public void UpdateDetails(string name, string description, bool isReimbursable)
        {
            Name = name;
            Description = description;
            IsReimbursable = isReimbursable; 
        }
    }
}
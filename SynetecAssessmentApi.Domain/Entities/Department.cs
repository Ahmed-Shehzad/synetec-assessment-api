using System.Collections.Generic;
using SynetecAssessmentApi.Domain.Entities.Base;

namespace SynetecAssessmentApi.Domain.Entities
{
    public class Department : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Department(
            int id,
            string title,
            string description) : base(id)
        {
            Title = title;
            Description = description;
        }
    }
}

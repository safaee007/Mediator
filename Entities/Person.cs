using System.ComponentModel.DataAnnotations;

namespace MediatR_SampleProject.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VkHunter.Domain.Entities
{
    public class TestModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

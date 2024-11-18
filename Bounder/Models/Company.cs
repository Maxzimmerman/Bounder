using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace Bounder.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        public List<CompanyLocation> Area { get; set; }
    }
}

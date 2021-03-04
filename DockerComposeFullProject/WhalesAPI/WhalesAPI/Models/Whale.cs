using System.ComponentModel.DataAnnotations.Schema;

namespace WhalesAPI.Models
{
    public class Whale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string Population { get; set; }
        public string Size { get; set; }
    }
}

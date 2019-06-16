using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.Mobels
{
    public class Value
    {
        [Required]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
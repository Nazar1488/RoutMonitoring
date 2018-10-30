using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Monitoring
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public MonitoringType Type { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name = "Is successed")]
        public bool IsSuccessed { get; set; }

        [Required]
        [Display(Name = "Is in process")]
        public bool IsInProccess { get; set; }

        [Required]
        [Display(Name = "Rout")]
        public string Rout { get; set; }
    }
}
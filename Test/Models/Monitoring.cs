using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models.Railway;

namespace Test.Models
{
    public class Monitoring
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public MonitoringType Type { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "Is successed")]
        public bool IsSuccessed { get; set; }

        [Required]
        [Display(Name = "Is in process")]
        public bool IsInProccess { get; set; }

        [Required]
        [Display(Name = "Rout")]
        public string Rout { get; set; }

        [Required]
        [Display(Name = "From")]
        public string From { get; set; }

        [Required]
        [Display(Name = "To")]
        public string To { get; set; }

        [Required]
        [Display(Name = "Date")]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        public string Time { get; set; }

        [Required]
        [Display(Name = "Seat type")]
        public string SeatType { get; set; }

        public List<Train> Trains { get; set; }
    }
}
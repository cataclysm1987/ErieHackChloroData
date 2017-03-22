using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ErieHackChloroData.Models
{
    public enum GreatLakes { Erie, Superior, Michigan, Ontario, Huron }
    public enum Sites { RR1B, BRD17D, CW88, BRD17I, CE100, CE92, CW82, WPT1, MFYBRD17D}
    public enum Parameters { ChlorophyllA, DRPhos, NH3, NO3NO2, TOTALP }

    public enum Codes
    {
        [Description("Estimated value")]Estimated,
        [Description("Value is below method detection limit")]BelowLimit,
        [Description("Value is between method detection limit and practical quantitation limit; estimated value")]InBetween,
        [Description("Reading is accurate")]Accurate
    }

    public enum Units
    {
        [Description("ug/L")]
        ugl,
        [Description("mg/L")]
        mgl
    }

    public class ChlorophyllSample
    {
        [Key]
        public int SampleId { get; set; }
        [Required]
        [Display(Name="Great Lake")]
        public GreatLakes Lake { get; set; }
        [Required]
        [Display(Name = "Site Observed")]
        public Sites Site { get; set; }
        [Required]
        [Display(Name = "Time Entered")]
        public DateTime TimeEntered { get; set; }
        [Required]
        [Display(Name = "Parameter Observed")]
        public Parameters Parameter { get; set; }
        [Required]
        [Display(Name = "Entry Code")]
        public Codes EntryCode { get; set; }
        [Required]
        [Display(Name = "Result of Measurement")]
        public double Result { get; set; }
        [Required]
        [Display(Name = "Units of Measurement")]
        public Units Unit { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
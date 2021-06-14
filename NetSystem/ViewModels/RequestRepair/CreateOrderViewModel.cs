using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetSystem.ViewModels.RequestRepair
{
    public class CreateOrderViewModel
    {
        [Display(Name ="کد درخواست")]
        public long RequestID_FK { get; set; }
        [Display(Name ="عنوان درخواست")]
        public string RequestTitel { get; set; }

        [Display(Name ="برق")]
        public bool Electrical { get; set; }

        [Display(Name ="مکانیکی")]
        public bool Mecanical { get; set; }
        [Display(Name ="تاسیسات")]
        public bool Piping { get; set; }
        [Display(Name ="ساخت")]
        public bool Creating { get; set; }
        [Display(Name ="تجهیز")]
        public bool Equip { get; set; }
        [Display(Name ="تعمیرات در خارج شرکت")]
        public bool RepairOutside { get; set; }


        [Display(Name ="شروع کار")]
        public DateTime StartWorking { get; set; }


        [Display(Name ="فرسودگی")]
        public bool Cause_Exhaustion { get; set; }
        [Display(Name ="سهل انگاری اپراتور")]
        public bool Cause_OperatorNegligence { get; set; }
        [Display(Name ="کیفیت قطعات یدکی")]
        public bool Cause_QualityofSpareParts { get; set; }
        [Display(Name ="خطای تعمیرکار")]
        public bool Cause_RepairmanError { get; set; }

        [Display(Name ="سایر")]
        public bool OtherError { get; set; }
        [Display(Name ="شرح")]
        public string OtherErrorDescription { get; set; }

        [Display(Name ="شرح کار")]
        public string ReportRepair { get; set; }


        [Display(Name ="کمبود نیرو")]
        public bool PersonHours { get; set; }
        [Display(Name ="به مدت")]
        public short PersonHoursTime { get; set; }
        [Display(Name ="شرح")]
        public string PersonHoursDescription { get; set; }

        [Display(Name ="برنامه ریزی تولید")]
        public bool ProductionPlanning { get; set; }
        [Display(Name ="به مدت")]
        public short ProductionPlanningTime { get; set; }
        [Display(Name ="شرح")]
        public string ProductionPlanningDescription { get; set; }

        [Display(Name ="نبود قطعات یدکی")]
        public bool NoSpareParts { get; set; }
        [Display(Name ="به مدت")]
        public short NoSparePartsTime { get; set; }
        [Display(Name ="شرح")]
        public string NoSparePartsDescription { get; set; }

        [Display(Name ="سایر")]
        public bool Other { get; set; }
        [Display(Name ="به مدت")]
        public short OtherTime { get; set; }
        [Display(Name ="شرح")]
        public string OtherDescription { get; set; }

     

    }
}

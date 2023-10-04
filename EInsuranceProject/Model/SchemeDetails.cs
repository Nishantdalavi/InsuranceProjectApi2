using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class SchemeDetails
    {
        [Key]
        public int DetailId { get;set; }
        public string SchemeImage { get; set; }
        public string Description { get;set; }
        public Int32 MinAmount { get; set; }
        public Int32 MaxAmount { get; set;}

        public InsuranceScheme? InsuranceScheme { get; set; }
           
      

    }
}

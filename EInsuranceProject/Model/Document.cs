using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Document
    {
        [Key]
        public int DocumentId { get;set; }
        public string DocumentType { get;set; }
        public string DocumentName { get;set; }
       // public string DoumentFile { get;set; }

        public Customer Customer { get;set; }
        [ForeignKey("Customer")]
        public int CustomerId { get;set; }  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainLayer.Models
{
    public class Visit : BaseEntity
    {
        public int Id
        {
            get;
            set;
        }
        public string VisitDescription
        {
            get;
            set;
        }
        public int PatientId
        {
            get;
            set;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainLayer.Models
{
    public class Clinic : BaseEntity
    {
        public int Id
        {
            get;
            set;
        }
        public string ClinicName
        {
            get;
            set;
        }
       
        public List<Patient> Patients
        {
            get;
            set;
        }
    }
}
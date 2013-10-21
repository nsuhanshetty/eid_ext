using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eid.Models
{
    class StaffModel
    {        
        public int EMP_NO { get; set; }
        public string EMP_NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public int EMP_DOB { get; set; }
        public string EMP_MARITAL_STATUS { get; set; }
        public int EMP_DOM { get; set; }
        public string WIFE_NAME { get; set; }
        public int EMP_NOCHILD { get; set; }
        public string EMP_READ { get; set; }
        public string EMP_WRITE { get; set; }
        public string EMP_SPEAK { get; set; }
        public string EMP_PADDRESS { get; set; }
        public string EMP_PRES_ADDRESS { get; set; }
        public int EMP_PHONE_NO { get; set; }
        public int EMP_MOBILE_NO { get; set; }
        public string EMP_EDU_QUAL { get; set; }
        public string EMP_OTHR_QUAL { get; set; }
        public string EMP_EXPERIENCE_SEC_SER { get; set; }
        public string REF1_NAME { get; set; }
        public string REF1_HOUSE_NO { get; set; }
        public string REF1_STREET_NO { get; set; }
        public string REF1_POST_OFFICE { get; set; }
        public string REF1_DISTRICT { get; set; }
        public int REF1_STATE { get; set; }
        public int REF1_TELEPHONE { get; set; }
        public int REF1_PINCODE { get; set; }
        public string REF1_OCCUPATION { get; set; }
        public string REF2_NAME { get; set; }
        public string REF2_HOUSE_NO { get; set; }
        public string REF2_STREET_NO { get; set; }
        public string REF2_POST_OFFICE { get; set; }
        public string REF2_DISTRICT { get; set; }
        public string REF2_STATE { get; set; }
        public int REF2_TELEPHONE { get; set; }
        public int REF2_PINCODE { get; set; }
        public string REF2_OCCUPATION { get; set; }
        public string EMP_ABOUT { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_ON { get; set; }
        public string MODIFIED_BY { get; set; }
        public string MODIFIED_ON { get; set; }
        public char DELETED { get; set; }
    }
}

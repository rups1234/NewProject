using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCovid
{
    class DataStructures
    {


        public Dictionary<int, PatientDetails> ptdata = new Dictionary<int, PatientDetails>();

        private static DataStructures obj;


        private DataStructures()
        {

        }

        public static DataStructures Detail()
        {
            if(obj==null)
            {
                obj = new DataStructures();
            }
            return obj;

        }


        public void Setpatient_detail(Dictionary<int, PatientDetails> ptdata) => this.ptdata = ptdata;

        public Dictionary<int, PatientDetails> Getpatient_detail()
        {
            return ptdata;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCovid
{
    class Program
    {
        static void Main(string[] args)
        {

            PatientDetails pobject = new PatientDetails();

            Dictionary<int, PatientDetails> newdic = pobject.Getpatient_detail();
     
            pobject.Setpatient_detail();
          

            AddMethod(101,"Jim",768987677,77,"Fever","YES");

        }



        static PatientDetails AddMethod(int patient_ID, string patient_Name, int patient_phone, int patient_age,  string symptoms, string covidPt)
        {

            PatientDetails objectptdetails = new PatientDetails();

           


            return objectptdetails;
        
        
        
        }

        public void CovidCheck(Dictionary<int, PatientDetails> newdic)
        {
            foreach(var check in newdic)
            {
                PatientDetails p = check.Value;

                string positive = p.GetcovidPt();

                if(positive.Equals("YES"))
                {
                    Console.WriteLine("Is a Covid Pt"  +positive, "Patient Name  : ", p.Getpatient_Name());
                }
                else
                {
                    Console.WriteLine("Is Covid Negative");
                }

            }
           

        }
            
    }
}

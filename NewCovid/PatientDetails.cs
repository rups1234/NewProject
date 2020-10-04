using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCovid
{
    class PatientDetails
    {


        public Dictionary<int, PatientDetails> ptdata = new Dictionary<int, PatientDetails>();


        public int patient_ID;
        public string patient_Name;
        public int patient_phone;
        public int patient_age;
        public string symptoms;
        public string covidPt;


        //Add method for Setter & Getter

        //public PatientDetails SetPtDetails()
        //{

        //}
        public void Setpatient_ID(int patient_ID) => this.patient_ID = patient_ID;
        public void Setpatient_Name(string patient_Name) => this.patient_Name = patient_Name;

        public void Setpatient_phone(int patient_phone) => this.patient_phone = patient_phone;
        public void Setpatient_age(int patient_age) => this.patient_age = patient_age;

        public void Setsymptoms(string symptoms) => this.symptoms = symptoms;
        public void SetcovidPt(string covidPt) => this.covidPt = covidPt;



        public int Getpatient_ID() => patient_ID;
        public string Getpatient_Name() => patient_Name;
        public int Getpatient_phone() => patient_phone;
        public int Getpatient_age() => patient_age;
        public string Getsymptoms() => symptoms;
        public string GetcovidPt() => covidPt;


        public void Setpatient_detail(Dictionary<int, PatientDetails> ptdata) => this.ptdata = ptdata;

        public Dictionary<int, PatientDetails> Getpatient_detail() => ptdata;


    }


}

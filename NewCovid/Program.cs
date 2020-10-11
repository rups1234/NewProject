using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace NewCovid
{
    class Program
    {
        static void Main(string[] args)
        {

            PatientDetails pobject = new PatientDetails();

            DataStructures dataobject = DataStructures.Detail(); //Create Singleton Object in Main


            Dictionary<int, PatientDetails> adddictionary = dataobject.Getpatient_detail(); //Create a Dictionary to add data using GET method
           dataobject.Setpatient_detail(adddictionary);


           pobject = AddMethod(101, "Jim", 768987677, 77, "Fever", "YES");

            Program programObj = new Program();
            //Invoke the CovidCheck method
            programObj.CovidCheck(adddictionary);


            //Creating a resource file .JSON file to add data
            var assembly = Assembly.GetExecutingAssembly();
            var resourcename = "NewCovid.InputData.Input.json"; //file path

            // Path C:\Users\user\source\repos\NewCovid\NewCovid\InputData\Input.json

            var resources = assembly.GetManifestResourceNames();
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourcename))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            JObject o1 = JObject.Parse((result));

            //Data is in Json formatt add it to List and loop through each element to ADD Patient Data
            var listPatientData = (JArray)o1["PatientDetails"];
            List<PatientDetails> listofElements = new List<PatientDetails>();
            foreach (var variable in listPatientData)
            {
                PatientDetails obj1 = JsonConvert.DeserializeObject<PatientDetails>(variable.ToString());

                PatientDetails store = AddMethod(obj1.Getpatient_ID(), obj1.Getpatient_Name(), obj1.Getpatient_phone(),obj1.Getpatient_age(),
                    obj1.Getsymptoms(), obj1.GetcovidPt());

                listofElements.Add(store);
            }





            //Dictionary<int, PatientDetails> newdic = pobject.Getpatient_detail();
            //pobject.Setpatient_detail(newdic);
            //  AddMethod(101,"Jim",768987677,77,"Fever","YES");

        }

      
        //private static PatientDetails AddMethod(int v1, string v2, int v3, string v4, string v5)
        //{
        //    Console.WriteLine("test");
        //}



        //Add Data to Dictionary
        public void GenericAdd(Dictionary<int, PatientDetails> patientdictionary, PatientDetails pobj)
        {
            try
            {

            //Enure Dictionary & Pt obj is not null
            if (patientdictionary != null && pobj != null) //Without Try block
            {
                //Ensure Key is not null
                if (!patientdictionary.ContainsKey(pobj.Getpatient_ID()))
                {

                    patientdictionary.Add(pobj.Getpatient_ID(), pobj);
                        Console.WriteLine(patientdictionary);
                }
            }

            Console.WriteLine("Exception");


            }
            catch (Exception e)
            {
               Console.WriteLine("Exception handled");

            }





        }


        //Create a Generic method to add data .
        private static PatientDetails AddMethod(int patient_ID, string patient_Name, int patient_phone, int patient_age,  string symptoms, string covidPt)
        {

            PatientDetails objectptdetails = new PatientDetails();
            
            //Set the data
            objectptdetails.Setpatient_ID(patient_ID);
            objectptdetails.Setpatient_Name(patient_Name);
            objectptdetails.Setpatient_phone(patient_phone);
            objectptdetails.Setpatient_age(patient_age);
            objectptdetails.Setsymptoms(symptoms);
            objectptdetails.SetcovidPt(covidPt);
        
            return objectptdetails;
        }

        //Bussiness Logic
        public void CovidCheck(Dictionary<int, PatientDetails> adddictionary)
        {
            List<string> listofPts = new List<string>();

            foreach (var check in adddictionary)
            {s
                PatientDetails p = check.Value;
                string positive = p.GetcovidPt();
                string CovidPtName = p.Getpatient_Name();
                if (positive.Equals("YES"))
                {
                    Console.WriteLine("Is a Covid Pt"  +positive, "Patient Name  : " +CovidPtName);
                    listofPts.Add(CovidPtName);
                }
                else
                {
                    Console.WriteLine("Is Covid Negative");
                }

            }

            string SeniorCitizen = "People diagnosied Positive : ";
          
            foreach (string agedPt in listofPts)
            {
                SeniorCitizen += agedPt;   //appending to same string.
              

            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();
            // PdfPage page1 = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text
            gfx.DrawString(SeniorCitizen, font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height), //page1.width
            XStringFormats.Center);

            // Save the document...
            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);



        }

    }
}

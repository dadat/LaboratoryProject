using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryProject
{
    class Ultrasound
    {

        private string findings { get; set; }
        private string impression { get; set; }
        private string radiologist { get; set; }

        private string codePatient { get; set; }
        private string dateUltrasound { get; set; }
        private string codeUltrasound { get; set; }
        private DateTime dateEncoded { get; set; }

        public Ultrasound(string findings_, string impression_, string radiologist_, string codePatient_, string codeUltrasound_, string dateUltrasound_, DateTime dateEncoded_)
        {
            findings = findings_;
            impression = impression_;
            radiologist = radiologist_;

            codePatient = codePatient_;
            codeUltrasound = codeUltrasound_;
            dateUltrasound = dateUltrasound_;
            dateEncoded = dateEncoded_;
        }

        public bool insertUltrasound()
        {
            if (insertUltrasoundMethod() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool insertUltrasoundMethod()
        {
            try
            {
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    TblUltrasound tblUltra = new TblUltrasound();
                    tblUltra.CodePatient = codePatient;
                    tblUltra.DateUltrasound = dateUltrasound;
                    tblUltra.Findings = findings;
                    tblUltra.Impression = impression;
                    tblUltra.Radiologist = radiologist;
                    tblUltra.CodeUltrasound = codeUltrasound;
                    tblUltra.DateEncoded = dateEncoded;

                    if (tblUltra.Errors.Count == 0)
                    {
                        uow.Add(tblUltra);
                        uow.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

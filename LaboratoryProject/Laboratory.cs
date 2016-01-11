using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryProject
{
    class Laboratory
    {
        public string Request { get; set; }
        public decimal Price { get; set; }
        public string LaboratoryCode { get; set; }
        public DateTime DateEncoded { get; set; }
        public string DateLaboratory { get; set; }
        public string Doctor { get; set; }

        public string PatientCode { get; set; }

        public Laboratory(string request_, decimal price_, string laboratoryCode_, DateTime dateEncoded_, string dateLaboratory_, string doctor_, string patientCode_)
        {
            Request = request_;
            Price = price_;
            LaboratoryCode = laboratoryCode_;
            DateEncoded = dateEncoded_;
            DateLaboratory = dateLaboratory_;
            Doctor = doctor_;
            PatientCode = patientCode_;
        }

        public bool insertLaboratory()
        {
            if (insertLab() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool insertLab()
        {
            try
            {
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    TblLaboratory tblLab = new TblLaboratory();
                    tblLab.CodePatient = PatientCode;
                    tblLab.DateLaboratory = DateLaboratory;
                    tblLab.Request = Request;
                    tblLab.Total = Price;
                    tblLab.CodeLaboratory = LaboratoryCode;
                    tblLab.DateEncoded = DateEncoded;

                    if (tblLab.Errors.Count == 0)
                    {
                        uow.Add(tblLab);
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
                throw;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project004.Data;
namespace Project004.Models
{
    public class PracticeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Mobile_no { get; set; }
        public string Email_id { get; set; }
        public string City { get; set; }
        public int srno { get; set; }

        public string savereg(PracticeModel model)
        {
            string msg = "";
            Project004Entities Db = new Project004Entities();
            {
                var regData = new tblPractice()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Last_Name = model.Last_Name,
                    Mobile_no = model.Mobile_no,
                    Email_id = model.Email_id,
                    City = model.City,
                };
                Db.tblPractices.Add(regData);
                Db.SaveChanges();
                return msg;
            }
        }

        public List<PracticeModel> GetPracticeList() 
        {
            Project004Entities Db = new Project004Entities();
            List<PracticeModel> lstPractice = new List<PracticeModel>();
            var AddPracticeList = Db.tblPractices.ToList();
            int srno = 1;
            if (AddPracticeList != null)
            {
                foreach(var Practice in AddPracticeList) 
                {
                    lstPractice.Add(new PracticeModel()
                    {
                        srno = srno,
                        ID = Practice.ID,
                        Name = Practice.Name,
                        Last_Name = Practice.Last_Name,
                        Mobile_no = Practice.Mobile_no,
                        Email_id = Practice.Email_id,
                        City = Practice.City,

                    });
                    srno++;

                }
            }
            return lstPractice;

        }
        public string deletePractice(int ID)
        {
            var massage = " delete successful";
            Project004Entities Db = new Project004Entities();
            var data = Db.tblPractices.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null)
            {
                Db.tblPractices.Remove(data);
                Db.SaveChanges();

            }
            return massage;

        }

    }
    
}

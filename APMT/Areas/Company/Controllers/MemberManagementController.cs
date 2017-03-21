using APMT.Areas.Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
namespace APMT.Areas.Company.Controllers
{

    public class MemberManagementController : Controller
    {
        private CP_SPMEntities db = new CP_SPMEntities();
        // GET: Company/ManageMember
        public ActionResult View_List()
        {
            var query = from UserC in db.APMT_Company_User
                        join user in db.APMT_User on UserC.User_id equals user.ID
                        join company in db.APMT_Company on UserC.Company_id equals company.ID
                        where company.ID == 1
                        select new userCompany { id = UserC.ID, fullName = user.Fullname, email = user.Email, avartar = user.Avatar, createAt = user.Create_at.ToString(), updateAt = user.Update_at.ToString(), isAllowed = user.Allowed };
            //  var lstprocess = db.APMT_Running_Process_Detail.Where(x => x.project_id == id).ToList();
            ViewBag.List = query.ToList();

            return View();
        }

        public ActionResult autocomplete(string term)
        {

            var query = from user in db.APMT_User
                        where (user.Email.Contains(term) || user.Fullname.Contains(term)) && user.Allowed == true
                        select user.Email + " (" + user.Fullname + ")";
            var filteredItems = query.ToList();
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add_New(FormCollection f)
        {
            ViewBag.Message = null;
            string trimEmail = "";
            string email = f["somevalue"];
            if (email.Contains("("))
            {
                trimEmail = email.Substring(0, email.IndexOf('(')).Trim();
            }
            else
            {
                trimEmail = email;
            }
            try
            {

                var userID = db.APMT_User.SingleOrDefault(x => x.Email.Equals(trimEmail)).ID;
                if (userID != null)
                {
                    APMT_Company_User companyUser = new APMT_Company_User();
                    companyUser.Company_id = 1;
                    companyUser.User_id = int.Parse(userID.ToString());
                    db.APMT_Company_User.Add(companyUser);
                    db.SaveChanges();
                    ViewBag.Message = "Successful";
                    return RedirectToAction("View_List");
                }
                else
                {
                    ViewBag.Message = "User not exist !";
                    return RedirectToAction("View_List");
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "Add new Failure !";
                return RedirectToAction("View_List");
            }

        }
        public ActionResult deleteMember(int? id)
        {
            return View();
        }
    }
}
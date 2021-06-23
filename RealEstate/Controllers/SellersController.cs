using RealEstate.Models;
using System;
using System.Web.Mvc;
using static DataLibrary.DatabaseLogic.SellerProcessor;

namespace RealEstate.Controllers
{
    public class SellersController : Controller
    {
        // GET: Sellers
        /// <summary>
        /// Indexes the specified is success.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="status">The status.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        public ActionResult Index(Boolean isSuccess = false, string status = "", string msg = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.status = status;
            ViewBag.msg = msg;

            if (Session["Email"] != null)
            {
                var data = GetSellerById((string)Session["Email"]);
                if (data.Count > 0)
                {
                    var row = data[0];
                    SellersModel seller = new SellersModel
                    {
                        SellerId = row.SellerId,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        Email = row.Email,
                        Address = row.Address,
                        Phone = row.Phone,
                    };

                    return View(seller);
                }
            }
            return RedirectToAction("Register");
        }

        /// <summary>
        /// Registers the specified is success.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="status">The status.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        public ActionResult Register(Boolean isSuccess = false, string status = "", string msg = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.status = status;
            ViewBag.msg = msg;
            var sellerObj = new SellersModel();
            return View(sellerObj);
        }

        

        /// <summary>
        /// Registers the specified seller.
        /// </summary>
        /// <param name="_seller">The seller.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(SellersModel _seller)
        {
            if (ModelState.IsValid)
            {
                int recordCreated = CreateSeller(_seller.Email,  _seller.FirstName, _seller.LastName, _seller.Address, _seller.Phone);
                if (recordCreated > 0)
                {
                    
                    Session["FirstName"] = _seller.FirstName;
                    Session["LastName"] = _seller.LastName;
                    Session["Email"] = _seller.Email;
                    Session["Address"] = _seller.Address;
                    Session["Phone"] = _seller.Phone;
                    return RedirectToAction("Register", new { isSuccess = true, status = "success", msg = "Registered Successfully" });
                }
                else
                {
                    return RedirectToAction("Register", new { isSuccess = true, status = "danger", msg = "Seller With same email Already exists" });
                }
            }
            return View();
        }


        /// <summary>
        /// Indexes the specified seller.
        /// </summary>
        /// <param name="_seller">The seller.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(SellersModel _seller)
        {
            if (ModelState.IsValid)
            {
                int recordUpdated = UpdateSeller(_seller.Email, _seller.FirstName, _seller.LastName, _seller.Address, _seller.Phone);
                if (recordUpdated > 0)
                {
                    return RedirectToAction("Index", new { isSuccess = true, status = "success", msg = "Information Updated Successfully" });
                }
                else
                {
                    return RedirectToAction("Index", new { isSuccess = true, status = "danger", msg = "Seller With same email Already exists!Please Use valid Email" });
                }
            }
            return View();
        }
    }
}
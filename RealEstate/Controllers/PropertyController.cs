using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static DataLibrary.DatabaseLogic.PropertyProcesor;

namespace RealEstate.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        /// <summary>
        /// Propertieses the specified is success.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="status">The status.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        public ActionResult Properties(Boolean isSuccess = false, string status = "", string msg = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.status = status;
            ViewBag.msg = msg;
            var data = LoadProperties();
            List<PropertyModel> properties = new List<PropertyModel>();
            foreach (var row in data)
            {
                properties.Add(new PropertyModel
                {
                    PropertyID = row.PropertyID,
                    Suburb = row.Suburb,
                    Location = row.Location,
                    NumberOfRooms = row.NumberOfRooms,
                    PropertyType = row.PropertyType,
                    FloorArea = row.FloorArea,
                    LandArea = row.LandArea,
                    RV = row.RV,
                    SellerEmail = row.SellerEmail
                });
            }
            return View(properties);
        }

        /// <summary>
        /// Searches the property.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public ActionResult SearchProperty(string option = "", string search = "")
        {
            List<PropertyModel> properties = new List<PropertyModel>();
            if (search == "")
            {
                return View(properties);
            }
            else
            {
                var data = Search(option, search);
                foreach (var row in data)
                {
                    properties.Add(new PropertyModel
                    {
                        PropertyID = row.PropertyID,
                        Suburb = row.Suburb,
                        Location = row.Location,
                        NumberOfRooms = row.NumberOfRooms,
                        PropertyType = row.PropertyType,
                        FloorArea = row.FloorArea,
                        LandArea = row.LandArea,
                        RV = row.RV,
                        SellerEmail = row.SellerEmail
                    });
                }
                return View(properties);
            }
        }

        /// <summary>
        /// Properties the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult PropertyById(int id)
        {
            var data = GetPropertyByID(id);
            List<PropertyModel> properties = new List<PropertyModel>();
            foreach (var row in data)
            {
                properties.Add(new PropertyModel
                {
                    PropertyID = row.PropertyID,
                    Suburb = row.Suburb,
                    Location = row.Location,
                    NumberOfRooms = row.NumberOfRooms,
                    PropertyType = row.PropertyType,
                    FloorArea = row.FloorArea,
                    LandArea = row.LandArea,
                    RV = row.RV,
                    SellerEmail = row.SellerEmail
                });
            }
            return View(properties);
        }

        /// <summary>
        /// Deletes the property.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteProperty(int id)
        {
            int recordDeleted = PropertyDelete(id);
            if (recordDeleted > 0)
            {
                return RedirectToAction("Properties", new { isSuccess = true, status = "success", msg = "Property Deleted Successfully" });
            }
            else
            {
                return RedirectToAction("Properties", new { isSuccess = true, status = "danger", msg = "Property Not Deleted" });
            }
        }

        /// <summary>
        /// Adds the property.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="status">The status.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        public ActionResult AddProperty(Boolean isSuccess = false, string status = "", string msg = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.status = status;
            ViewBag.msg = msg;
            var propertyObj = new PropertyModel();
            return View(propertyObj);
        }

        /// <summary>
        /// Adds the property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProperty(PropertyModel property)
        {
            if (ModelState.IsValid)
            {
                int recordCreated = CreateProperty(property.Suburb, property.Location, property.NumberOfRooms, property.PropertyType, property.FloorArea, property.LandArea, property.RV, property.SellerEmail);
                if (recordCreated > 0)
                {
                    return RedirectToAction("AddProperty", new { isSuccess = true, status = "success", msg = "Property Added Successfully" });
                }
                else
                {
                    return RedirectToAction("AddProperty", new { isSuccess = true, status = "danger", msg = "Property Not Added" });
                }
            }
            return View();
        }
    }
}
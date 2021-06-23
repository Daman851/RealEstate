using System.Collections.Generic;
using DataLibrary.Models;
using DataLibrary.DatabaseAccess;
using System;
using System.Linq;

namespace DataLibrary.DatabaseLogic
{
    public static class PropertyProcesor
    {
        /// <summary>
        /// Creates the property.
        /// </summary>
        /// <param name="suburb">The suburb.</param>
        /// <param name="location">The location.</param>
        /// <param name="numberOfRooms">The number of rooms.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="floorArea">The floor area.</param>
        /// <param name="landArea">The land area.</param>
        /// <param name="rV">The r v.</param>
        /// <param name="sellerEmail">The seller email.</param>
        /// <returns></returns>
        public static int CreateProperty(string suburb, string location, int numberOfRooms, string propertyType, float floorArea, float landArea, string rV,string sellerEmail)
        {
            PropertymodelDB property = new PropertymodelDB {
                Suburb = suburb,
                Location = location,
                NumberOfRooms = numberOfRooms,
                PropertyType = propertyType,
                FloorArea = floorArea,
                LandArea = landArea,
                RV = rV,
                SellerEmail = sellerEmail
            };
            string sql = @"INSERT INTO [dbo].[Properties]
           ([Suburb]
           ,[Location]
           ,[NumberOfRooms]
           ,[PropertyType]
           ,[FloorArea]
           ,[LandArea]
           ,[RV]
           ,[SellerEmail])
     VALUES
           (@Suburb
           ,@Location
           ,@NumberOfRooms
           ,@PropertyType
           ,@FloorArea
           ,@LandArea
           ,@RV
           ,@SellerEmail);";
            return SQLAccess.SaveData(sql, property);
       }
        /// <summary>
        /// Loads the properties.
        /// </summary>
        /// <returns></returns>
        public static List<PropertymodelDB> LoadProperties()
        {
            string sql = @"SELECT * FROM Properties";
            return SQLAccess.LoadData<PropertymodelDB>(sql);
        }
        /// <summary>
        /// Properties the delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static int PropertyDelete(int id)
        {
            string sql = @"DELETE FROM Properties WHERE PropertyID=" + id + ";";
            return SQLAccess.DeleteData<PropertymodelDB>(sql);
        }
        /// <summary>
        /// Gets the property by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static List<PropertymodelDB> GetPropertyByID(int id)
        {
            string sql = @"SELECT * FROM Properties WHERE PropertyID=" + id + ";";
            return SQLAccess.LoadData<PropertymodelDB>(sql);
        }
        /// <summary>
        /// Searches the specified option.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public static List<PropertymodelDB> Search(string option,string search)
        {
            if (option == "Suburb")
            {
                return LoadProperties().Where(s => s.Suburb.ToLower() == search.ToLower() || search == null).ToList();


            }
            else if (option == "Location")
            {

                return LoadProperties().Where(s => s.Location.ToLower() == search.ToLower() || search == null).ToList();
            }
            else
            {
              
              return LoadProperties().Where(s => s.PropertyType.ToLower() == search.ToLower() || search == null).ToList();
            }
        }

    }
}

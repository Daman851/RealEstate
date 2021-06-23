using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Models;
using DataLibrary.DatabaseAccess;
namespace DataLibrary.DatabaseLogic
{
    public static class SellerProcessor
    {
        /// <summary>
        /// Creates the seller.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        public static int CreateSeller(string email, string firstName, string lastName, string address, string phone)
        {
            SellerModelDB sp = new SellerModelDB
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                Phone = phone
            };
            string sql = @"INSERT INTO [dbo].[Sellers]
           ([Email]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[Phone])
     VALUES
           (@Email
           ,@FirstName
           ,@LastName
           ,@Address
           ,@Phone)

";
            return SQLAccess.SaveData(sql, sp);

        }
        /// <summary>
        /// Updates the seller.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        public static int UpdateSeller(string email, string firstName, string lastName, string address, string phone)
        {
            SellerModelDB sp = new SellerModelDB
            {
                FirstName = firstName,
                Email=email,
                LastName = lastName,
                Address = address,
                Phone = phone
            };
            string sql = @"UPDATE [dbo].[Sellers]
                       SET [FirstName] = @FirstName
                          ,[LastName] = @LastName
                          ,[Address] = @Address
                          ,[Phone] = @Phone
                     WHERE [Email] = Email";
            return SQLAccess.SaveData(sql, sp);
        }
        
        /// <summary>
        /// Gets the seller by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static List<SellerModelDB> GetSellerById(string email)
        {
            string sql = @"SELECT * FROM Sellers WHERE Email='" + email+"'";
            return SQLAccess.LoadData<SellerModelDB>(sql);
        }
    }
}

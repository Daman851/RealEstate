using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
   public  class PropertymodelDB
    {

        /// <summary>
        /// Gets or sets the property identifier.
        /// </summary>
        /// <value>
        /// The property identifier.
        /// </value>
        public int PropertyID { get; set; }
        /// <summary>
        /// Gets or sets the suburb.
        /// </summary>
        /// <value>
        /// The suburb.
        /// </value>
        public string Suburb { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the number of rooms.
        /// </summary>
        /// <value>
        /// The number of rooms.
        /// </value>
        public int NumberOfRooms { get; set; }
        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        public string PropertyType { get; set; }
        /// <summary>
        /// Gets or sets the floor area.
        /// </summary>
        /// <value>
        /// The floor area.
        /// </value>
        public float FloorArea { get; set; }
        /// <summary>
        /// Gets or sets the land area.
        /// </summary>
        /// <value>
        /// The land area.
        /// </value>
        public float LandArea { get; set; }
        /// <summary>
        /// Gets or sets the rv.
        /// </summary>
        /// <value>
        /// The rv.
        /// </value>
        public string RV { get; set; }
        /// <summary>
        /// Gets or sets the seller email.
        /// </summary>
        /// <value>
        /// The seller email.
        /// </value>
        public string SellerEmail { get; set; }
    }
}

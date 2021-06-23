using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class PropertyModel
    {
        /// <summary>
        /// Gets or sets the property identifier.
        /// </summary>
        /// <value>
        /// The property identifier.
        /// </value>
        public int PropertyID { get; set; }

        [DisplayName("Property Sub Urban")]
        [Required(ErrorMessage = "Property Sub Urban is required")]
        public string Suburb { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [DisplayName("Property Location")]
        [Required(ErrorMessage = "Property Location is required")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the number of rooms.
        /// </summary>
        /// <value>
        /// The number of rooms.
        /// </value>
        [DisplayName("Property Number Of Rooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number of rooms")]
        [Required(ErrorMessage = "Property Number Of Rooms is required")]
        public int NumberOfRooms { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        [DisplayName("Property Type")]
        [Required(ErrorMessage = "Property Type is required")]
        public string PropertyType { get; set; }

        /// <summary>
        /// Gets or sets the floor area.
        /// </summary>
        /// <value>
        /// The floor area.
        /// </value>
        [DisplayName("Property Floor Area")]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid floor Area")]
        [Required(ErrorMessage = "Property Floor Area is required")]
        public float FloorArea { get; set; }

        /// <summary>
        /// Gets or sets the land area.
        /// </summary>
        /// <value>
        /// The land area.
        /// </value>
        [DisplayName("Property Land Area")]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid Land Area")]
        [Required(ErrorMessage = "Property Land Area is required")]
        public float LandArea { get; set; }

        /// <summary>
        /// Gets or sets the rv.
        /// </summary>
        /// <value>
        /// The rv.
        /// </value>
        [DisplayName("Property RV")]
        [Required(ErrorMessage = "Property RV is required")]
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
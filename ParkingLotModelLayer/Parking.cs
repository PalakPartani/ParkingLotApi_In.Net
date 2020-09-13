// <copyright file="Parking.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Parking class.
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// Gets or sets parking slot.
        /// </summary>
        [Required(ErrorMessage = "Parking slot is required")]
        [RegularExpression(@"^[1-9]{1,}$", ErrorMessage = "Please enter valid parking slot")]
        public int Parking_Slot { get; set; }

        /// <summary>
        /// Gets or sets vehcle number.
        /// </summary>
        [Required(ErrorMessage = "Vehicle number is required")]
        [RegularExpression(@"^[A-Z0-9]{3,}$", ErrorMessage = "Please enter a valid vehicle number")]
        public string Vehicle_Number { get; set; }

        /// <summary>
        /// Gets or sets vehicle type.
        /// </summary>
        [Required(ErrorMessage = "Vehicle type is required")]
        [RegularExpression(@"^[0-9A-Za-z]{1,}$", ErrorMessage = "Please enter  valid vehicle type")]
        public string VehicleType { get; set; }

        /// <summary>
        /// Gets or sets parking type.
        /// </summary>
        [Required(ErrorMessage = "Parking type is required")]
        [RegularExpression(@"^[0-9A-Za-z]{1,}$", ErrorMessage = "Please enter valid parking type")]
        public string Parking_Type { get; set; }

        /// <summary>
        /// Gets or sets driver type.
        /// </summary>
        [Required(ErrorMessage = "Driver type is required")]
        [RegularExpression(@"^[0-9A-Za-z]{1,}$", ErrorMessage = "Please enter valid driver type")]
        public string Driver_Type { get; set; }

        /// <summary>
        /// Gets or sets parking entry time.
        /// </summary>
        public DateTime EntryTime { get; set; }
    }
}

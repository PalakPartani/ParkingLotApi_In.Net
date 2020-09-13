// <copyright file="ParkingLot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Parking lot class.
    /// </summary>
    public class ParkingLot
    {
        /// <summary>
        /// Gets or sets parking id.
        /// </summary>
        public int Parking_Id { get; set; }

        public string Role { get; set; }

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
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or sets charge.
        /// </summary>
        public int Vehicle_Charge { get; set; }

        /// <summary>
        /// Gets or sets parking entry time.
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// Gets or sets parking type.
        /// </summary>
        public int Parking_Type { get; set; }

        /// <summary>
        /// Gets or sets driver type.
        /// </summary>
        public int Driver_Type { get; set; }

        /// <summary>
        /// Gets or sets disabled.
        /// </summary>
        public char Disabled { get; set; }

        /// <summary>
        /// Gets or sets exit time.
        /// </summary>
        public DateTime ExitTime { get; set; }
    }
}
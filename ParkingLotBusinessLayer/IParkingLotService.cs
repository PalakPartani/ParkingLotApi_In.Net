// <copyright file="IParkingLotService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBusinessLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;

    /// <summary>
    /// Interface to provide service.
    /// </summary>
    public interface IParkingLotService
    {
        /// <summary>
        /// Adding vecicle to lot.
        /// </summary>
        /// <param name="parkingLot">Model class.</param>
        /// <returns>adding vehicle.</returns>
        ParkingLot ParkVehicle(Parking parkingLot);

        /// <summary>
        /// Unpark vehicle.
        /// </summary>
        /// <param name="parkingLot">Inputs the parking lot.</param>
        /// <returns>bool result.</returns>
        ParkingLot UnparkVehicle(int parkingLot);

        /// <summary>
        /// Finds vehicle by vehicle no.
        /// </summary>
        /// <param name="vehicleNo">Inputs the vehicle no.</param>
        /// <returns>parking lot.</returns>
        ParkingLot FindVehicleByVehicleNo(string vehicleNo);

        /// <summary>
        /// Finds vehicle by slot no.
        /// </summary>
        /// <param name="slotNo">Inputs the slot no.</param>
        /// <returns>parking lot.</returns>
        ParkingLot FindVehicleBySlotNumber(int slotNo);

        /// <summary>
        /// Finds by id.
        /// </summary>
        /// <param name="parkingid">Inputs the id.</param>
        /// <returns>Parkinlot Model.</returns>
        ParkingLot FindVehicleByParkingId(int parkingid);

        /// <summary>
        /// Find Available Slots.
        /// </summary>
        /// <returns>List Of Available slots.</returns>
        List<int> FindEmptySlots();

        /// <summary>
        /// Display List Of all vehicles.
        /// </summary>
        /// <returns>List of Parkinglot Objects.</returns>
        List<ParkingLot> FindAllVehicles();

        /// <summary>
        /// Delete Record By Parking Id.
        /// </summary>
        /// <param name="parkingId">Parking Id.</param>
        /// <returns>Action Result.</returns>
        string DeleteVehicle(int parkingId);
    }
}

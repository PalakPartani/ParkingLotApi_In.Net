// <copyright file="IParkingLotRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;

    /// <summary>
    /// IParkingLotRepository Interface.
    /// </summary>
    public interface IParkingLotRepository
    {
        /// <summary>
        /// Parking vehicle.
        /// </summary>
        /// <param name="parkingLot">Parking Object.</param>
        /// <returns>the parking lot object.</returns>
        ParkingLot AddVehicle(Parking parkingLot);

        /// <summary>
        /// Unparks the vehicle.
        /// </summary>
        /// <param name="parkingSlot">Inputs slot.</param>
        /// <returns>bool result.</returns>
        ParkingLot UnparkVehicle(int parkingSlot);

        /// <summary>
        /// Finds vehilce by vehicle no.
        /// </summary>
        /// <param name="vehicleNo">Inputs vehicle no.</param>
        /// <returns>parking lot.</returns>
        ParkingLot FindVehicleByVehicleNo(string vehicleNo);

        /// <summary>
        /// Finds vehicle by slot no.
        /// </summary>
        /// <param name="slotNo">Inputs slot no.</param>
        /// <returns>Parking lot.</returns>
        ParkingLot FindVehicleBySlotNumber(int slotNo);

        /// <summary>
        /// Finds vehicle by id.
        /// </summary>
        /// <param name="parkingid">parking id.</param>
        /// <returns>Parkinglot Object.</returns>
        ParkingLot FindVehicleByParkingId(int parkingid);

        /// <summary>
        /// Finding empty slots.
        /// </summary>
        /// <returns>empty slots.</returns>
        List<int> FindEmptySlots();

        /// <summary>
        /// Finding all vehicles.
        /// </summary>
        /// <returns>List of Parkinglot Objects.</returns>
        List<ParkingLot> FindAllVehicles();

        /// <summary>
        /// Delete Record By Parking Id.
        /// </summary>
        /// <param name="parkingId">Parking Id.</param>
        /// <returns>String Message.</returns>
        string DeleteVehicle(int parkingId);
    }
}
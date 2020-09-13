// <copyright file="ParkingLotService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBusinessLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// PArking lot service.
    /// </summary>
    public class ParkingLotService : IParkingLotService
    {
        /// <summary>
        /// declaring IParkingLotRepository.
        /// </summary>
        private readonly IParkingLotRepository repository;
        private readonly MSMQService service = new MSMQService();

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingLotService"/> class.
        /// </summary>
        /// <param name="repository">Object of IparkingRepository.</param>
        public ParkingLotService(IParkingLotRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adding vehicles To ParkingLot.
        /// </summary>
        /// <param name="parkingLot">Parkinglot Object.</param>
        /// <returns>Parkinglot Objects.</returns>
        public ParkingLot ParkVehicle(Parking parkingLot)
        {
            ParkingLot parking = this.repository.AddVehicle(parkingLot);
            if (parking != null)
            {
                this.service.AddToQueue(parking.Role + " Parked Vehicle Having Number " + parking.Vehicle_Number + " At Time " + parking.EntryTime);
            }

            return parking;
        }

        /// <summary>
        /// Fetching List of All Vehicles.
        /// </summary>
        /// <returns>List of Parkinglot objects.</returns>
        public List<ParkingLot> FindAllVehicles()
        {
            return this.repository.FindAllVehicles();
        }

        /// <summary>
        /// Fetching List of Empty Parking slot.
        /// </summary>
        /// <returns>List of Parking Slots.</returns>
        public List<int> FindEmptySlots()
        {
            return this.repository.FindEmptySlots();
        }

        /// <summary>
        /// Find Vehicles By Parking Id.
        /// </summary>
        /// <param name="parkingid">Parking Id.</param>
        /// <returns>Parkinglot Objects.</returns>
        public ParkingLot FindVehicleByParkingId(int parkingid)
        {
            return this.repository.FindVehicleByParkingId(parkingid);
        }

        /// <summary>
        /// Find Vehicles By Using Slot Nummber.
        /// </summary>
        /// <param name="slotNo">Slot Number.</param>
        /// <returns>Parkinglot Object.</returns>
        public ParkingLot FindVehicleBySlotNumber(int slotNo)
        {
            return this.repository.FindVehicleBySlotNumber(slotNo);
        }

        /// <summary>
        /// Find Vehicle By Using Vehicle Number.
        /// </summary>
        /// <param name="vehicleNo">Vehicle Number.</param>
        /// <returns>Parkinglot Object.</returns>
        public ParkingLot FindVehicleByVehicleNo(string vehicleNo)
        {
            return this.repository.FindVehicleByVehicleNo(vehicleNo);
        }

        /// <summary>
        /// Unpark Vehicle Using Slot Number.
        /// </summary>
        /// <param name="parkingSlot">Slot Number.</param>
        /// <returns>Parkinglot Object.</returns>
        public ParkingLot UnparkVehicle(int parkingSlot)
        {
            ParkingLot parking = this.repository.UnparkVehicle(parkingSlot);
            if (parking.Vehicle_Number != null)
            {
                this.service.AddToQueue(parking.Role + " Unparked Vehicle Having Number " + parking.Vehicle_Number + " At Time " + parking.ExitTime + "was parked for " + (int)parking.ExitTime.Subtract(parking.EntryTime).TotalMinutes + "minutes" + "with charges Rs" + parking.Vehicle_Charge);
            }

            return parking;
        }

        /// <summary>
        /// Delete Record By Parking Id.
        /// </summary>
        /// <param name="parkingId">Parking Id.</param>
        /// <returns>Action Result.</returns>
        public string DeleteVehicle(int parkingId)
        {
            return this.repository.DeleteVehicle(parkingId);
        }
    }
}
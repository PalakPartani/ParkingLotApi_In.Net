// <copyright file="OwnerController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using ParkingLotBusinessLayer;
    using ParkingLotModelLayer;
    using Swashbuckle.AspNetCore.Annotations;

    /// <summary>
    /// Owner Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IParkingLotService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerController"/> class.
        /// </summary>
        /// <param name="service">IparkinglotService object.</param>
        public OwnerController(IParkingLotService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Parking vehicle.
        /// </summary>
        /// <param name="parkingLot">Model class.</param>
        /// <returns>parking lot object.</returns>
        [SwaggerOperation("parks the vehicle in lot.")]
        [Route("park")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parkingLot)
        {
            ParkingLot result = this.service.ParkVehicle(parkingLot);
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Vehicle not Parked", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Unparking vehicle.
        /// </summary>
        /// <param name="parkingSlot">slot Number.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("unparks the vehicle in lot.")]
        [Route("unpark")]
        [HttpPut]
        public ActionResult UnparkVehicle(int parkingSlot)
        {
            ParkingLot result = this.service.UnparkVehicle(parkingSlot);
            try
            {
                if (result.Vehicle_Number != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle UnParked Successfully", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Finds the vehicle.
        /// </summary>
        /// <param name="vehiclenumber">Inputs the number.</param>
        /// <returns>parking lot object.</returns>
        [SwaggerOperation("finds the vehicle by number.")]
        [Route("search/&vehiclenumber={vehiclenumber}")]
        [HttpGet]
        public ActionResult FindVehicleByVehicleNumber(string vehiclenumber)
        {
            ParkingLot result = this.service.FindVehicleByVehicleNo(vehiclenumber);
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle found", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Finds vehicle by slot no.
        /// </summary>
        /// <param name="slotNo">Inputs the slot no.</param>
        /// <returns>parking lot object.</returns>
        [SwaggerOperation("finds the vehicle by parking slot.")]
        [Route("search/slotno/{slotNo}")]
        [HttpGet]
        public ActionResult FindVehicleByParkingSlot(int slotNo)
        {
            ParkingLot result = this.service.FindVehicleBySlotNumber(slotNo);
            try
            {
                if (result.Vehicle_Number != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle found", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Finding record by id.
        /// </summary>
        /// <param name="parkingid">parking id.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("finds the vehicle by id.")]
        [Route("search/{parkingid}")]
        [HttpGet]
        public ActionResult FindVehicleByParkingId(int parkingid)
        {
            ParkingLot result = this.service.FindVehicleByParkingId(parkingid);
            {
                try
                {
                    if (result.Vehicle_Number != null)
                    {
                        return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle found", result));
                    }

                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", result));
                }
                catch (Exception e)
                {
                    return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
                }
            }
        }

        /// <summary>
        /// Fetch List Of All Empty Slots.
        /// </summary>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("searches for empty slots.")]
        [Route("search/emptyslots")]
        [HttpGet]
        public ActionResult FindAllEmptySlots()
        {
            List<int> result = this.service.FindEmptySlots();
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Empty Records are!", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No empty Found", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Fetch List Of All Vehicles.
        /// </summary>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("searches all vehicles in lot.")]
        [Route("search/allvehicles")]
        [HttpGet]
        public ActionResult FindAllVehicles()
        {
            List<ParkingLot> result = this.service.FindAllVehicles();
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "The Records are!", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No empty Found"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }

        /// <summary>
        /// Delete Record By Parking Id.
        /// </summary>
        /// <param name="parkingid">Parking Id.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("delete the record from lot.")]
        [Route("delete/{parkingid}")]
        [HttpDelete]
        public ActionResult DeleteByParkingId(int parkingid)
        {
            var result = this.service.DeleteVehicle(parkingid);
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Deleted Record! " + parkingid, result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No empty Found"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }
    }
}

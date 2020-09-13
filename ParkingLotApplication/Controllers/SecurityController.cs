// <copyright file="SecurityController.cs" company="PlaceholderCompany">
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
    /// Security Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IParkingLotService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityController"/> class.
        /// </summary>
        /// <param name="service">IparkinglotService object.</param>
        public SecurityController(IParkingLotService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Parking vehicle.
        /// </summary>
        /// <param name="parkingLot">Model class.</param>
        /// <returns>parking lot object.</returns>
        [SwaggerOperation("parks vehicle in lot.")]
        [Route("park")]
        [HttpPost]
        public ActionResult AddingVehicle([FromBody] Parking parkingLot)
        {
            ParkingLot result = this.service.ParkVehicle(parkingLot);
            try
            {
                if (result.Vehicle_Number != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Vehicle NOT Parked Successfully", result));
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
        [SwaggerOperation("unparks in lot.")]
        [Route("unpark")]
        [HttpPut]
        public ActionResult RemovingVehicle(int parkingSlot)
        {
            ParkingLot result = this.service.UnparkVehicle(parkingSlot);
            try
            {
                if (result != null)
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
        /// Finding record by vehicle number.
        /// </summary>
        /// <param name="vehicleNo">Vehicle Number.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("searches vehicle by number in lot.")]
        [Route("search/&vehiclenumber={vehiclenumber}")]
        [HttpGet]
        public ActionResult FindVehicleByVehicleNumber(string vehicleNo)
        {
            ParkingLot result = this.service.FindVehicleByVehicleNo(vehicleNo);
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
        /// Finding record by slot.
        /// </summary>
        /// <param name="slotNo">slot number.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("searches vehicle by slot no in lot.")]
        [Route("find/{slotno}")]
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
        /// <param name="id">parking id.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("searches vehicle by id in lot.")]
        [Route("find/{parkingid}")]
        [HttpGet]
        public ActionResult FindVehicleByParkingId(int id)
        {
            ParkingLot result = this.service.FindVehicleByParkingId(id);
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
}

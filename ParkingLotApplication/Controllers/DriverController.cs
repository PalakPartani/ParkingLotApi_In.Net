// <copyright file="DriverController.cs" company="PlaceholderCompany">
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
    /// Driver Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IParkingLotService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverController"/> class.
        /// </summary>
        /// <param name="service">IparkinglotService object.</param>
        public DriverController(IParkingLotService service)
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
        public ActionResult AddingVehicle([FromBody] Parking parkingLot)
        {
            ParkingLot result = this.service.ParkVehicle(parkingLot);
            try
            {
                if (result != null)
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
        [SwaggerOperation("unparks the vehicle in lot.")]
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
    }
}

// <copyright file="PoliceController.cs" company="PlaceholderCompany">
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
    /// Police controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly IParkingLotService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PoliceController"/> class.
        /// </summary>
        /// <param name="service">service.</param>
        public PoliceController(IParkingLotService service)
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
                if (result.Vehicle_Number != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Vehicle NOT Parked Successfully"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }

        /// <summary>
        /// Unparking vehicle.
        /// </summary>
        /// <param name="parkingSlot">Parking slot number.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("unparks the vehicle in lot.")]
        [Route("unpark")]
        [HttpPut]
        public ActionResult RemovingVehicle(int parkingSlot)
        {
            var result = this.service.UnparkVehicle(parkingSlot);
            try
            {
                if (result.Vehicle_Number != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle UnParked Successfully"));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }

        /// <summary>
        /// Finding record by vehicle number.
        /// </summary>
        /// <param name="vehicleNo">vehicle number.</param>
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

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }

        /// <summary>
        /// Finding record by slot.
        /// </summary>
        /// <param name="slotNo">slot number.</param>
        /// <returns>Action Result.</returns>
        [SwaggerOperation("searches vehicle by slotnumber in lot.")]
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

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
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

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }
    }
}

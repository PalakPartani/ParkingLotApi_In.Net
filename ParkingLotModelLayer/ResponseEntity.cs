// <copyright file="ResponseEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System.Net;

    /// <summary>
    /// Class to define response entity.
    /// </summary>
    public class ResponseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="httpStatusCode">Initialize code.</param>
        /// <param name="message">Initialize message.</param>
        /// <param name="data">Initalize data.</param>
        public ResponseEntity(HttpStatusCode httpStatusCode, string message, object data)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
            this.Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="httpStatusCode">Initialize code.</param>
        /// <param name="message">Initialize message.</param>
        public ResponseEntity(HttpStatusCode httpStatusCode, string message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets HttpStatusCode.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data.
        /// </summary>
        public object Data { get; set; }
    }
}

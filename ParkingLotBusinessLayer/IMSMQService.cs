// <copyright file="IMSMQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Experimental.System.Messaging;

    /// <summary>
    /// Providing MSMQ service.
    /// </summary>
    public interface IMSMQService
    {
        /// <summary>
        /// Adding message.
        /// </summary>
        /// <param name="message">Inputs the message.</param>
        void AddToQueue(string message);

        /// <summary>
        /// Recieving message.
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="eventArgs">arg to check status.</param>
        void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs eventArgs);
    }
}

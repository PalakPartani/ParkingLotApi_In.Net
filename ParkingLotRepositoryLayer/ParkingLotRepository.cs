// <copyright file="ParkingLotRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using ParkingLotModelLayer;

    /// <summary>
    /// Parking lot repository class.
    /// </summary>
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingLotRepository"/> class.
        /// </summary>
        /// <param name="configuration">sets the configuration.</param>
        public ParkingLotRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("ParkingLotDBConnection").Value;
            this.connection = new SqlConnection(this.connectionString);
        }

        /// <summary>
        /// Park Vehicle.
        /// </summary>
        /// <param name="parkingLot"> Parking object.</param>
        /// <returns> Parkinglot Model.</returns>
        public ParkingLot AddVehicle(Parking parkingLot)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spParkingLot", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parking_Slot", parkingLot.Parking_Slot);
                    cmd.Parameters.AddWithValue("@Vehicle_Number", parkingLot.Vehicle_Number);
                    cmd.Parameters.AddWithValue("@Vehicle_Type", parkingLot.VehicleType);
                    cmd.Parameters.AddWithValue("@Parking_Type", parkingLot.Parking_Type);
                    cmd.Parameters.AddWithValue("@Driver_Type", parkingLot.Driver_Type);
                    this.connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result > 0)
                    {
                        return this.FindVehicleByVehicleNo(parkingLot.Vehicle_Number);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Find Vehicle By Slot Number.
        /// </summary>
        /// <param name="slotNo"> Slot Number.</param>
        /// <returns>Parkinglot model.</returns>
        public ParkingLot FindVehicleBySlotNumber(int slotNo)
        {
            try
            {
                ParkingLot parkingLot = new ParkingLot();

                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetBySlotNumber", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parking_Slot", slotNo);
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            parkingLot.Parking_Id = Convert.ToInt32(reader["Parking_Id"]);
                            parkingLot.Parking_Slot = Convert.ToInt32(reader["Parking_Slot"]);
                            parkingLot.Parking_Type = Convert.ToInt32(reader["Parking_Type"]);
                            parkingLot.VehicleType = Convert.ToInt32(reader["Vehicle_Type"]);
                            parkingLot.Vehicle_Number = reader["Vehicle_Number"].ToString();
                            parkingLot.Driver_Type = Convert.ToInt32(reader["Driver_Type"]);
                            parkingLot.EntryTime = Convert.ToDateTime(reader["Entry_Time"]);
                            parkingLot.ExitTime = Convert.ToDateTime(reader["Exit_Time"]);
                            parkingLot.Vehicle_Charge = Convert.ToInt32(reader["Charge"]);
                        }
                    }

                    this.connection.Close();
                    string role = this.GetByRole(parkingLot.Parking_Slot);
                    parkingLot.Role = role;
                    return parkingLot;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Finding vehicle by number.
        /// </summary>
        /// <param name="vehicleNo">Vehicle Number.</param>
        /// <returns>ParkingLot Model.</returns>
        public ParkingLot FindVehicleByVehicleNo(string vehicleNo)
        {
            try
            {
                ParkingLot parkingLot = new ParkingLot();

                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetByVehicleNumber", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Vehicle_Number", vehicleNo);
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            parkingLot.Parking_Id = Convert.ToInt32(reader["Parking_Id"]);
                            parkingLot.Parking_Slot = Convert.ToInt32(reader["Parking_Slot"]);
                            parkingLot.Parking_Type = Convert.ToInt32(reader["Parking_Type"]);
                            parkingLot.VehicleType = Convert.ToInt32(reader["Vehicle_Type"]);
                            parkingLot.Vehicle_Number = reader["Vehicle_Number"].ToString();
                            parkingLot.Driver_Type = Convert.ToInt32(reader["Driver_Type"]);
                            parkingLot.EntryTime = Convert.ToDateTime(reader["Entry_Time"]);
                        }

                        this.connection.Close();
                        string role = this.GetByRole(parkingLot.Parking_Slot);
                        parkingLot.Role = role;
                        return parkingLot;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Gets role.
        /// </summary>
        /// <param name="parkingSlot">Inputs the slot.</param>
        /// <returns>the role.</returns>
        public string GetByRole(int parkingSlot)
        {
            try
            {
                ParkingLot parkingLot = new ParkingLot();

                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetRole", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parking_Slot", parkingSlot);
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           return parkingLot.Role = reader["Role_Type"].ToString();
                        }
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Remove vehicle.
        /// </summary>
        /// <param name="parkingSlot">Inputs the slot.</param>
        /// <returns>bool result.</returns>
        public ParkingLot UnparkVehicle(int parkingSlot)
        {
            ParkingLot parkingLot = new ParkingLot();
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd1 = new SqlCommand("spUnpark", this.connection);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Parking_Slot", parkingSlot);
                    this.connection.Open();

                    int result = cmd1.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return this.FindVehicleBySlotNumber(parkingSlot);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// finding by parking id.
        /// </summary>
        /// <param name="id">Parking Id.</param>
        /// <returns>parking object.</returns>
        public ParkingLot FindVehicleByParkingId(int id)
        {
            try
            {
                ParkingLot parkingLot = new ParkingLot();

                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetByParkingId", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parking_Id", id);
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            parkingLot.Parking_Id = Convert.ToInt32(reader["Parking_Id"]);
                            parkingLot.Parking_Slot = Convert.ToInt32(reader["Parking_Slot"]);
                            parkingLot.Parking_Type = Convert.ToInt32(reader["Parking_Type"]);
                            parkingLot.VehicleType = Convert.ToInt32(reader["Vehicle_Type"]);
                            parkingLot.Vehicle_Number = reader["Vehicle_Number"].ToString();
                            parkingLot.Driver_Type = Convert.ToInt32(reader["Driver_Type"]);
                            parkingLot.EntryTime = Convert.ToDateTime(reader["Entry_Time"]);
                        }
                    }

                    this.connection.Close();
                    string role = this.GetByRole(parkingLot.Parking_Slot);
                    parkingLot.Role = role;
                    return parkingLot;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Finding all empty slots.
        /// </summary>
        /// <returns>list of empty slots.</returns>
        public List<int> FindEmptySlots()
        {
            try
            {
                List<int> list = new List<int>();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmptySlots", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           int slotId = Convert.ToInt32(reader["Parking_Slot"]);

                           list.Add(slotId);
                        }
                    }

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Find all vehicles.
        /// </summary>
        /// <returns>list of all vehicles.</returns>
        public List<ParkingLot> FindAllVehicles()
        {
            try
            {
                List<ParkingLot> list = new List<ParkingLot>();

                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetAllVehicles", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ParkingLot parkingLot = new ParkingLot();
                            parkingLot.Parking_Id = Convert.ToInt32(reader["Parking_Id"]);
                            parkingLot.Parking_Slot = Convert.ToInt32(reader["Parking_Slot"]);
                            parkingLot.Parking_Type = Convert.ToInt32(reader["Parking_Type"]);
                            parkingLot.VehicleType = Convert.ToInt32(reader["Vehicle_Type"]);
                            parkingLot.Vehicle_Number = reader["Vehicle_Number"].ToString();
                            parkingLot.Driver_Type = Convert.ToInt32(reader["Driver_Type"]);
                            parkingLot.EntryTime = Convert.ToDateTime(reader["Entry_Time"]);
                            list.Add(parkingLot);
                        }
                    }

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Delete Record By Parking Id.
        /// </summary>
        /// <param name="parkingId">Parking Id.</param>
        /// <returns>String Message.</returns>
        public string DeleteVehicle(int parkingId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteVehicleRecord", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parking_Id", parkingId);

                    this.connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    ParkingLot parkingLot = this.FindVehicleByParkingId(parkingId);
                    if (parkingLot.Vehicle_Number != null)
                    {
                        return null;
                    }

                    return "Record Deleted Successfully";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
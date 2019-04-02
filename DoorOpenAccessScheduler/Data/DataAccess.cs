using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoorOpenAccessScheduler.Helpers;

namespace DoorOpenAccessScheduler.Data
{
    internal static class DataAccess
    {
        private static SqlConnection GetConnection()
        {
            var connectionString = ConfigurationHelper.ConnectionString;
            return new SqlConnection(connectionString);
        }

        public static List<BiometricDevice> GetBiometricDevices()
        {
            using (var connection = GetConnection())
            {
                var sqlCommand = "SELECT ID, HOSTNAME, PORT FROM BiometricDevice " +
                                 "WHERE LOCATION = @LOCATION ";

                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = sqlCommand;
                    cmd.Connection = connection;
                    cmd.Parameters.Add("@LOCATION", SqlDbType.NVarChar).Value = "SCHEDULED";

                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var output = new List<BiometricDevice>();
                        while (reader.Read())
                        {
                            output.Add(new BiometricDevice
                            {
                                ID = (Guid) reader["ID"], IPAddress = reader["HOSTNAME"].ToString(),
                                Port = Convert.ToUInt16(reader["PORT"])
                            });
                        }

                        return output;
                    }
                }
            }
        }
    }
}

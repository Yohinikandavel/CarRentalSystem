using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.SqlClient;

namespace CarRentalSystem.util
{
    public static class DBConnUtil
    {
        private static readonly string ConnectionString;

        static DBConnUtil()
        {
            var properties = LoadProperties();
            ConnectionString = $"Server={properties["server"]};Database={properties["database"]};Integrated Security=True;";
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        private static Dictionary<string, string> LoadProperties()
        {
            var properties = new Dictionary<string, string>();
            var propertiesFilePath = "dbconfig.properties";

            if (!File.Exists(propertiesFilePath))
                throw new FileNotFoundException($"Properties file not found: {propertiesFilePath}");

            foreach (var line in File.ReadAllLines(propertiesFilePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                var parts = line.Split('=', 2);
                if (parts.Length == 2)
                {
                    properties[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return properties;
        }
    }
}

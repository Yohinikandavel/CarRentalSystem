using System;
using System.Collections.Generic;
using System.IO;

namespace CarRentalSystem.util
{
    public static class PropertyUtil
    {
        private static readonly string PropertiesFilePath = "dbconfig.properties";

        public static Dictionary<string, string> LoadProperties()
        {
            var properties = new Dictionary<string, string>();

            if (!File.Exists(PropertiesFilePath))
            {
                throw new FileNotFoundException($"Properties file not found: {PropertiesFilePath}");
            }

            foreach (var line in File.ReadAllLines(PropertiesFilePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split('=',2);
                if (parts.Length == 2)
                {
                    properties[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return properties;
        }
    }
}
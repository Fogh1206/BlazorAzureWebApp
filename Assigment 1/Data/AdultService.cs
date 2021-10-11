using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Models;

namespace Assigment_1.Data
{
    public class AdultService : IAdultService
    {
        public IList<Adult> AdultsList { get;  set; }
        private string productsFile = "adults.json";

        public AdultService()
        {
            // Connect();
            if (!File.Exists(productsFile))
            {
                string productsAsJson = JsonSerializer.Serialize(AdultsList);
                File.WriteAllText(productsFile, productsAsJson);
            }
            else
            {
                string content = File.ReadAllText(productsFile);
                AdultsList = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }


        public void Save()
        {
            string productsAsJson = JsonSerializer.Serialize(AdultsList);
            File.WriteAllText(productsFile, productsAsJson);
        }

        public void Remove(int adultId)
        {
            foreach (var var in AdultsList)
            {
                if (var.Id.Equals(adultId))
                {
                    AdultsList.Remove(var);
                    break;
                }
            }
            Save();
        }
        
    }
}
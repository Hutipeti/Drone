using MezogazdasagiDron.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MezogazdasagiDron.Services
{
    public class TableStorageService
    {
        public static FarmEntity Insert(string userId, string farmName)
        {
            CloudStorageAccount storageAccount;
            var connectionString = ConfigurationManager.AppSettings["tableStorageConnectionString"];

            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                try
                {
                    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                    CloudTable table = tableClient.GetTableReference("farms");
                    table.CreateIfNotExists();

                    var farmId = Guid.NewGuid().ToString();
                    FarmEntity farm = new FarmEntity(userId, farmId)
                    {
                        FarmName = farmName
                    };

                    TableOperation operation = TableOperation.Insert(farm);
                    table.Execute(operation);

                    return farm;
                }
                catch(Exception ex)
                {

                }
            }

            return null;
        }

        public static FarmEntity Get(string userName, string farmId)
        {
            CloudStorageAccount storageAccount;
            var connectionString = ConfigurationManager.AppSettings["tableStorageConnectionString"];

            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                try
                {
                    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                    CloudTable table = tableClient.GetTableReference("farms");
                    table.CreateIfNotExists();

                    TableOperation operation = TableOperation.Retrieve(userName, farmId);
                    var result = table.Execute(operation);

                    return (FarmEntity)result.Result;
                }
                catch (Exception ex)
                {

                }
            }

            return null;
        }
    }
}
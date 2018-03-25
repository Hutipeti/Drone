using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MezogazdasagiDron.Models
{
    public class FarmEntity : TableEntity
    {
        public FarmEntity(string userName, string farmId)
        {
            this.PartitionKey = userName;
            this.RowKey = farmId;
        }

        public FarmEntity() { }

        public string FarmName { get; set; }

        public IList<ImageData> Images { get; set; } = new List<ImageData>();
    }

    public class ImageData
    {
        public string Name { get; set; }

        public float LatitudeDegrees { get; set; }

        public float LatitudeMinutes { get; set; }

        public float LatitudeSeconds { get; set; }

        public float LongitudeDegrees { get; set; }

        public float LongitudeMinutes { get; set; }

        public float LongitudeSeconds { get; set; }
    }
}
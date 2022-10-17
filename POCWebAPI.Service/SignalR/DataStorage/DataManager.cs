using POCWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCWebAPI.Service.DataStorage
{
    public static class DataManager
    {
        public static List<ChartModel> GetData()
        {
            var r = new Random();
            return new List<ChartModel>
            {
                new ChartModel { Data = new List<int> { r.Next(1,40) }, Label = "Red", backgroundColor = "#E74C3C"},
                new ChartModel { Data = new List<int> { r.Next(1,40) }, Label = "Blue", backgroundColor = "#5491DA"},
                new ChartModel { Data = new List<int> { r.Next(1,40) }, Label = "Green", backgroundColor = "#B2E0AA"},
                new ChartModel { Data = new List<int> { r.Next(1,40) }, Label = "Yellow", backgroundColor = "#D5E41B"}
            };
        }
    }
}

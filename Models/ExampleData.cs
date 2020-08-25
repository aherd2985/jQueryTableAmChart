using System;
using System.Collections.Generic;

namespace jQueryTableAmCharts.Models
{
    public class ExampleData
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Root
        {
            public List<List<string>> data { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;

namespace jQueryTableAmCharts.Models
{
    public class GraphData
    {
        public GraphData()
        {
            WPSalary = 0;
        }

        public string WorkPlace { get; set; }
        public Int32 WPSalary { get; set; }
        public IEnumerable<TitleData> TiteList { get; set; }
    }

    public class TitleData
    {
        public TitleData()
        {
            TitleSalary = 0;
        }

        public string Title { get; set; }
        public Int32 TitleSalary { get; set; }
    }
}

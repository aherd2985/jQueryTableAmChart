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
    public IEnumerable<TitleData> subData { get; set; }
  }

  public class TitleData
  {
    public TitleData()
    {
      value = 0;
    }

    public string name { get; set; }
    public Int32 value { get; set; }
  }
}

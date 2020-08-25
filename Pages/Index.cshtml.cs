using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using static jQueryTableAmCharts.Models.ExampleData;
using System.IO;
using jQueryTableAmCharts.Models;

namespace jQueryTableAmCharts.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
    }

    public void OnGet()
    {

    }

    public List<GraphData> GetGraphData()
    {
      string readText = string.Empty;
      using (var sr = new StreamReader("wwwroot/Data/arrays.txt"))
      {
        // Set the stream to the string variable
        readText = sr.ReadToEnd();
      }
      Root myDeserializedClass = JsonSerializer.Deserialize<Root>(readText);

      List<Person> personList = new List<Person>();
      foreach (List<string> personDetail in myDeserializedClass.data)
      {
        Person newPerson = new Person
        {
          WorkPlace = personDetail[2],
          Title = personDetail[1],
          Salary = Int32.Parse(personDetail[5].Substring(1).Replace(",", ""))
        };
        personList.Add(newPerson);
      }

      List<GraphData> returnGraphData = new List<GraphData>();
      List<GraphData> salaryGraphData =
                                        (from workPlace in personList
                                         group workPlace by workPlace.WorkPlace into workPlaceGroup
                                         select new GraphData
                                         {
                                           WorkPlace = workPlaceGroup.Key,
                                           WPSalary = workPlaceGroup.Sum(x => x.Salary)
                                         }).Cast<GraphData>().ToList();
      foreach (GraphData graphDataPoint in salaryGraphData)
      {
        GraphData returnGraphPoint = salaryGraphData.FirstOrDefault(x => x.WorkPlace == graphDataPoint.WorkPlace);
        if (returnGraphPoint != null)
          returnGraphPoint.subData = (from titlePoint in personList
                                       where titlePoint.WorkPlace == graphDataPoint.WorkPlace
                                       group titlePoint by titlePoint.Title into titlePointGroup
                                       select new TitleData
                                       {
                                         name = titlePointGroup.Key,
                                         value = titlePointGroup.Sum(x => x.Salary),
                                       }).Cast<TitleData>().ToList();
        returnGraphData.Add(returnGraphPoint);
      }
      return returnGraphData;
    }


  }
}

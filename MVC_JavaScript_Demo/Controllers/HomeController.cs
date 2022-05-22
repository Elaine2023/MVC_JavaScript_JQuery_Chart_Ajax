using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Start.Models;

namespace MVC_Start.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult IndexWithLayout()
    {
      return View();
    }

    /// <summary>
    /// Replicate the chart example in the JavaScript presentation
    /// 
    /// Typically LINQ and SQL return data as collections.
    /// Hence we start the example by creating collections representing the x-axis labels and the y-axis values
    /// However, chart.js expects data as a string, not as a collection.
    ///   Hence we join the elements in the collections into strings in the view model
    /// </summary>
    /// <returns>View that will display the chart</returns>
    public ViewResult DemoChart()
    {
        
      string[] ChartLabels = new string[] { "Argentina", "Bolivia", "Brazil", "Chile", "Colombia", "Ecuador", "Falkland Island",
          "French Guiana", "Guyana", "Paraguay", "Peru", "Suriname", "Uruguay", "Venezuela" };
      string[] ChartColors = new string[] { "#ff0000", "#cb4151", "#a0522d", "#faf0e6", "#ffba00", "#e5aa70", "#ffe135", "#bfff00", "#96a53c", "#006400", "#aaf0d1", 
          "#b9f2ff", "#e7feff", "#cf71af"};
      int[] ChartData = new int[] { 45195, 11673, 212559, 19116, 50882, 17643, 3,298,786,7132,32971,586,3473,28435 };

      ChartModel Model = new ChartModel
      {
        ChartType = "bar",
        Labels = String.Join(",", ChartLabels.Select(d => "'" + d + "'")),
        Colors = String.Join(",", ChartColors.Select(d => "\"" + d + "\"")),
        Data = String.Join(",", ChartData.Select(d => d)),
        Title = "Predicted South America Population (millions) in 2050"
      };

      return View(Model);
    }

    public ViewResult DemoAjax()
    {
      return View();
    }

    public JsonResult AjaxResult()
    {
      Task.WaitAll(Task.Delay(1000));

      return Json("Test");

    }
  }
}
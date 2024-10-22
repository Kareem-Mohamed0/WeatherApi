using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/Weather")]
    public class WeatherController : ControllerBase
    {
        public static List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        [HttpGet]
        public IActionResult GetAllSummaries()
        {
            //var weather = new { City = "new york", Temp = "22 C", Condition = "sunny" };
            var res = Summaries;
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetSummaryById(int id)
        {
            //var weather = new { City = "new york", Temp = "22 C", Condition = "sunny" };
            try
            {
                var res = Summaries[id - 1];
                if (res is not null)
                    return Ok(res);
                return NotFound();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateSummary([FromBody] Data Data)
        {
            //var weather = new { City = "new york", Temp = "22 C", Condition = "sunny" };
            try
            {
                Summaries.Add(Data.summer);
                return Ok(Summaries);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"Faild to add {Data.summer}");
            }
        }
        public class Data
        {
            public String summer { get; set; }
        }
        [HttpPut]
        public IActionResult EditSummary(string old_summer ,string summer)
        {
            //var weather = new { City = "new york", Temp = "22 C", Condition = "sunny" };
            try
            {
                var index = Summaries.IndexOf(old_summer);
                if (index == -1)
                    return NotFound();
                Summaries[index] = summer;
                return Ok(Summaries);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"Faild to add {summer}");
            }
        }
    }
}

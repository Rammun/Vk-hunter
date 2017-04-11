using System.Collections.Generic;
using System.Web.Http;

namespace VkHunter.Web.Controllers
{
    /// <summary>
    /// Для теста
    /// </summary>
    [RoutePrefix("api/test")]
    public class TestController : BaseController
    {
        [HttpGet]
        [Route("getValues")]
        public IEnumerable<string> GetValues()
        {
            return new string[] { $"TestController: {nameof(TestController)}", $"TestMethod: {nameof(GetValues)}" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}

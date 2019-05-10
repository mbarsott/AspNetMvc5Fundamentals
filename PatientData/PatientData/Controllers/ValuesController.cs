using System.Collections.Generic;
using System.Web.Http;

namespace PatientData.Controllers
{
    //    [Authorize]
    /// <summary>
    ///     Sample documentation here!
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ValuesController : ApiController
    {
        // GET api/values        
        /// <summary>
        ///     This is a method documentation.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
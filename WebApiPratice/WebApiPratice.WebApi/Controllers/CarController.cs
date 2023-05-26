using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPratice.WebApi.Controllers
{
    public class Info
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> cars { get; set; }
    }
    public class CarController : ApiController
    {

        // GET: api/Car
        public string Get(int id, string name)
        {
            return (Convert.ToString(id) + name);
        }

        // GET: api/Car
        public string Get([FromBody] Info info)
        {
            return (info.Name + info.Id);
        }

        // POST: api/Car
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Car/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Car/5
        public void Delete(int id)
        {
        }
    }
}

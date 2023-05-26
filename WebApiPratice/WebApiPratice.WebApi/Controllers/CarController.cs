using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiPratice.WebApi.Models;

namespace WebApiPratice.WebApi.Controllers
{
    public class CarController : ApiController
    {

        public List<Car> cars = new List<Car>
        {
            new Car { Id=1, Name="Juke", Brand="Nissan"},
            new Car { Id=2, Name="Cx-3", Brand="Mazda"},
            new Car { Id=3, Name="M3", Brand="BMW"}
        };


        // GET: api/Car/prim
        public string Get(int id, string name)
        {
            return (Convert.ToString(id) + name);
        }

        // GET: api/Car/get/body
        public string Get([FromBody] Info info)
        {
            return (info.Name + info.Id);
        }

        // POST: api/Car/post
        public HttpResponseMessage Post([FromBody]Car addCar)
        {
            if (addCar.Id > 3)
            {
                cars.Add(addCar);
                return Request.CreateResponse(HttpStatusCode.OK, "Data Succesfully Added");
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden);
        }

        // PUT: api/Car/put
        public HttpResponseMessage Put(int id, [FromBody]Car updateCar)
        {
            Car carToUpdate = cars.Find(car  => car.Id == id);
            int index = cars.FindIndex(carI => carI.Id == id);
            cars[index] = updateCar;
            return Request.CreateResponse(HttpStatusCode.OK, cars[1]);

        }

        // DELETE: api/Car/delete
        public HttpResponseMessage Delete(int id)
        {
            Car carToRemove = cars.Find(car => car.Id == id);
            if (carToRemove != null)
            {
                bool result = cars.Remove(carToRemove);
                if (result == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "The data succesfuly delleted");
                } 
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The data does not exist");

       
        }
    }
}

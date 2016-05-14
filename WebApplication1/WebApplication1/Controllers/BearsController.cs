using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.IO;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class BearsController : ApiController
    {
        // GET: api/Bears
        public IEnumerable<Bear> Get()
        {
            String JSONstring = File.ReadAllText(@"c:\dev\github\11-TopSpotsAPI\WebApplication1\WebApplication1\App_Data\json.json");
            List<Bear> myList = JsonConvert.DeserializeObject<List<Bear>>(JSONstring);
            Console.WriteLine(myList);
            return myList;
        }

        public Action<Bear> myList;

        // GET: api/Bears/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bears
        public void Post([FromBody]Bear value)
        {
            //load from file

            /*var JSONstring = File.ReadAllText(@"c:\dev\github\11-TopSpotsAPI\WebApplication1\WebApplication1\App_Data\json.json");
            var array = JArray.Parse(JSONstring);
            Console.Write(array);
            var Bear = new Bear();
            Bear.name = "nice place";
            Bear.description = "some info";
            Bear.location = new float[] { 32.990f, 17.890f };

            array.Add(Bear);

            var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(@"c:\dev\github\11 - TopSpotsAPI\WebApplication1\WebApplication1\App_Data\json.json", jsonToOutput);*/
            //save to file here*/
            var filePath = @"c:\dev\github\11-TopSpotsAPI\WebApplication1\WebApplication1\App_Data\json.json";
            // Read existing json data
            var JSONstring = File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var myList = JsonConvert.DeserializeObject<List<Bear>>(JSONstring)
                                ?? new List<Bear>();

             //Add any new employees
            myList.Add(new Bear()
            {
                /*name = "Test Person 1",
                description = "something",
                location = new float[] { 32.990f, 17.890f }*/
                name = value.name,
                description = value.description,
                location = value.location
            });
           

            //Update json data string
            JSONstring = JsonConvert.SerializeObject(myList);
            File.WriteAllText(filePath, JSONstring);
           


        }

        // PUT: api/Bears/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bears/5
        public void Delete(int id)
        {
        }
    }
}

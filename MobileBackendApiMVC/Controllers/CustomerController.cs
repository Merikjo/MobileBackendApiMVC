using MobileBackendApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileBackendApiMVC.Controllers
{
    public class CustomerController : ApiController
    {

        public string[] GetAll()
        {
            string[] customerNames = null;
            MobileWorkDataEntities entities = new MobileWorkDataEntities();
            try
            {
                customerNames = (from c in entities.Customers
                                 where (c.Active == true)
                                 select c.CustomerName).ToArray();
            }
            finally
            {
                entities.Dispose();
            }

            return customerNames;
        }



        #region
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using apitask.Models;

namespace apitask.Controllers
{
    public class suplierController : ApiController
    {
         NorthwindEntities1 db = new NorthwindEntities1();

        // GET: api/suplier
        public IHttpActionResult getall()
        {
            var suplier = from x in db.Suppliers
                          select new SuplierDTO()
                          {
                              SupplierID = x.SupplierID,
                              CompanyName = x.CompanyName


                          };

            return Ok(suplier);
        }

        // GET: api/suplier/id

        public IHttpActionResult getbyid(int id)
        {
            var result = from x in db.Suppliers
                         where x.SupplierID == id
                         select new SuplierDTO()
                         {
                             SupplierID = x.SupplierID,
                             CompanyName = x.CompanyName,
                         };

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        public IHttpActionResult Postsuplier(Supplier newsupplier)
        {

            if (newsupplier == null)
            {
                return BadRequest();
            }
            else
            {
                db.Suppliers.Add(newsupplier);
                db.SaveChanges();
                return Created("order", db.Suppliers);

            }


        }


        // PUT: api/suplier/id

        public IHttpActionResult Putsuplier(int id, Supplier s)
        {
            var result = db.Suppliers.Find(id);
            if (result == null)
            {
                return NotFound();

            }
            else
            {
                result.CompanyName = s.CompanyName;

                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        // DELETE: api/suplier/id

        public IHttpActionResult Deletesuplier(int id)

        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            else
            {
                db.Suppliers.Remove(supplier);
                db.SaveChanges();

                return Ok(supplier);
            }

        }




    }
}

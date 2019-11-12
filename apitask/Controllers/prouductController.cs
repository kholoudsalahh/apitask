using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apitask.Models;

namespace apitask.Controllers
{
    public class prouductController : ApiController
    {

         NorthwindEntities1 db = new NorthwindEntities1();

        // GET: api/prouduct
        //select
        public IHttpActionResult getall()
        {
            var product = from x in db.Products
                              select new ProductDTO()
                              {
                                  ProductID= x.ProductID,
                                  ProductName = x.ProductName,


                              };

            return Ok(product);
        }

        // GET: api/prouduct/id

        public IHttpActionResult getbyid(int id)
        {
            var result = from x in db.Products
                    where x.ProductID == id
                    select new ProductDTO()
                    {
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
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

        // POST: api/prouduct
        //create

        public IHttpActionResult Postproduct(Product newproduct)
        {

            if (newproduct == null)
            {
                return BadRequest();
            }
            else
            {
                db.Products.Add(newproduct);
                db.SaveChanges();
                return Created("product", db.Products);

            }


        }


        // PUT: api/prouduct/id
        //update

        public IHttpActionResult Putproduct(int id, Product pro)
        {
            Product result = db.Products.Find(id);
            if (result == null)
            {
                return NotFound();

            }
            else
            {
                result.ProductName = pro.ProductName;
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // DELETE: api/prouduct/id
        //delete
        public IHttpActionResult Deleteproduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                db.Products.Remove(product);
                db.SaveChanges();

                return Ok(product);
            }

        }


    }
}


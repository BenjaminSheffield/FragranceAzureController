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
using FragranceController;

namespace FragranceController.Controllers
{
    public class FragrancesController : ApiController
    {
        private FragranceReact db = new FragranceReact();

        // GET: api/Fragrances
        public List<Fragrance> GetFragrances(string house)
        {
            var relevantSearch = db.Fragrances.Where(x => x.House == house);
            List<Fragrance> fragranceList = new List<Fragrance>();

            foreach (var fragrance in relevantSearch)
            {
                fragranceList.Add(fragrance);
            }

            return fragranceList;
        }

        // GET: api/Fragrances/5
        [ResponseType(typeof(Fragrance))]
        public IHttpActionResult GetFragrance(int id)
        {
            Fragrance fragrance = db.Fragrances.Find(id);
            if (fragrance == null)
            {
                return NotFound();
            }

            return Ok(fragrance);
        }

        // PUT: api/Fragrances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFragrance(int id, Fragrance fragrance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fragrance.id)
            {
                return BadRequest();
            }

            db.Entry(fragrance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FragranceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Fragrances
        [ResponseType(typeof(Fragrance))]
        public IHttpActionResult PostFragrance(Fragrance fragrance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fragrances.Add(fragrance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fragrance.id }, fragrance);
        }

        // DELETE: api/Fragrances/5
        [ResponseType(typeof(Fragrance))]
        public IHttpActionResult DeleteFragrance(int id)
        {
            Fragrance fragrance = db.Fragrances.Find(id);
            if (fragrance == null)
            {
                return NotFound();
            }

            db.Fragrances.Remove(fragrance);
            db.SaveChanges();

            return Ok(fragrance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FragranceExists(int id)
        {
            return db.Fragrances.Count(e => e.id == id) > 0;
        }
    }
}
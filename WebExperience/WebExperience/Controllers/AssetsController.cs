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
using WebExperience.Models;

namespace WebExperience.Controllers
{
    public class AssetsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Assets
        public IQueryable<Asset> GetAssets()
        {
            return db.Assets.OrderByDescending(x => x.id);
        }
        // GET: api/Assets/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult GetAsset(int id)
        {
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }

        // PUT: api/Assets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsset(int id, Asset asset)
        {
            if (id != asset.id)
            {
                return BadRequest();
            }

            db.Entry(asset).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST: api/Assets
        [ResponseType(typeof(Asset))]
        [HttpPost]
        public IHttpActionResult PostAsset([FromBody] Asset Asset)
        {
            db.Assets.Add(Asset);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = Asset.id }, Asset);
        }


        // DELETE: api/Assets/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult DeleteAsset(int id)
        {
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            db.Assets.Remove(asset);
            db.SaveChanges();

            return Ok(asset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetExists(int id)
        {
            return db.Assets.Count(e => e.id == id) > 0;
        }
    }
}
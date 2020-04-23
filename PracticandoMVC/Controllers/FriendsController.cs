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
using PracticandoMVC.Models;

namespace PracticandoMVC.Controllers
{
    public class FriendsController : ApiController
    {
        private DataContext db = new DataContext();
        [Authorize]
        // GET: api/Friends
        public IQueryable<Friend> GetFriends()
        {
            return db.Friends;
        }
        [Authorize]
        // GET: api/Friends/5
        [ResponseType(typeof(Friend))]
        public IHttpActionResult GetFriend(int id)
        {
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }
        [Authorize]
        // PUT: api/Friends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFriend(int id, Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friend.FriendId)
            {
                return BadRequest();
            }

            db.Entry(friend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExists(id))
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
        [Authorize]
        // POST: api/Friends
        [ResponseType(typeof(Friend))]
        public IHttpActionResult PostFriend(Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Friends.Add(friend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = friend.FriendId }, friend);
        }
        [Authorize]
        // DELETE: api/Friends/5
        [ResponseType(typeof(Friend))]
        public IHttpActionResult DeleteFriend(int id)
        {
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return NotFound();
            }

            db.Friends.Remove(friend);
            db.SaveChanges();

            return Ok(friend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendExists(int id)
        {
            return db.Friends.Count(e => e.FriendId == id) > 0;
        }
    }
}
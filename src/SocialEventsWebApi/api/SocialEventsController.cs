using System.Collections.Generic;
using SocialEventsWebApi.models;
using Microsoft.AspNet.Mvc;
using System.Linq;
using System;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialEventsWebApi.api
{
    [Route("api/[controller]")]
    public class SocialEventsController : Controller
    {
        private readonly SocialEventsAppContext _dbContext;

        public SocialEventsController(SocialEventsAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region private methods
        private IActionResult processUpdate(SocialEvent socialEvent)
        {
            var existingSocialEvent = _dbContext.SocialEvents.FirstOrDefault(x => x.Id == socialEvent.Id);
            existingSocialEvent.MapUrl = socialEvent.MapUrl;
            existingSocialEvent.Title = socialEvent.Title;
            existingSocialEvent.Content = socialEvent.Content;
            existingSocialEvent.CreationDate = socialEvent.CreationDate.ToLocalTime();
            existingSocialEvent.EventDate = socialEvent.EventDate.ToLocalTime();
            _dbContext.SaveChanges();
            return new ObjectResult(existingSocialEvent);
        }

        #endregion
        // GET: api/values
        [HttpGet]
        public IEnumerable<SocialEvent> Get()
        {
            return _dbContext.SocialEvents;
            //return new List<SocialEvent> {
            //    new SocialEvent { Id = 1, Content = "Content for 1", CreationDate = DateTime.Now, EventDate = DateTime.Now.AddDays(1),MapUrl="",Title="Event 1" } ,
            //    new SocialEvent { Id = 2, Content = "Content for 2", CreationDate = DateTime.Now, EventDate = DateTime.Now.AddDays(2),MapUrl="",Title="Event 2" },
            //    new SocialEvent { Id = 3, Content = "Content for 3", CreationDate = DateTime.Now, EventDate = DateTime.Now.AddDays(3),MapUrl="",Title="Event 3"}
            //};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var socialEvent = _dbContext.SocialEvents.FirstOrDefault(x => x.Id == id);

            if(socialEvent != null)
            {
                return new ObjectResult(socialEvent);
            }
            else
            {
                return new HttpNotFoundResult();
            }
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SocialEvent socialEvent)
        {
            if (ModelState.IsValid)
            {
                if (socialEvent.Id == 0)
                {
                    //add new
                    socialEvent.CreationDate = DateTime.UtcNow;
                    socialEvent.EventDate = socialEvent.EventDate.ToLocalTime();
                    _dbContext.SocialEvents.Add(socialEvent);
                    _dbContext.SaveChanges();
                    return new ObjectResult(socialEvent);
                }
                else
                {
                    //update
                    return processUpdate(socialEvent);
                }
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SocialEvent socialEvent)
        {
            //update
            return processUpdate(socialEvent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var socialEvent = _dbContext.SocialEvents.FirstOrDefault(x => x.Id == id);
            _dbContext.SocialEvents.Remove(socialEvent);
            _dbContext.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}

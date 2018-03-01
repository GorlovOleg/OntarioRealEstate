//--- WebAPI2
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using OntarioRealEstate.DAL;
using OntarioRealEstate.Models.Property;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace OntarioRealEstate.Controllers
{
    [Produces("application/json")]
    [Route("api/pBrokersWebAPI")]
    public class pBrokersWebAPIController : Controller
    {
        //--- service is injected into the constructor of the controller  from Startup
        //--- Dependency Injection - Transient: A new instance is created every time, short term service by request 
        //--- services.AddEntityFramework().AddSqlServer().AddDbContext
        
        public PropertyDbContext db { get; set; }

        private PropertyDbContext _context;

        public pBrokersWebAPIController(PropertyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: api/pBrokersWebAPI
        [HttpGet]
        public IEnumerable<pBroker> GetpBrokers() 
        {
            return _context.pBrokers;
        }

//        [HttpGet]
        //--- api/GetReport
        //[Route("api/GetReport")]
        //--- 2.2 GetReport ---------------------------------------------
        //public JsonResult GetpBrokers(string sidx, string sord, int page, int rows, bool _search, string firstName, string lastName)  //Gets the Report Lists.
        //{
        //    var brokers = GetpBrokers() as IEnumerable<pBroker>;

        //    int pageIndex = Convert.ToInt32(page) - 1;
        //    int pageSize = 10;
        //    int rows_t = 10;

        //    //--- LINQ Method syntax 
        //    //--- LINQ http://www.tutorialsteacher.com/linq/linq-method-syntax
        //    //var ReportResults3 = db.Subscribers.Where(s => s.FirstName == "Tom").ToList<OntarioRealEstateCanada.Models.Subscriber>();

        //    //var ReportResults = db.pBrokers.Select(  
        //    //    _rows => new
        //    //    {
        //    //        _rows.pBrokerId,
        //    //        _rows.FirstName,
        //    //        _rows.LastName,
        //    //        _rows.Phone,
        //    //        _rows.Email,
        //    //        _rows.ImageUrl,
        //    //        _rows.pBrokerage
        //    //    });

        //    var ReportResults = from _pBrokerage in db.pBrokerages
        //                         join _pBroker in db.pBrokers on _pBrokerage.pBrokerageId equals _pBroker.pBrokerageId
        //                         select new
        //                         {
        //                             _pBroker.pBrokerId,
        //                             _pBroker.FirstName,
        //                             _pBroker.LastName,
        //                             _pBroker.Phone,
        //                             _pBroker.Email,
        //                             _pBroker.ImageUrl,
        //                             _pBroker.pBrokerage.pBrokerageName
        //                         };
        //    //var ReportResults = ReportResults2.AsEnumerable();



        //    //---var ReportResults2 = db.Subscribers.Include(s => s.Hospital).Include(s => s.SubAddress).Include(s => s.SubCredit);
        //    //var ReportResults2 = db.Subscribers;

        //    //            var Table3 = db.Subscribers.Include(s => s.Hospital).Include(s => s.SubAddress).Include(s => s.SubCredit).Dump("Subscribers");


        //    //if (!string.IsNullOrEmpty(firstName))
        //    //{
        //    //    ReportResults = ReportResults.Where(p => p.FirstName.Contains(firstName));
        //    //}
        //    //if (!string.IsNullOrEmpty(lastName))
        //    //{
        //    //    ReportResults = ReportResults.Where(p => p.LastName.Contains(lastName));
        //    //}

        //    //if (!string.IsNullOrEmpty(gender))
        //    //{
        //    //    ReportResults = ReportResults.Where(p => p.Gender.Contains(gender));
        //    //}
        //    /*
        //                //if ((!DateTime..IsNullOrEmpty(birthOfDate))
        //                //{
        //                //    ReportResults = ReportResults.Where(p => p.DateOfBirth >= birthOfDate);
        //                //}

        //    */
        //    int totalRecords = ReportResults.Count();
        //    //int totalRecords2 = ReportResults2.Count();

        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows_t);

        //    //if (sord.ToUpper() == "DESC")
        //    //{
        //    //ReportResults = ReportResults.OrderByDescending(s => s.FirstName);
        //    //ReportResults = ReportResults.Skip(pageIndex * pageSize).Take(pageSize);
        //    ////}

        //    //if (sord.ToUpper() == "DESC")
        //    //{
        //    //    ReportResults = ReportResults.OrderBy(s => s.FirstName);
        //    //    ReportResults = ReportResults.Skip(pageIndex * pageSize).Take(pageSize);
        //    //}

        //    var jsonData = new
        //    {
        //        total = totalPages,
        //        page,
        //        records = totalRecords,
        //        rows = ReportResults
        //    };
        //    return Json(jsonData);
        //} 

        // GET: api/pBrokersWebAPI/5
        [HttpGet("{id}", Name = "GetpBroker")]
        public IActionResult GetpBroker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pBroker pBroker = _context.pBrokers.Single(m => m.pBrokerId == id);

            if (pBroker == null)
            {
                return NotFound();
            }

            return Ok(pBroker);
        }

        // PUT: api/pBrokersWebAPI/5
        [HttpPut("{id}")]
        public IActionResult PutpBroker(int id, [FromBody] pBroker pBroker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pBroker.pBrokerId)
            {
                return BadRequest();
            }

            _context.Entry(pBroker).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pBrokerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/pBrokersWebAPI
        [HttpPost]
        public IActionResult PostpBroker([FromBody] pBroker pBroker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.pBrokers.Add(pBroker);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (pBrokerExists(pBroker.pBrokerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetpBroker", new { id = pBroker.pBrokerId }, pBroker);
        }

        // DELETE: api/pBrokersWebAPI/5
        [HttpDelete("{id}")]
        public IActionResult DeletepBroker(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pBroker pBroker = _context.pBrokers.Single(m => m.pBrokerId == id);
            if (pBroker == null)
            {
                return NotFound();
            }

            _context.pBrokers.Remove(pBroker);
            _context.SaveChanges();

            return Ok(pBroker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pBrokerExists(int id)
        {
            return _context.pBrokers.Count(e => e.pBrokerId == id) > 0;
        }
    }
}
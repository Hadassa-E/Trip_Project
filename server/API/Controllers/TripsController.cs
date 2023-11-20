using AutoMapper;
using BLL.interfacesBLL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        ItripBLL t;
        IorderBLL o;
        IkindBLL k;
        public TripsController(ItripBLL _t, IorderBLL o, IkindBLL k)
        {
            t = _t;
            this.o = o;
            this.k = k;
        }
        //GetAllTrips
        [HttpGet("GetAllTrips")]
        public ActionResult<List<Trip>> GetAllTrips()
        {
            return Ok(t.getAllTripBLL());
        }
        [HttpGet("GetAllTripsToShow")]
        public ActionResult<List<Trip>> GetAll()
        {
            return Ok(t.getAllTripBLL().Where(x=>x.TripDate>DateTime.Today));
        }
        //GetTripById
        [HttpGet("GetTripById/{id}")]
        public ActionResult<Trip> GetTripById(int id)
        {
            return Ok(t.GetTripBLL(id));
        }
        //GetInvitesToTripById
        [HttpGet("GetInvitesToTripById/{id}")]
        public ActionResult<List<Order>> getInvitesToTrip(int id)
        {
            return Ok(t.GetInvitesToTrip(t.GetTripBLL(id)));
        }
        //AddTrip
        [Route("AddTrip")]
        [HttpPost]
        public ActionResult<int> AddTrip([FromBody] TripDTO t1)
        {
            return Ok(t.AddTripBLL(t1));
        }
        //AddInviteToTrip
        [HttpPost("AddInviteToTrip")]
        public ActionResult<bool> AddInviteToTrip([FromBody] OrderDTO order)
        {

            return Ok(o.AddOrderBLL(order));
        }
        //UpdateTrip
        [HttpPut]
        [Route("UpdateTrip")]
        public ActionResult<bool> UpdateTrip([FromBody] TripDTO trip)
        {
            return Ok(t.UpdateTripBLL(trip));
        }

        //DeleteTrip
        [HttpDelete("DeleteTrip/{id}")]
        public ActionResult<bool> DeleteTrip(int id)
        {
            return Ok(t.DeleteTripBLL(id));
        }
        //getAllKind
        [HttpGet("getAllKind")]
        public ActionResult<List<Kind>> getAllKind()
        {
            return Ok(k.getAllKindBLL());
        }

        //DeleteOrder
        [HttpDelete("DeleteOrder/{id}")]
        public ActionResult<bool> DeleteOrder(int id)
        {
            return Ok(o.DeleteOrderBLL(id));
        }
        //GetAllToTrip-order
        [HttpGet("GetAllToTrip/{id}")]
        public ActionResult<List<Order>> GetAllToTrip(int id)
        {
            return Ok(o.GetAllToTripBLL(id));
        }
    }
}

using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class Racuncontroller
    {

        private readonly TrgovinaOdjecomContext _contex;
       

        public Racuncontroller(TrgovinaOdjecomContext contex) { _contex = contex; }
        [HttpGet]

        public IActionResult Get()
        {
            return new JsonResult(_contex.Racuni.ToList());
        }

        [HttpPost]
        public IActionResult Post(Racun racun)
        {
            _contex.Racuni.Add(racun);
            _contex.SaveChanges();


            return new JsonResult(racun);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            var RacunIzBaze = _contex.Racuni.Find(id);

            _contex.Racuni.Remove(RacunIzBaze);
            _contex.SaveChanges();
            return new JsonResult(new { poruka = "obrisano" });


        }
        [HttpPut]
        [Route("{id:int}")]


        public IActionResult Put(int id, Racun racun)
        {
            var RacunIzBaze = _contex.Racuni.Find(id);
            RacunIzBaze.Datum = racun.Datum;
            RacunIzBaze.Kupac = racun.Kupac;
       


            _contex.Racuni.Update(RacunIzBaze);
            _contex.SaveChanges();


            return new JsonResult(RacunIzBaze);
        }
    }
}

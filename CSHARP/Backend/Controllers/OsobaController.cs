using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OsobeController
    {
        private readonly TrgovinaOdjecomContext _contex;

        public OsobeController(TrgovinaOdjecomContext contex) { _contex = contex; }
        [HttpGet]

        public IActionResult Get()
        {

            return new JsonResult(_contex.Osobe.ToList());
        }

        [HttpPost]
        public IActionResult Post(Osoba osoba)
        {
            _contex.Osobe.Add(osoba);
            _contex.SaveChanges();


            return new JsonResult(osoba);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            var OsobeIzBaze = _contex.Osobe.Find(id);

            _contex.Osobe.Remove(OsobeIzBaze);
            _contex.SaveChanges();
            return new JsonResult(new { poruka = "obrisano" });


        }
        [HttpPut]
        [Route("{id:int}")]


        public IActionResult Put(int id, Osoba osoba)
        {
            var OsobeIzBaze = _contex.Osobe.Find(id);
            OsobeIzBaze.Ime = osoba.Ime;
            OsobeIzBaze.Prezime = osoba.Prezime;
            OsobeIzBaze.Email = osoba.Email;


            _contex.Osobe.Update(OsobeIzBaze);
            _contex.SaveChanges();


            return new JsonResult(OsobeIzBaze);
        }


    }
}

using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KupciController


    {

        private readonly TrgovinaOdjecomContext _contex;

        public KupciController(TrgovinaOdjecomContext contex) { _contex = contex; }
        [HttpGet]

        public IActionResult Get()
        {
          
            return new JsonResult(_contex.Kupci.ToList());
        }

        [HttpPost]
        public IActionResult Post(Kupac kupac)
        {
            _contex.Kupci.Add(kupac);
            _contex.SaveChanges();


            return new JsonResult(kupac);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            var SmjerIzBaze = _contex.Kupci.Find(id);

            _contex.Kupci.Remove(SmjerIzBaze);
            _contex.SaveChanges();
            return new JsonResult(new { poruka = "obrisano" });


        }
        [HttpPut]
        [Route("{id:int}")]


        public IActionResult Put(int id, Kupac kupac)
        {
            var KupacIzBaze = _contex.Kupci.Find(id);
            KupacIzBaze.Ime = kupac.Ime;
            KupacIzBaze.Prezime = kupac.Prezime;
            KupacIzBaze.Ulica = kupac.Ulica;
            KupacIzBaze.Mjesto = kupac.Mjesto;
            KupacIzBaze.Kontakt = kupac.Kontakt;


            _contex.Kupci.Update(KupacIzBaze);
            _contex.SaveChanges();


            return new JsonResult(KupacIzBaze);
        }


    }
}


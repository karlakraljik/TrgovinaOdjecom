using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StavkaController
    {
        private readonly TrgovinaOdjecomContext _contex;


        public StavkaController(TrgovinaOdjecomContext contex) { _contex = contex; }
        [HttpGet]

        public IActionResult Get()
        {
            return new JsonResult(_contex.Stavke.ToList());
        }

        [HttpPost]
        public IActionResult Post(Stavka stavka)
        {
            _contex.Stavke.Add(stavka);
            _contex.SaveChanges();


            return new JsonResult(stavka);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            var StavkeIzBaze = _contex.Stavke.Find(id);

            _contex.Stavke.Remove(StavkeIzBaze);
            _contex.SaveChanges();
            return new JsonResult(new { poruka = "obrisano" });


        }
        [HttpPut]
        [Route("{id:int}")]


        public IActionResult Put(int id, Stavka stavka)
        {
            var StavkeIzBaze = _contex.Stavke.Find(id);
            StavkeIzBaze.Racun = stavka.Racun;
            StavkeIzBaze.Proizvod = stavka.Proizvod;
            StavkeIzBaze.Kolicina = stavka.Kolicina;
            StavkeIzBaze.Cijena = stavka.Cijena;
      

            _contex.Stavke.Update(StavkeIzBaze);
            _contex.SaveChanges();


            return new JsonResult(StavkeIzBaze);
        }
    }
}

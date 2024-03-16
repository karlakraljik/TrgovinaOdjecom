using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class Proizvodcontroller
    {
        private readonly TrgovinaOdjecomContext _contex;


        public Proizvodcontroller(TrgovinaOdjecomContext contex) { _contex = contex; }
        [HttpGet]

        public IActionResult Get()
        {
            return new JsonResult(_contex.Proizvodi.ToList());
        }

        [HttpPost]
        public IActionResult Post(Proizvod proizvod)
        {
            _contex.Proizvodi.Add(proizvod);
            _contex.SaveChanges();


            return new JsonResult(proizvod);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            var ProizvodIzBaze = _contex.Proizvodi.Find(id);

            _contex.Proizvodi.Remove(ProizvodIzBaze);
            _contex.SaveChanges();
            return new JsonResult(new { poruka = "obrisano" });


        }
        [HttpPut]
        [Route("{id:int}")]


        public IActionResult Put(int id, Proizvod proizvod)
        {
            var ProizvodIzBaze = _contex.Proizvodi.Find(id);
            ProizvodIzBaze.Naziv = proizvod.Naziv;
            ProizvodIzBaze.Datumnabave = proizvod.Datumnabave;
            ProizvodIzBaze.Cijena = proizvod.Cijena;
            ProizvodIzBaze.Aktivan = proizvod.Aktivan;
          


            _contex.Proizvodi.Update(ProizvodIzBaze);
            _contex.SaveChanges();


            return new JsonResult(ProizvodIzBaze);
        }

    }
}

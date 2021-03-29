using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ImovelController : Controller
    {
        // GET: ImovelController
        Repository.DAL.Repository<Model.Imovel> repositotry;

        public ImovelController(Repository.DAL.Repository<Model.Imovel> repo)
        {
            repositotry = repo;
        }

        [HttpGet("imovel/index")]
        public IActionResult Index()
        {
            return Ok(repositotry.Get());            
        }

        // GET: ImovelController/Details/5
        [HttpGet("imovel/Details")]
        public ActionResult<Model.Imovel> Details(object id)
        {
            return Ok(repositotry.GetByID(id));
        }

        // POST: ImovelController/Create
        [HttpPost("imovel/create")]
        public ActionResult Create([FromBody] Model.Imovel imovel)
        {
            return Ok(repositotry.Insert(imovel));
        }


        // POST: ImovelController/Edit/5
        [HttpPost("imovel/edit")]
        public ActionResult Edit(int id, [FromBody] Model.Imovel imovel )
        {
            return Ok(repositotry.Update(imovel));
        }

        // GET: ImovelController/Delete/5
        [HttpPost("imovel/delete/{id}")]
        public ActionResult Delete(object id)
        {
            Model.Imovel imovel = repositotry.GetByID(id);
            repositotry.Delete(imovel);
            return Ok();
        }
        
    }
}

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

        /// <summary>
        /// Rota que retorna uma lista de Imovel
        /// </summary>
        /// <returns>IActionResult OK com uma lista Json do objeto Imovel no corpo da resposta</returns>
        [HttpGet("imovel/index")]
        public IActionResult Index()
        {
            return Ok(repositotry.Get());            
        }

        /// <summary>
        /// Rota que retorna uma lista de Imovel
        /// </summary>
        /// <returns>IActionResult OK com uma lista Json do objeto Imovel no corpo da resposta</returns>
        // GET: ImovelController/Details/5
        [HttpGet("imovel/Details")]
        public ActionResult<Model.Imovel> Details(object id)
        {
            return Ok(repositotry.GetByID(id));
        }

        /// <summary>
        /// Rota que cria um imovel que é passado como parametro
        /// </summary>
        /// <param name="imovel">Variavel imovel para criação</param>
        /// <returns>IActionResult OK com um Json do objeto Imovel no corpo da resposta</returns>
        // POST: ImovelController/Create
        [HttpPost("imovel/create")]
        public ActionResult Create([FromBody] Model.Imovel imovel)
        {
            return Ok(repositotry.Insert(imovel));
        }

        /// <summary>
        /// Rota para edição do imovel que é passado como parametro
        /// </summary>
        /// <param name="id">identificador do imovel</param>
        /// <param name="imovel">Variavel com os valores do imovel.</param>
        /// <returns>IActionResult OK com um Json do objeto Imovel no corpo da resposta</returns>
        // POST: ImovelController/Edit/5
        [HttpPost("imovel/edit")]
        public ActionResult Edit(int id, [FromBody] Model.Imovel imovel)
        {
            return Ok(repositotry.Update(imovel));
        }

        /// <summary>
        /// Rota para exclusão do imovel que é passado como parametro o identificador
        /// </summary>
        /// <param name="id">Identificador do imovel para exclusão</param>
        /// <returns></returns>
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

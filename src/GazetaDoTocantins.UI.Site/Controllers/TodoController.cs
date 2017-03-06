using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GazetaDoTocantins.UI.Site.Services;
using GazetaDoTocantins.UI.Site.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GazetaDoTocantins.UI.Site.Controllers
{
    [Route("/api/todos")]
    [AutoValidateAntiforgeryToken]
    public class TodoController : Controller
    {
        private ITodoService service;
        public TodoController(ITodoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Json(service.Get().Where(t => !t.Done));
        }

        [HttpPut]
        public IActionResult CreateTodo([FromBody]TodoModel model)
        {
            return Json(service.Create(model));
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult UpdateTodo(string id, [FromBody]TodoModel model)
        {
            service.Update(id, model);
            return new OkResult();
        }
    }
}

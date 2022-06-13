using Microsoft.AspNetCore.Mvc;
using ColourAPI.Models;
using System.Collections.Generic;
using System.Linq;
namespace ColourAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColourController:ControllerBase
    {
        private readonly ColourContext _context;
        public ColourController(ColourContext context){
            _context=context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colour>> Get(){
            return _context.ColourItems.ToList();
        }
    }
}
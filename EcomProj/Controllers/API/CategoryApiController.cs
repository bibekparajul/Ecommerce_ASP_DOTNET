using EcomProj.DataAccess.Data;
using EcomProj.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EcomProj.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Use /api/category/all the  [HttpGet("All")] maps it as /api/category +...
        [HttpGet("All")]
        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }



    }
}

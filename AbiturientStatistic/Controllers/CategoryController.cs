using DAL.Entity;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return (IEnumerable<Category>)_unitOfWork.CategoryRepository.Get();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category == null) return BadRequest();

            _unitOfWork.CategoryRepository.Insert(category);
            _unitOfWork.Save();

            return Ok("Successfully created new category!");
        }
        [HttpPut]
        public ActionResult Edit(Category category)
        {
            if (category == null) return BadRequest();

            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Save();

            return Ok("Successfully updated selected category!");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoryToRemove = _unitOfWork.CartRepository.GetById(id);

            if (categoryToRemove == null) return BadRequest();

            _unitOfWork.CategoryRepository.Delete(categoryToRemove);
            _unitOfWork.Save();

            return Ok("Successfully deleted selected category!");
        }

    }
}

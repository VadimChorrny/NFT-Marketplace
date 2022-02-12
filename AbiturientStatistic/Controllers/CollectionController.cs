using DAL.Entity;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CollectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Collection> Get()
        {
            return (IEnumerable<Collection>)_unitOfWork.CollectionRepository.Get();
        }
        public ActionResult Create(Collection collection)
        {
            if (collection == null) return BadRequest();

            _unitOfWork.CollectionRepository.Insert(collection);
            _unitOfWork.Save();

            return Ok("Successfully created new collection!");
        }
        [HttpPut]
        public ActionResult Edit(Collection collection)
        {
            if (collection == null) return BadRequest();

            _unitOfWork.CollectionRepository.Update(collection);
            _unitOfWork.Save();

            return Ok("Successfully updated selected collection!");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var collectionToRemove = _unitOfWork.CartRepository.GetById(id);

            if (collectionToRemove == null) return BadRequest();

            _unitOfWork.CollectionRepository.Delete(collectionToRemove);
            _unitOfWork.Save();

            return Ok("Successfully deleted selected collection!");
        }
    }
}

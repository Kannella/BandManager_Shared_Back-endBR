using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BandManager.Api.Resources.Exceptions;

namespace BandManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectDbController<E> : ControllerBase where E : Entity
	{
		protected readonly IDirectDbService<E> _directDbService;

		public DirectDbController(BandManagerContext context) : base()
		{
			_directDbService = new DirectDbService<E>(new DirectDbRepository<E>(context));
		}

		[HttpGet]
		public IActionResult GetAll(bool includeChildren = false)
		{
			try
			{
				List<E> entity = _directDbService.GetAll(includeChildren);

				if (entity.Count == 0) return NotFound();

				return Ok(entity);
			}
			catch (NoEntitiesFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception)
			{
				return Problem();
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id, bool includeChildren = true)
		{
			try
			{
				E entity = _directDbService.GetById(id, includeChildren);

				if (entity == null) return NotFound();

				return Ok(entity);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception)
			{
				return Problem();
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			try
			{
				E entity = _directDbService.GetById(id);
				_directDbService.Delete(entity);
				return Ok();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception)
			{
				return Problem();
			}
		}

        /*public IActionResult Delete(int id) //Probably shouldn't use this here, as this can't be used to delete references. Implement specific delete methods in the controllers
		{
			try
			{
				E entity = _directDbService.GetById(id);
				if (entity == null) return NotFound();
				_directDbService.Delete(entity);
				return Ok();
			}
			catch (Exception)
			{
				return Problem(statusCode:500);
			}
		}*/
    }
}
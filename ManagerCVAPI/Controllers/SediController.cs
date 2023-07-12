using ManagerCVAPI.Model.Interfaces;
using ManagerCVAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ManagerCVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SediController : ControllerBase
    {
        private IRepository repository;
        public SediController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSede()
        {
            return Ok(await repository.Sedi.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSedeById(int id)
        {
            try
            {
                var response = await repository.Sedi.Where(s => s.Id.Equals(id)).ToListAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostSede(Sede sede)
        {
            repository.AddSede(sede);
            return Created("api/Sedi", await repository.Sedi.ToListAsync());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSede(Sede sede)
        {
            try
            {
                repository.UpdateSede(sede);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Accepted(await repository.Sedi.ToListAsync());
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSede(Sede sede)
        {
            try
            {
                repository.DeleteSede(sede);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Accepted(await repository.Sedi.ToListAsync());
        }
    }
}

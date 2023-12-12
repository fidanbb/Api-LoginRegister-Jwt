using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;
using Service.DTOs.Employee;
using Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_OnionArchitecture.Controllers
{
    
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto request)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _employeeService.CreateAsync(request);

            return Ok();
        }

        [HttpDelete]
        
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            return Ok(await _employeeService.DeleteAsync(id));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {
                var data=await _employeeService.GetByIdAsync(id);
                return Ok(data);
            }

            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            
        }


        [HttpPut]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute]int? id, [FromBody]EmployeeEditDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _employeeService.UpdateAsync(id, request));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllByFullName([FromQuery]string fullName)
        {
            try
            {
                return Ok(await _employeeService.GetAllByFullNameAsync(fullName));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
    }
}


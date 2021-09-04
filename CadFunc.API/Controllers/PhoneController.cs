using CadFunc.Application.DTOs;
using CadFunc.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CadFunc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PhoneController : ControllerBase
    {
        private IPhoneService _phoneService;
        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PhoneDTO>>> Get()
        {
            var phones = await _phoneService.GetPhones();
            if (phones == null)
            {
                return NotFound("Phones Not Found.");
            }
            return Ok(phones);
        }

        [HttpGet("{id:int}", Name = "GetPhone")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PhoneDTO>> Get(int id)
        {
            if (id < 0)
                return BadRequest("Invalid Id.");

            var phone = await _phoneService.GetById(id);
            if (phone == null)
            {
                return NotFound("Phone Not Found.");
            }
            return Ok(phone);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] PhoneDTO phoneDTO)
        {
            if (phoneDTO == null)
                return BadRequest("Invalid Data.");

            await _phoneService.Add(phoneDTO);

            return new CreatedAtRouteResult("GetPhone", new { id = phoneDTO.Id }, phoneDTO);
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, [FromBody] PhoneDTO phoneDTO)
        {
            if (phoneDTO == null)
                return BadRequest("Invalid Data.");

            if (id != phoneDTO.Id)
                return BadRequest("The Id from parameters should be equal to the Id from JSON body.");

            var phone = await _phoneService.GetById(id);
            if (phone == null)
            {
                return NotFound("Phone Not Found.");
            }

            try
            {
                await _phoneService.Update(phoneDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Error trying to update de phone" + ex.Message);
            }
            return Ok(phoneDTO);
        }

        [HttpDelete("{id:int}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PhoneDTO>> Delete(int id)
        {
            if (id < 0)
                return BadRequest("Invalid Id.");

            var phone = await _phoneService.GetById(id);
            if (phone == null)
            {
                return NotFound("Phone Not Found.");
            }

            await _phoneService.Remove(id);
            return Ok(phone);
        }
    }
}

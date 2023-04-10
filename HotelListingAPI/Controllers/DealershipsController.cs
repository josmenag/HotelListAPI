using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Country;
using AutoMapper;
using HotelListingAPI.Contracts;
using HotelListingAPI.Repository;
using Microsoft.AspNetCore.Authorization;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDealershipsRepository _dealershipsRepository;

        public DealershipsController(IMapper mapper, IDealershipsRepository dealershipsRepository)
        {
            this._mapper = mapper;
            this._dealershipsRepository = dealershipsRepository;
        }

        // GET: api/Dealerships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDealershipDto>>> GetDealerships()
        {
            var dealerships = await _dealershipsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetDealershipDto>>(dealerships);
            return Ok(records);
        }

        // GET: api/Dealerhips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DealershipDto>> GetDealership(int id)
        {
            var dealership = await _dealershipsRepository.GetDetails(id);

            if (dealership == null)
            {
                return NotFound();
            }

            var dealershipDto = _mapper.Map<DealershipDto>(dealership);

            return Ok(dealershipDto);
        }

        // PUT: api/Dealership/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> PutDealership(int id, UpdateDealershipDto updateDealershipDto)
        {
            if (id != updateDealershipDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var dealership = await _dealershipsRepository.GetAsync(id);

            if (dealership == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDealershipDto, dealership);

            try
            {
                await _dealershipsRepository.UpdateAsync(dealership);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DealershipExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dealership
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Dealership>> PostDealership(CreateDealershipDto createDealershipDto)
        {
            var dealership = _mapper.Map<Dealership>(createDealershipDto);

            await _dealershipsRepository.AddAsync(dealership);

            return CreatedAtAction("GetDealership", new { id = dealership.Id }, dealership);
        }

        // DELETE: api/Dealership/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteDealership(int id)
        {
            var dealership = await _dealershipsRepository.GetAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }

            await _dealershipsRepository.DeleteAsync(id);            
            return NoContent();
        }

        private async Task<bool> DealershipExists(int id)
        {
            return await _dealershipsRepository.Exists(id);
        }
    }
}

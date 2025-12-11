using AirlineManagement.Data;
using AirlineManagement.Model.DTO;
using AirlineManagement.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace AirlineManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public AirportsController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            //get data from database= domain Model
            var AirportDMs = dbContext.Airports.ToList();

            //convert Domain model to DTO
            var airportDto = new List<AirportDto>();
            foreach (var AirportDM in AirportDMs)
            {
                airportDto.Add(new AirportDto()
                {
                    AirportID = AirportDM.AirportID,
                    Name = AirportDM.Name,
                    Code = AirportDM.Code,
                    City = AirportDM.City,
                    Country = AirportDM.Country
                });
            }

            return Ok(airportDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddPort([FromBody] AddPortRequestDto addPortRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                //need to convert portDto to PortDM
                var airport = new Airport
                {
                    AirportID = Guid.NewGuid(),
                    Name = addPortRequestDto.Name,
                    Code = addPortRequestDto.Code,
                    City = addPortRequestDto.City,
                    Country = addPortRequestDto.Country,

                    OriginFlights = new List<Flight>(),
                    DestinationFlights = new List<Flight>()
                };

                //Save Domain domain model data
                dbContext.Airports.Add(airport);
                dbContext.SaveChanges();

                //show data in DTO
                var response = new AirportDto
                {
                    AirportID = airport.AirportID,
                    Name = airport.Name,
                    Code = airport.City,
                    Country = airport.Country
                };

                return Ok(response);
            }
        }

        [HttpGet]
        [Route("{AirportID:Guid}")]
        public  async Task<IActionResult> GetById([FromRoute] Guid AirportID)
        {
            var DataDM = dbContext.Airports.FirstOrDefaultAsync(x => x.AirportID == AirportID);

            if(DataDM==null)
            {
                return NotFound();
            }
            else
            {
                //fetch domain to dto
                var airportDto = new AirportDto
                {
                    AirportID = AirportID,
                    Name = DataDM.Result.Name,
                    Code = DataDM.Result.Code,
                    City=DataDM.Result.City,
                    Country=DataDM.Result.Country
                };


                return Ok(airportDto);
            }
        }

        [HttpPut]
        [Route("{AirportID:Guid}")]
        public async Task<IActionResult> ModifyPort([FromRoute] Guid AirportID, [FromBody] UpdatePortRequestDto updatePortRequestDto)
        {
            var AirportDataDM = dbContext.Airports.FirstOrDefaultAsync(x => x.AirportID == x.AirportID);

            if(AirportDataDM==null)
            {
                return BadRequest();
            }
            else
            {
                //fetch DTO to Domain Model
                AirportDataDM.Result.Name = updatePortRequestDto.Name;
                AirportDataDM.Result.Code = updatePortRequestDto.Code;
                AirportDataDM.Result.City = updatePortRequestDto.City;
                AirportDataDM.Result.Country = updatePortRequestDto.Country;

                dbContext.SaveChanges();


                //convert into DTOs
                var airportDto = new AirportDto
                {
                    Name = AirportDataDM.Result.Name,
                    Code = AirportDataDM.Result.Code,
                    City = AirportDataDM.Result.City,
                    Country = AirportDataDM.Result.Country
                };

                return Ok(airportDto);
            }
        }

        [HttpDelete]
        [Route("{AirportID:guid}")]
        public async Task<IActionResult> RemovePortDetails([FromRoute] Guid AirportID)
        {
            var airportDM = dbContext.Airports.FirstOrDefaultAsync(x => x.AirportID == x.AirportID);

            if(airportDM==null)
            {
                return BadRequest();
            }
            else
            {
                dbContext.Airports.Remove(airportDM.Result);
                dbContext.SaveChanges();

                //return deleted port to DTO
                var airportDto = new AirportDto
                {
                    AirportID= airportDM.Result.AirportID,
                    Name = airportDM.Result.Name,
                    Code = airportDM.Result.Code,
                    City = airportDM.Result.City,
                    Country = airportDM.Result.Country
                };

                return Ok();
            }
        }
    }
}

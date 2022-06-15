using Game.Ordering.Grpc;
using Game.Store.Application.Store.Commands;
using Game.Store.Application.Store.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Store.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetGameItem")]       
        public async Task<IActionResult> GetGameItem()
        {
            var query = new GetStoreItemQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create([FromBody] CreateGameItemCommand command)
        {

            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine(z.Id);
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet(Name = "TimeZone")]
        public async Task<IActionResult> TimeZone()
        {

            //foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            //{
            //    Console.WriteLine(z.Id);
            //}

            var zones = TimeZoneInfo.GetSystemTimeZones().Select(r => r.Id).ToList();


            return Ok(zones);
        }


    }
}

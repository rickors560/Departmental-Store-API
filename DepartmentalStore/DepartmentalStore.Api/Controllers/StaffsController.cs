using DepartmentalStore.Application.Contracts.Persistence;
using DepartmentalStore.Application.Features.Staff.Commands.CreateStaff;
using DepartmentalStore.Application.Features.Staff.Commands.DeleteStaff;
using DepartmentalStore.Application.Features.Staff.Commands.UpdateStaff;
using DepartmentalStore.Application.Features.Staff.Queries.GetStaff;
using DepartmentalStore.Application.Features.Staff.Queries.GetStaffs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStore.Api.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly LinkGenerator _linkGenerator;

        public StaffsController(IMediator mediator, LinkGenerator linkGenerator)
        {
            this._mediator = mediator;
            this._linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetStaffsVM>>> GetAllStaffs(bool includeAddress = false) {
            try
            {
                var results = await _mediator.Send(new GetStaffsQuery { IncludeAddress = includeAddress });
                return results;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetStaffVM>> GetStaff(int id,bool includeAddress = false) {
            try
            {
                var staff = await _mediator.Send(new GetStaffQuery { Id = id, IncludeAddress = includeAddress });
                if(staff == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Staff ID not found.");
                }
                return staff;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateStaffVM>> PostStaff(CreateStaffVM createStaffVM)
        {
            try
            {
                var staff = await _mediator.Send(new CreateStaffCommand { CreateStaffVM = createStaffVM });

                var location = _linkGenerator.GetPathByAction("GetStaff", "Staffs", new { id = staff.Id });
                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current ID");
                }

                return this.Created(location, staff);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UpdateStaffVM>> PutStaff(int id, UpdateStaffVM updateStaffVM) {
            try
            {
                if (updateStaffVM.Id == 0) {
                    updateStaffVM.Id = id;      //In Case of Null
                }

                if (id != updateStaffVM.Id) {
                    return this.BadRequest("Id must be same.");
                }

                var staff = await _mediator.Send(new UpdateStaffCommand { UpdateStaffVM = updateStaffVM });

                var location = _linkGenerator.GetPathByAction("GetStaff", "Staffs", new { id = staff.Id });
                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current ID");
                }

                return this.Accepted(location, staff);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStaff(int id) {
            try
            {
                await _mediator.Send(new DeleteStaffCommand { Id = id });
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
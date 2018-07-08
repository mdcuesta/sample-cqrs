using Microsoft.AspNetCore.Mvc;
using Sampler.CQRS.Core;
using Sampler.CQRS.Source.Commands;
using Sampler.CQRS.Source.Queries;

namespace Sampler.CQRS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public DepartmentsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public ActionResult<GetAllDepartmentsQueryResult> Index()
        {
            var query = new GetAllDepartmentsQuery();
            return this.queryDispatcher.Dispatch<GetAllDepartmentsQuery, GetAllDepartmentsQueryResult>(query);
        }

        [Route("executeCommand")]
        [HttpGet]
        public void Post()
        {
            var command = new CreateDepartmentCommand
            {
                Name = "someName",
            };

            this.commandDispatcher.Dispatch(command);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thales.DotNet.Tech.Domain.Dto;
using Thales.DotNet.Tech.Domain.Services;
using Thales.DotNet.Tech.Infrastructure.Adapters;

namespace Thales.DotNet.Tech.Application.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _service;
        private readonly IGeneralConfiguration _configuration;
        public IEnumerable<EmployeeDto> AllEmployee = new List<EmployeeDto>();

        public EmployeeController(ILogger<EmployeeController> logger, IGeneralConfiguration configuration, IEmployeeService service)
        {
            _logger = logger;
            _configuration = configuration;
            _service = service;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            try
            {
                AllEmployee = _service.GetAllEmployees().Result;
                return View(AllEmployee);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int Id)
        {
            if (Id <= 0) return View();

            var employee = _service.GetEmployeeById(Id).Result;
            return View(employee);
        }
    
    }
}

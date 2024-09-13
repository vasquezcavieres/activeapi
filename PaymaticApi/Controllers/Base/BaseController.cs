

using AutoMapper;
using Cl.Intertrade.ActivPay.Helpers.Base;

namespace Cl.Intertrade.ActivPay.Controllers.Base
{
    public class BaseController<T> : Microsoft.AspNetCore.Mvc.Controller
    {
        public ILogger<T> logger;
        public IMapper mapper;
        public ISettingsConfig settings { get; set; }
        public IWebHostEnvironment environment { get; set; }
    }
}

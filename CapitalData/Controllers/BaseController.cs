using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CapitalData.Utilities;
using Microsoft.AspNetCore.Mvc;
using ProPublicaSDK;

namespace CapitalData.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly ProPublica _proPublica;
        protected static readonly string DefaultCongress = ConfigurationManager.GetConfiguration("DefaultCongress");
        protected static readonly string SenateChamber = ConfigurationManager.GetConfiguration("SenateChamber");
        protected static readonly string HouseChamber = ConfigurationManager.GetConfiguration("HouseChamber");
        public BaseController(IMapper mapper = null, ProPublica proPublica = null)
        {
            _mapper = mapper;
            _proPublica = proPublica;
        }
    }
}
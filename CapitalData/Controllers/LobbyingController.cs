using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CapitalData.Models;
using Microsoft.AspNetCore.Mvc;
using ProPublicaSDK;

namespace CapitalData.Controllers
{
    public class LobbyingController : BaseController
    {
        public LobbyingController(IMapper mapper, ProPublica proPublica) : base(mapper, proPublica) { }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            var lobbyingRepresentations = _proPublica.Lobbying.GetRecentLobbyingRepresentations();
            return PartialView("_List", _mapper.Map<List<LobbyingRepresentationViewModel>>(lobbyingRepresentations));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CapitalData.Models;
using Microsoft.AspNetCore.Mvc;
using ProPublicaSDK;

namespace CapitalData.Controllers
{
    public class CommitteesController : BaseController
    {
        public CommitteesController(IMapper mapper, ProPublica proPublica) : base(mapper, proPublica) { }
        public IActionResult Index(string congress, string chamber)
        {
            congress = !string.IsNullOrEmpty(congress) ? congress : DefaultCongress;
            chamber = !string.IsNullOrEmpty(chamber) ? chamber : SenateChamber;
            ViewData["congress"] = congress;
            ViewData["chamber"] = chamber;
            return View();
        }
        public IActionResult List(string congress, string chamber)
        {
            ViewData["congress"] = congress;
            ViewData["chamber"] = chamber;
            var committees = _proPublica.Committees.GetCommittees(congress, chamber);
            return PartialView("_List", _mapper.Map<List<CommitteeViewModel>>(committees));
        }
        public IActionResult Details(string id, string congress, string chamber)
        {
            ViewData["congress"] = congress;
            ViewData["chamber"] = chamber;
            var committe = _proPublica.Committees.GetCommittee(id, congress, chamber);
            return View(_mapper.Map<CommitteeViewModel>(committe));
        }
    }
}
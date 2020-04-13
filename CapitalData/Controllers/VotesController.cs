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
    public class VotesController : BaseController
    {
        public VotesController(IMapper mapper, ProPublica proPublica) : base(mapper, proPublica) { }
        public IActionResult Index(string chamber)
        {
            chamber = !string.IsNullOrEmpty(chamber) ? chamber : HouseChamber;
            ViewData["chamber"] = chamber;
            return View();
        }
        public IActionResult List(string chamber)
        {
            ViewData["chamber"] = chamber;
            var recentVotes = _proPublica.Votes.GetRecentVotes(chamber);
            var votes = _mapper.Map<List<VoteViewModel>>(recentVotes);
            var labels = votes.Select(v => v.result).Distinct();
            var data = new List<int>();
            labels.ToList()
                .ForEach(x => data.Add(votes.Count(c => c.result == x)));
            return PartialView("_List", new VoteListViewModel(votes, labels, data));
        }
        public IActionResult Details(string congress, string chamber, int sessionNumber, int rollCallNumber)
        {
            var vote = _proPublica.Votes.GetRoleCallVote(congress, chamber, sessionNumber.ToString(), rollCallNumber.ToString());
            return View(_mapper.Map<VoteViewModel>(vote));
        }
    }
}
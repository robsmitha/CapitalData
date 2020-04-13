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
    public class MembersController : BaseController
    {
        public MembersController(IMapper mapper, ProPublica proPublica) : base(mapper, proPublica) { }
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
            var members = _proPublica.Members.GetMembers(congress, chamber);
            return PartialView("_List", _mapper.Map<List<MemberViewModel>>(members));
        }

        public async Task<IActionResult> Details(string id)
        {
            try
            {
                ViewData["memberId"] = id;
                var member = _proPublica.Members.GetMember(id);
                return View(_mapper.Map<MemberViewModel>(member));
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        public async Task<IActionResult> Votes(string id)
        {
            try
            {
                ViewData["memberId"] = id;
                var member = _proPublica.Members.GetMember(id); 
                var votes = _proPublica.Members.GetMemberVotes(id);
                return View(new MemberVotesViewModel(_mapper.Map<List<VoteViewModel>>(votes), _mapper.Map<MemberViewModel>(member)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        public async Task<IActionResult> Bills(string id)
        {
            try
            {
                ViewData["memberId"] = id;
                var member = _proPublica.Members.GetMember(id);
                var bills = _proPublica.Members.GetMemberBills(id);
                return View(new MemberBillsViewModel(_mapper.Map<List<BillViewModel>>(bills), _mapper.Map<MemberViewModel>(member)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        public async Task<IActionResult> CosponsoredBills(string id)
        {
            try
            {
                ViewData["memberId"] = id;
                var member = _proPublica.Members.GetMember(id);
                var cosponsoredBills = _proPublica.Members.GetMemberCosponsoredBills(id);
                return View(new MemberCosponsoredBillsViewModel(_mapper.Map<List<BillViewModel>>(cosponsoredBills), _mapper.Map<MemberViewModel>(member)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        public async Task<IActionResult> Statements(string id, string congress)
        {
            ViewData["memberId"] = id;
            var member = _proPublica.Members.GetMember(id);
            var statements = _proPublica.Members.GetMemberStatements(id, congress);
            return View(new MemberStatementsViewModel(_mapper.Map<List<StatementViewModel>>(statements), _mapper.Map<MemberViewModel>(member)));
        }
        public async Task<IActionResult> Expenses(string id, int? year, int? quarter)
        {
            year = year ?? DateTime.Now.Year;
            quarter = quarter ?? GetQuarter(DateTime.Now);
            ViewData["memberId"] = id;
            ViewData["year"] = year;
            ViewData["quarter"] = quarter;

            var member = _proPublica.Members.GetMember(id);
            var expenses = _proPublica.Members.GetMemberExpenses(id, year.Value, quarter.Value);
            return View(new MemberExpensesViewModel(_mapper.Map<List<ExpensesViewModel>>(expenses), _mapper.Map<MemberViewModel>(member)));
        }
        public async Task<IActionResult> Explanations(string id, string congress)
        {
            ViewData["memberId"] = id;
            var member = _proPublica.Members.GetMember(id);
            var explanations = _proPublica.Members.GetMemberExplanations(id, congress);
            return View(new MemberExplanationsViewModel(_mapper.Map<List<ExplanationViewModel>>(explanations), _mapper.Map<MemberViewModel>(member)));
        }
        public static int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 1;
            else if (date.Month >= 7 && date.Month <= 9)
                return 2;
            else if (date.Month >= 10 && date.Month <= 12)
                return 3;
            else
                return 4;
        }
    }
}
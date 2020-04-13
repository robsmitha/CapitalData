using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CapitalData.Models;
using Microsoft.AspNetCore.Mvc;
using ProPublicaSDK;
using ProPublicaSDK.Models;

namespace CapitalData.Controllers
{
    public class BillsController : BaseController
    {
        public BillsController(IMapper mapper, ProPublica proPublica) : base(mapper, proPublica) { }
        public IActionResult Index(string chamber)
        {
            chamber = !string.IsNullOrEmpty(chamber) ? chamber : HouseChamber;
            ViewData["chamber"] = chamber; 
            return View();
        }
        public IActionResult List(string chamber)
        {
            ViewData["chamber"] = chamber;
            var bills = _proPublica.Bills.GetUpcomingBills(chamber);
            return PartialView("_List", _mapper.Map<List<BillViewModel>>(bills));
        }
        public async Task<IActionResult> Details(string congress, string id)
        {
            try
            {
                var bill = _proPublica.Bills.GetBill(congress, id);
                var statements = new List<StatementModel>();
                //TODO: Implement GetBillStatements statements
                var model = _mapper.Map<BillViewModel>(bill);
                model.statments = _mapper.Map<List<StatementViewModel>>(statements);
                return View(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
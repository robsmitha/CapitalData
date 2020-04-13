using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapitalData.Models
{
    public class VoteListViewModel
    {
        public List<VoteViewModel> Votes { get; set; }
        public string VoteChartLabelsJSON { get; set; }
        public string VoteChartDataJSON { get; set; }
        public VoteListViewModel(List<VoteViewModel> votes, IEnumerable<string> labels, IEnumerable<int> data)
        {
            Votes = votes;
            VoteChartLabelsJSON = labels != null ? JsonSerializer.Serialize(labels) : string.Empty;
            VoteChartDataJSON = data != null ? JsonSerializer.Serialize(data) : string.Empty;
        }
    }
}

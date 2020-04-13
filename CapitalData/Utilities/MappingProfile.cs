using AutoMapper;
using CapitalData.Models;
using ProPublicaSDK.Models;
using System.Text.RegularExpressions;

namespace CapitalData.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MemberModel, MemberViewModel>();
            CreateMap<RoleModel, RoleViewModel>();
            CreateMap<BillModel, BillViewModel>();
            CreateMap<VoteModel, VoteViewModel>();
            CreateMap<ActionModel, ActionViewModel>();
            CreateMap<VersionModel, VersionViewModel>();
            CreateMap<CosponsorsByPartyModel, CosponsorsByPartyViewModel>();
            CreateMap<AmendmentModel, AmendmentViewModel>();
            CreateMap<PositionModel, PositionViewModel>();
            CreateMap<DemocraticModel, DemocraticViewModel>();
            CreateMap<RepublicanModel, RepublicanViewModel>();
            CreateMap<IndependentModel, IndependentViewModel>();
            CreateMap<TotalModel, TotalViewModel>();
            CreateMap<SubjectModel, SubjectViewModel>();
            CreateMap<ExpensesModel, ExpensesViewModel>();
            CreateMap<StatementModel, StatementViewModel>();
            CreateMap<ExplanationModel, ExplanationViewModel>();
            CreateMap<CommitteeModel, CommitteeViewModel>();
            CreateMap<SubcommitteeModel, SubcommitteeViewModel>();
            CreateMap<HearingModel, HearingViewModel>();
            CreateMap<CommitteeMemberModel, CommitteeMemberViewModel>();
            CreateMap<FilingModel, FilingViewModel>();
            CreateMap<LobbyingClientModel, LobbyingClientViewModel>();
            CreateMap<LobbyingRegistrantModel, LobbyingRegistrantViewModel>();
            CreateMap<LobbyingRepresentationModel, LobbyingRepresentationViewModel>();
            CreateMap<LobbyistModel, LobbyistViewModel>();
        }
    }
}

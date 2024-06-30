using CountryAPI.Model;

namespace CountryAPI.Controller.Interface;

public interface IMemberRepository
{
    public Task<List<MemberModel>> GetTeamMembers();
    public Task<List<MemberModel>> AddMemberList(MemberModel request);
}
using CountryAPI.Model;

namespace CountryAPI.Interface;

public interface IMemberService
{
    public Task<List<MemberModel>> GetTeamMembers();
    public Task<List<MemberModel>> AddMemberList(MemberModel request);
}
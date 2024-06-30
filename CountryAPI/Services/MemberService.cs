using CountryAPI.Controller.Interface;
using CountryAPI.Interface;
using CountryAPI.Model;
using CountryAPI.Repository;

namespace CountryAPI.Services;
public class MemberService: IMemberService
{
    private readonly IMemberRepository _repository;

    public MemberService(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MemberModel>> GetTeamMembers()
    {
        return await _repository.GetTeamMembers();
    }
    public async Task<List<MemberModel>> AddMemberList(MemberModel param)
    {
        return await _repository.AddMemberList(param);
    }
}


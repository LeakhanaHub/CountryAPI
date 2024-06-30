using System.Data;
using CountryAPI.Controller.Interface;
using CountryAPI.Model;
using Dapper;

namespace CountryAPI.Repository
{
    public class MemberRepository : IMemberRepository
    {  
        private readonly IDbConnection _connectionFactory;

        public MemberRepository(BaseRepository baseRepository)
        {
            _connectionFactory = baseRepository.CreateConnection();
        }

        public async Task<List<MemberModel>> GetTeamMembers()
        {
            var result = await _connectionFactory.QueryAsync<MemberModel>("GetMemberList",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<MemberModel>> AddMemberList(MemberModel param)
        {
            var result = await _connectionFactory.QueryAsync<MemberModel>("AddMemberList",
                new
                {
                    param.Name,
                    param.Gender,
                    param.Age,
                    param.Address,
                    param.Email
                }, 
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}

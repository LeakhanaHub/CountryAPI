using CountryAPI.Interface;
using CountryAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controller
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [Route("api/get-total-member")]
        [HttpGet]
        public async Task<OkObjectResult> GetTotalMember()
        {
            try
            {
                var memberList = await _memberService.GetTeamMembers();
                var response = new BaseApiResponse<List<MemberModel>>
                {
                    Message = "Success",
                    Data = memberList,
                    ErrorCode = 0,
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                var response = new BaseApiResponse<List<MemberModel>>
                {
                    Message = ex.Message,
                    Data = null,
                    ErrorCode = 1,
                };
                return Ok(response);
            }

        }
        [Route("api/add-total-member")]
        [HttpPost]
        public async Task<OkObjectResult> AddMemberList(MemberModel param)
        {
            try
            {
                var memberList = await _memberService.AddMemberList(param);
                var response = new BaseApiResponse<List<MemberModel>>
                {
                    Message = "Success",
                    Data = memberList.ToList(),
                    ErrorCode = 0,
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                var response = new BaseApiResponse<List<MemberModel>>
                {
                    Message = ex.Message,
                    Data = null,
                    ErrorCode = 1,
                };
                return Ok(response);
            }

        }
    }

}

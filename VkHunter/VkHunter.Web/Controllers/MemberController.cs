using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using VkHunter.Domain.Entities;
using VkHunter.DTO;
using VkHunter.Web.Constants;

namespace VkHunter.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/member")]
    public class MemberController : BaseController
    {
        public MemberController()
        {
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var memberEntities = DataManager.Members.GetAll();
                var memberDTO = Mapper.Map<IEnumerable<Member>, IEnumerable<MemberResponseDTO>>(memberEntities);
                return Ok(memberDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MemberController)} | {nameof(GetAll)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var memberEntitie = DataManager.Members.GetById(id);
                var memberDTO = Mapper.Map<Member, MemberResponseDTO>(memberEntitie);
                return Ok(memberDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MemberController)} | {nameof(GetById)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(MemberRequestDTO member)
        {
            if (!ModelState.IsValid || member.Id != 0 || member.ProjectId <= 0)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var memberEntity = Mapper.Map<MemberRequestDTO, Member>(member);
                var entity = DataManager.Members.Create(memberEntity, member.ProjectId);
                DataManager.Save();

                var memberDTO = Mapper.Map<Member, MemberResponseDTO>(entity);
                return Ok(memberDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MemberController)} | {nameof(Create)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(MemberRequestDTO member)
        {
            if (!ModelState.IsValid || member.Id == 0)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var memberEntity = DataManager.Members.GetById(member.Id);

                var entity = Mapper.Map(member, memberEntity);
                DataManager.Members.Update(entity);
                DataManager.Save();

                var memberDTO = Mapper.Map<Member, MemberResponseDTO>(entity);
                return Ok(memberDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MemberController)} | {nameof(Update)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = DataManager.Members.Delete(id);
                DataManager.Save();

                var memberDTO = Mapper.Map<Member, MemberResponseDTO>(entity);
                return Ok(memberDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MemberController)} | {nameof(Delete)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("getMembers")]
        public IHttpActionResult GetMembers(GetMembersRequestDTO request)
        {
            try
            {
                var membersEntitie = DataManager
                    .Members
                    .GetMembers(request.States, request.ProjectIds, request.Count);

                var membersDTO = Mapper.Map<IEnumerable<Member>, IEnumerable<MemberResponseDTO>>(membersEntitie);
                return Ok(membersDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MemberController)} | {nameof(GetById)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }
    }
}

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
    [RoutePrefix("api/history")]
    public class HistoryController : BaseController
    {
        public HistoryController()
        {
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var historyEntities = DataManager.Histories.GetAll();
                var historyDTO = Mapper.Map<IEnumerable<History>, IEnumerable<HistoryResponseDTO>>(historyEntities);
                return Ok(historyDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(HistoryController)} | {nameof(GetAll)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var historyEntitie = DataManager.Histories.GetById(id);
                var historyDTO = Mapper.Map<History, HistoryResponseDTO>(historyEntitie);
                return Ok(historyDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(HistoryController)} | {nameof(GetById)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(HistoryRequestDTO history)
        {
            if (!ModelState.IsValid || history.Id != 0)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var historyEntity = Mapper.Map<HistoryRequestDTO, History>(history);
                var entity = DataManager.Histories.Create(historyEntity);
                DataManager.Save();

                var historyDTO = Mapper.Map<History, HistoryResponseDTO>(entity);
                return Ok(historyDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(HistoryController)} | {nameof(Create)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(HistoryRequestDTO history)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var historyEntity = DataManager.Histories.GetById(history.Id);

                var entity = Mapper.Map(history, historyEntity);
                DataManager.Histories.Update(entity);
                DataManager.Save();

                var historyDTO = Mapper.Map<History, HistoryResponseDTO>(entity);
                return Ok(historyDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(HistoryController)} | {nameof(Update)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = DataManager.Histories.Delete(id);
                DataManager.Save();

                var historyDTO = Mapper.Map<History, HistoryResponseDTO>(entity);
                return Ok(historyDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(HistoryController)} | {nameof(Delete)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }
    }
}

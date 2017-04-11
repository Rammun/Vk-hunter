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
    [RoutePrefix("api/search")]
    public class SearchController : BaseController
    {
        public SearchController()
        {
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var searchEntities = DataManager.Searches.GetAll();
                var searchesDTO = Mapper.Map<IEnumerable<Search>, IEnumerable<SearchResponseDTO>>(searchEntities);
                return Ok(searchesDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(SearchController)} | {nameof(GetAll)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var searchEntitie = DataManager.Searches.GetById(id);
                var searchDTO = Mapper.Map<Search, SearchResponseDTO>(searchEntitie);
                return Ok(searchDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(SearchController)} | {nameof(GetById)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(SearchRequestDTO search)
        {
            if (!ModelState.IsValid || search.Id != 0)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var searchEntity = Mapper.Map<SearchRequestDTO, Search>(search);
                var entity = DataManager.Searches.Create(searchEntity);
                DataManager.Save();

                var searchDTO = Mapper.Map<Search, SearchResponseDTO>(entity);
                return Ok(searchDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(SearchController)} | {nameof(Create)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(SearchRequestDTO search)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var searchEntity = DataManager.Searches.GetById(search.Id);

                var entity = Mapper.Map(search, searchEntity);
                DataManager.Searches.Update(entity);
                DataManager.Save();

                var searchDTO = Mapper.Map<Search, SearchResponseDTO>(entity);
                return Ok(searchDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(SearchController)} | {nameof(Update)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = DataManager.Searches.Delete(id);
                DataManager.Save();

                var searchDTO = Mapper.Map<Search, SearchResponseDTO>(entity);
                return Ok(searchDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(SearchController)} | {nameof(Delete)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }
    }
}

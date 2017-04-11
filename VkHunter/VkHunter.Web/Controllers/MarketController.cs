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
    [RoutePrefix("api/market")]
    public class MarketController : BaseController
    {
        public MarketController()
        {
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var marketEntities = DataManager.Markets.GetAll();
                var marketDTO = Mapper.Map<IEnumerable<Market>, IEnumerable<MarketResponseDTO>>(marketEntities);
                return Ok(marketDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MarketController)} | {nameof(GetAll)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var postEntitie = DataManager.Posts.GetById(id);
                var postDTO = Mapper.Map<Post, PostResponseDTO>(postEntitie);
                return Ok(postDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MarketController)} | {nameof(GetById)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(MarketRequestDTO market)
        {
            if (!ModelState.IsValid || market.Id != 0)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var marketEntity = Mapper.Map<MarketRequestDTO, Market>(market);
                var entity = DataManager.Markets.Create(marketEntity);
                DataManager.Save();

                var marketDTO = Mapper.Map<Market, MarketResponseDTO>(entity);
                return Ok(marketDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MarketController)} | {nameof(Create)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(MarketRequestDTO market)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var marketEntity = DataManager.Markets.GetById(market.Id);

                var entity = Mapper.Map(market, marketEntity);
                DataManager.Markets.Update(entity);
                DataManager.Save();

                var marketDTO = Mapper.Map<Market, MarketResponseDTO>(entity);
                return Ok(marketDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MarketController)} | {nameof(Update)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = DataManager.Markets.Delete(id);
                DataManager.Save();

                var marketDTO = Mapper.Map<Market, MarketResponseDTO>(entity);
                return Ok(marketDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(MarketController)} | {nameof(Delete)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }
    }
}

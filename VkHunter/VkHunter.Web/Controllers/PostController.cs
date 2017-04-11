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
    [RoutePrefix("api/post")]
    public class PostController : BaseController
    {
        public PostController()
        {
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var postEntities = DataManager.Posts.GetAll();
                var postDTO = Mapper.Map<IEnumerable<Post>, IEnumerable<PostResponseDTO>>(postEntities);
                return Ok(postDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(PostController)} | {nameof(GetAll)} | {ex}");
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
                Logger.Debug($"{nameof(PostController)} | {nameof(GetById)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(PostRequestDTO post)
        {
            if (!ModelState.IsValid || post.Id != 0)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var postEntity = Mapper.Map<PostRequestDTO, Post>(post);
                var entity = DataManager.Posts.Create(postEntity);
                DataManager.Save();

                var postDTO = Mapper.Map<Post, PostResponseDTO>(entity);
                return Ok(postDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(PostController)} | {nameof(Create)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(PostRequestDTO post)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            try
            {
                var postEntity = DataManager.Posts.GetById(post.Id);

                var entity = Mapper.Map(post, postEntity);
                DataManager.Posts.Update(entity);
                DataManager.Save();

                var postDTO = Mapper.Map<Post, PostResponseDTO>(entity);
                return Ok(postDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(PostController)} | {nameof(Update)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = DataManager.Posts.Delete(id);
                DataManager.Save();

                var postDTO = Mapper.Map<Post, PostResponseDTO>(entity);
                return Ok(postDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Logger.Debug($"{nameof(PostController)} | {nameof(Delete)} | {ex}");
                return BadRequest(ErrorMessage.Unsuccess);
            }
        }
    }
}

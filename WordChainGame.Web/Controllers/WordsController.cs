

namespace WordChainGame.Web.Controllers
{
    using AutoMapper;
    using Swashbuckle.Swagger.Annotations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using WordChainGame.DTO.InappropriateWordRequests;
    using WordChainGame.Services.Services.Words;
    using WordChainGame.Services.UnitOfWork;

    [RoutePrefix("api/words")]
    public class WordsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWordService words;

        public WordsController(IUnitOfWork unitOfWork, IMapper mapper, IWordService words)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.words = words;
        }

        /// <summary>
        /// Gets all requests for inappropriate word which are still not marked as inappropriate or not.
        /// </summary>
        /// <param name="top">Pagination model</param>
        /// <param name="skip">Pagination model</param>
        /// <returns>Paginated result for the requests</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("inappropriate")]
        [SwaggerResponse(HttpStatusCode.OK, "All inappropriate words requests.", typeof(PaginatedInappropriateWordRequests))]
        public IHttpActionResult Get(int top, int skip)
        {
            var requests = unitOfWork.InappropriateWordRequests
                                     .Get(filter: r => r.IsInappropriate == null,
                                          includeProperties: "Requester, InappropriateWord.Topic");

            var paginatedRequests = requests.Skip(skip).Take(top);
            int count = requests.Count();
            var response = new PaginatedInappropriateWordRequests
            {
                Count = count,
                InappropriateWordRequests = mapper.Map<ICollection<InappropriateWordRequestsResponseModel>>(paginatedRequests),
                NextPageUrl = top + skip > count ? null : string.Format("api/words/inappropriate?top={0}&skip={1}", top, top + skip),
                PreviousPageUrl = skip - top < 0 ? null : string.Format("api/words/inappropriate?top={0}&skip={1}", top, skip - top),
            };
            return Ok(response);
        }


        /// <summary>
        /// Gets all requests for inappropriate word which are still not marked as inappropriate or not.
        /// </summary>
        /// <param name="top">Pagination model</param>
        /// <param name="skip">Pagination model</param>
        /// <returns>Paginated result for the requests</returns>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("inappropriate")]
        [SwaggerResponse(HttpStatusCode.OK, "All inappropriate words requests.", typeof(PaginatedInappropriateWordRequests))]
        public IHttpActionResult Delete(int top, int skip)
        {
            var requests = unitOfWork.InappropriateWordRequests
                                     .Get(filter: r => r.IsInappropriate == null,
                                          includeProperties: "Requester, InappropriateWord.Topic");

            var paginatedRequests = requests.Skip(skip).Take(top);
            int count = requests.Count();
            var response = new PaginatedInappropriateWordRequests
            {
                Count = count,
                InappropriateWordRequests = mapper.Map<ICollection<InappropriateWordRequestsResponseModel>>(paginatedRequests),
                NextPageUrl = top + skip > count ? null : string.Format("api/words/inappropriate?top={0}&skip={1}", top, top + skip),
                PreviousPageUrl = skip - top < 0 ? null : string.Format("api/words/inappropriate?top={0}&skip={1}", top, skip - top),
            };
            return Ok(response);
        }

        /// <summary>
        /// Deletes word from topic by id and if there is request for inappropriate word, marks the request as completed.
        /// </summary>
        /// <param name="wordId">The id of the word.</param>
        /// <returns>Ok</returns>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Word successfully deleted.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Invalid word Id.")]
        public IHttpActionResult Delete(int wordId)
        {
            if (unitOfWork.Words.GetByID(wordId) == null)
            {
                return NotFound();
            }

            words.Delete(wordId);
            return Ok();
        }
    }
}

using DapperPracticalExample.DB;
using DapperPracticalExample.Mapping;
using DapperPracticalExample.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DapperPracticalExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DapperController : ControllerBase
    {
        private readonly IDbRepository dbRepository;

        public DapperController(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        [HttpGet("GetAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors() 
        {
            var authorEntities = await dbRepository.GetAuthors();

            var result = authorEntities.Select(author => 
            DapperMapper.AuthorEntityToAuthorDTO(author));

            return Ok(result);
        }

        [HttpGet("GetAuthor")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(long authorId) 
        {
            var authorEntity = await dbRepository.GetAuthor(authorId);

            if (authorEntity == null) return NotFound();

            var result = DapperMapper.AuthorEntityToAuthorDTO(authorEntity);

            return Ok(result);
        }
    }
}

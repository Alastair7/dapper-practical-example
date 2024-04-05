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

        [HttpGet("GetPersons")]
        public async Task<ActionResult<PersonDTO>> GetPersons() 
        {
            var personEntities = await dbRepository.GetPersons();

            if (personEntities == null) return NotFound();

            var result = personEntities
                .Select(DapperMapper.PersonEntityToPersonDTO);

            return Ok(result);
        }

        [HttpPost("InsertAuthor")]
        public async Task<ActionResult<string>> InsertAuthor([FromBody] 
        AuthorDTO authorDTO)
        {
            var authorEntity = DapperMapper.AuthorDTOToAuthorEntity(authorDTO);

            var result = await dbRepository.InsertAuthor(authorEntity);

            string message = result > 0 ? $"SUCCESS {result}" : "ERROR";
            return Ok(message);
        }

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult<string>> UpdateAuthor([FromBody]
        AuthorDTO authorDTO)
        {
            var authorEntity = DapperMapper.AuthorDTOToAuthorEntity(authorDTO);

            var result = await dbRepository.UpdateAuthor(authorEntity);

            string message = result > 0 ? $"SUCCESS {result}" : "ERROR";
            return Ok(message);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<string>> DeleteAuthor([FromQuery]
        long authorId)
        {
            var result = await dbRepository.DeleteAuthor(authorId);

            string message = result > 0 ? $"SUCCESS {result}" : "ERROR";
            return Ok(message);
        }
    }
}

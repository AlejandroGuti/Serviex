using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SERVIEX.Contexts;
using SERVIEX.Entities;
using SERVIEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SERVIEX.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class FullUserDTOController : ControllerBase
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public FullUserDTOController(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            /*
              [HttpGet("/primero")]
              public ActionResult<Autor> GetPrimerAutor()
              {
                  return context.Autores.FirstOrDefault();
              }*/
            /**/
            [HttpGet]
            public async Task<ActionResult<IEnumerable<FullUserDTO>>> Get()
            {
                var users = await _context.users.Include(x=>x.gender).ToListAsync();
                var fullUserDTO = _mapper.Map<List<FullUserDTO>>(users);
                return fullUserDTO;
            }
        [HttpGet("{id}", Name = "ObtainUser")]
        public async Task<ActionResult<FullUserDTO>> Get(int id, string param2)
        {
            User user = await _context.users.Include(x=>x.gender).FirstOrDefaultAsync(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }
            FullUserDTO fullUserDTO = _mapper.Map<FullUserDTO>(user);
            return fullUserDTO;

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FullUserCreationDTO userCreationDTO)
        {

            var user = _mapper.Map<User>(userCreationDTO);
            user.gender= await _context.genders.FindAsync(userCreationDTO.genderid);
            //user.gender.id = userCreationDTO.genderid;
            _context.Add(user);
            await _context.SaveChangesAsync();
            var userDTO = _mapper.Map<FullUserDTO>(user);
            return new CreatedAtRouteResult("ObtainUser", new { id = user.id }, userDTO);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FullUserCreationDTO userActualization)
        {
            var user = _mapper.Map<User>(userActualization);
            user.id = id;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        /*[{"op":""replace,
         * "path":"/name",
         * "value":"ACtualizado"}]*/
        public async Task<ActionResult> Patch
            (int id, [FromBody] JsonPatchDocument<FullUserCreationDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }
            var userDeLaBd = await _context.users.FirstOrDefaultAsync(x => x.id == id);
            if (userDeLaBd == null)
            {
                return NotFound();
            }
            var autorDTO = _mapper.Map<FullUserCreationDTO>(userDeLaBd);
            patchDocument.ApplyTo(autorDTO, ModelState);
            _mapper.Map(autorDTO, userDeLaBd);
            var isValid = TryValidateModel(userDeLaBd);
            if (!isValid) { return BadRequest(ModelState); }

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<FullUserDTO>> Delete(int id)
        {

            var userID = await _context.users.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

   
            if (userID == default(int))
            {
                return NotFound();
            }
            //var autorDelDTO = mapper.Map<AutorDeleteDTO>(autorID); 
            _context.users.Remove(new User { id = userID });
            await _context.SaveChangesAsync();
            return NoContent();

        }

    }
    
}

using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ServerMagazin.Data;
using ServerMagazin.Dtos;
using ServerMagazin.Models;
using ServerMagazin.ComandaAlgorithm;

namespace ServerMagazin.Controllers
{

    [Route("api/client")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult <IEnumerable<ClientReadDto>> GetAllClients()
        {
            var clientItems = _repository.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientReadDto>>(clientItems));
        }

        //GET api/client/{id}
        [HttpGet("{id}", Name ="GetClientById")]
        public ActionResult <ClientReadDto> GetClientById(int id)
        {
            var clientItem = _repository.GetClientById(id);
            if(clientItem != null)
                return Ok(_mapper.Map<ClientReadDto>(clientItem));
            return NotFound();

        }

        //POST api/client
        [HttpPost]
        public ActionResult <ClientReadDto> CreateClient([FromBody]ClientCreateDto clientCreateDto)
        {
            var clientModel = _mapper.Map<Client>(clientCreateDto); 
            _repository.CreateClient(clientModel);
            _repository.SaveChanges();

            var clientReadDto = _mapper.Map<ClientReadDto>(clientModel);

            return CreatedAtRoute(nameof(GetClientById), new {Id = clientModel.Id}, clientReadDto);
        } 


        //PUT api/client/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id, [FromBody]ClientUpdateDto clientUpdateDto)
        {
            var clientModelFromRepo = _repository.GetClientById(id);
            if(clientModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(clientUpdateDto, clientModelFromRepo);

            _repository.UpdateClient(clientModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //PATCH api/client/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialClientUpdate(int id,[FromBody] JsonPatchDocument<ClientUpdateDto> patchDoc)
        {
            var clientModelFromRepo = _repository.GetClientById(id);
            if(clientModelFromRepo == null)
            {
                return NotFound();
            }

            var clientToPatch = _mapper.Map<ClientUpdateDto>(clientModelFromRepo);
            patchDoc.ApplyTo(clientToPatch, ModelState);
            if(!TryValidateModel(clientToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(clientToPatch, clientModelFromRepo);

            _repository.UpdateClient(clientModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //DELETE api/client/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            var clientModelFromRepo = _repository.GetClientById(id);
            if(clientModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteClient(clientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }

    }

    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public LoginController(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult <ClientReadDto> LoginClient([FromBody]ClientLoginDto clientLoginDto)
        {
            var clientModel = _mapper.Map<Client>(clientLoginDto); 
            var client = _repository.LoginClient(clientModel);
            if(client != null)
            {
                return Ok(client.Id);
            }

            return Ok(0);
        } 

        

    }

    //Nu uita sa faci si metoda de GET 
    [Route("api/comanda")]
    public class ComandaController : Controller
    {
        private readonly ISlabComandaRepository _repositoryM;
        private readonly IClientRepository _repositoryC;
        private readonly IComandaRepository _repository;
        private readonly IMapper _mapper;

        public ComandaController(IClientRepository repositoryC, IMapper mapper, IComandaRepository repository, ISlabComandaRepository repositoryM)
        {
            _repositoryM = repositoryM;
            _repositoryC = repositoryC;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult <IEnumerable<ComandaReadDto>> GetAllComands(int id)
        {
            var comandaItems = _repository.GetAllComandsById(id);
            return Ok(_mapper.Map<IEnumerable<ComandaReadDto>>(comandaItems));
        }

        //POST api/comanda
        [HttpPost]
        public ActionResult <ComandaReadDto> CreateComanda([FromBody]ComandaCreateDto comandaCreateDto)
        {
            var comandaModel = _mapper.Map<Comanda>(comandaCreateDto); 
            _repository.CreateComanda(comandaModel);
            _repository.SaveChanges();
            var comandaReadDto = _mapper.Map<ComandaReadDto>(comandaModel);

            return Ok(comandaReadDto.IdC);
        }

        //DELETE api/comanda/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteComanda(int id)
        {
            var comandaModelFromRepo = _repository.GetComandaById(id);
            if(comandaModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteComanda(comandaModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        } 

        [HttpPut("{id}")]
        public ActionResult UpdateComanda(int id)
        {
            var comandaModelFromRepo = _repository.GetComandaById(id);
            if(comandaModelFromRepo == null)
            {
                return  NoContent();
            }

            comandaModelFromRepo.Done = true;

            _repository.UpdateComanda(comandaModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

    }
    [Route("api/slabcomanda")]
    public class SlabComandaController : Controller
    {
        private readonly ISlabComandaRepository _repository;
        private readonly IComandaRepository _repositoryC;
        private readonly IMapper _mapper;
        private readonly ComAlgorithm _comAlgorithm;

        public SlabComandaController(IComandaRepository repositoryC, IMapper mapper, ISlabComandaRepository repository, ComAlgorithm comAlgorithm)
        {
            _repositoryC = repositoryC;
            _repository = repository;
            _mapper = mapper;
            _comAlgorithm = comAlgorithm;
        }

        [HttpPost]
        public ActionResult <SlabComandaReadDto> CreateSlabComanda([FromBody]SlabComandaCreateDto slabComandaCreateDto)
        {
            var slabComandaModel = _mapper.Map<SlabComanda>(slabComandaCreateDto);   
            _repository.CreateSlabComanda(slabComandaModel);
            _repository.SaveChanges();

            var slabComandaReadDto = _mapper.Map<SlabComandaReadDto>(slabComandaModel);
            Console.WriteLine(slabComandaReadDto.IdSC);
            return Ok(slabComandaReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSlabComanda(int id)
        {
            var slabComandaModelFromRepo = _repository.GetSlabComandaById(id);
            if(slabComandaModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteSlabComanda(slabComandaModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        } 

        [HttpGet("{id}")]
        public ActionResult <SlabComandaReadDto> GetSlabComandaById(int id)
        {
            var slabComandaItem = _repository.GetSlabComandaById(id);
            Console.WriteLine("S-a intrat");
            if(slabComandaItem != null)
                return Ok(_mapper.Map<SlabComandaReadDto>(slabComandaItem));
            return NotFound();

        }


    }

    [Route("api/allslabcomanda")]
    public class AllSlabComandaController : Controller
    {
        private readonly ISlabComandaRepository _repository;
        private readonly IComandaRepository _repositoryC;
        private readonly IMapper _mapper;
        private readonly ComAlgorithm _comAlgorithm;

        public AllSlabComandaController(IComandaRepository repositoryC, IMapper mapper, ISlabComandaRepository repository, ComAlgorithm comAlgorithm)
        {
            _repositoryC = repositoryC;
            _repository = repository;
            _mapper = mapper;
            _comAlgorithm = comAlgorithm;
        }

        [HttpGet("{id}")]
        public ActionResult <IEnumerable<SlabComandaReadDto>> GetAllSlabComandaByIdComanda(int id)
        {
            var slabComandaItem = _repository.GetAllSlabComandaIdComanda(id);
            Console.WriteLine("S-a intrat");
            if(slabComandaItem != null)
                return Ok(_mapper.Map<IEnumerable<SlabComandaReadDto>>(slabComandaItem));
            return NotFound();

        }
        
    }

    [Route("api/slabstoc")]
    public class SlabStocController : Controller
    {
        private readonly ISlabStocRepository _repository;
        private readonly IMapper _mapper;

        public SlabStocController(IMapper mapper, ISlabStocRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{m}")]
        public ActionResult <IEnumerable<SlabStocReadDto>> GetAllSlabStocByMaterial(string m)
        {
            var slabStocItem = _repository.GetSlabStocByMaterial(m);
            Console.WriteLine("S-a intrat");
            if(slabStocItem != null)
                return Ok(_mapper.Map<IEnumerable<SlabStocReadDto>>(slabStocItem));
            return NotFound();

        }

        [HttpPost]
        public ActionResult <SlabStocReadDto> CreateSlabStoc([FromBody]SlabStocCreateDto slabStocCreateDto)
        {
            var slabStocModel = _mapper.Map<SlabStoc>(slabStocCreateDto);   
            _repository.CreateSlabStoc(slabStocModel);
            _repository.SaveChanges();

            var slabStocReadDto = _mapper.Map<SlabStocReadDto>(slabStocModel);

            return Ok(slabStocReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSlabStoc(int id)
        {
            var slabStocModelFromRepo = _repository.GetSlabStocById(id);
            if(slabStocModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteSlabStoc(slabStocModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }

        [HttpGet]
        public ActionResult <IEnumerable<SlabStocReadDto>> GetAllSlabStoc()
        {
            var clientItems = _repository.GetSlabStocByMaterialLungimeLatime("Marmura",0.6,0.5);
            return Ok(_mapper.Map<IEnumerable<SlabStocReadDto>>(clientItems));
        }

        

        
    }


    [Route("api/taiere")]
        public class TaiereController : Controller
        {
            private readonly ISlabStocRepository _repositorySS;
            private readonly ISlabComandaRepository _repositorySC;
            private readonly IComandaRepository _repositoryC;
            private readonly IMapper _mapper;
            private readonly ComAlgorithm _comAlgorithm;

            public TaiereController(ISlabStocRepository iSS, ISlabComandaRepository iSC, IComandaRepository iC, IMapper mapper, ComAlgorithm comAlgorithm)
            {
                this._repositorySS = iSS;
                this._repositorySC = iSC;
                this._repositoryC = iC;
                this._mapper = mapper;
                this._comAlgorithm = comAlgorithm;
            }

            [HttpGet("{id}")]
            public ActionResult TaiereById(int id)
            {
                
                var IdPlaciReurnate = _comAlgorithm.CutSlabs(id);
                if (IdPlaciReurnate.Count == 0)
                    return NoContent();
                
                else
                {
                    return Ok(IdPlaciReurnate); //De schimbat si aici -- Returnam placile din comanda pt care nu s-a putut face taierea
                                        //Stergem toata comanda
                }
            }

        }

}
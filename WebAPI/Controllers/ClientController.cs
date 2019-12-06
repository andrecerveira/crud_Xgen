using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();

        //[HttpGet]
        /// <summary>
        /// GET List All Clients
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> Get()
        {
            IEnumerable<Client> clients = _clientRepository.GetAll();   
            return clients;

            //return _clientRepository.GetAll();
        }


        /// <summary>
        /// GET Client By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("api/Clients/{id}")]
        public Client Get(int id)
        {
            return _clientRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }



        /// <summary>
        /// POST Inserts a Client
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public Client Post([FromBody]Client client)
        {
            return _clientRepository.Add(client);
        }

        /// <summary>
        /// PUT Updates a Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPut]
        public Client Put([FromForm]Client client)
        {
            return _clientRepository.Update(client);
        }

        /// <summary>
        /// DELETE Delete a Client
        /// </summary>
        /// <param name="client"></param>
        [HttpDelete("{id}")]
        [Route("api/Clients/{id}")]
        public void Delete(int id)
        {
            Client client = this.Get(id);
            _clientRepository.Remove(client);
        }
    }
}
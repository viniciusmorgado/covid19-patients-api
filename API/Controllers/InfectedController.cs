using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDb _mongoDb;
        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Data.MongoDb mongoDb)
        {
            _mongoDb = mongoDb;
            _infectedCollection = _mongoDb.Db.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        // Do body da requisição nós esperamos um json com padrão dos atributos da classe InfectedDto
        public IActionResult PostInfected([FromForm] InfectedDto dto)
        {
            var infected = new Infected(dto.Birthday, dto.Sex, dto.Latitude, dto.Longitude);
            _infectedCollection.InsertOne(infected);
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public IActionResult GetInfected()
        {
            var infectedList = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            return Ok(infectedList);
        }

        [HttpPut]
        public IActionResult UpdateInfected([FromForm] InfectedDto dto)
        {
            
            _infectedCollection.UpdateOne(Builders<Infected>.Filter.Where(prop => prop.Birthday == dto.Birthday),
            // Aqui o update atualiza uma única propriedade, replace todo o documento.
            Builders<Infected>.Update.Set("sex", dto.Sex));
            
            return Ok("Atualizado com sucesso!");
        }
    }
}
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
        public ActionResult SaveInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.Birthday, dto.Sex, dto.Latitude, dto.Longitude);
            _infectedCollection.InsertOne(infected);
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult GetInfected()
        {
            var infectedList = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            return Ok(infectedList);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpidemiologyKDR.Controllers
{
    [ApiController]
    [Route("api/individuals")]
    public class IndividualsController : ControllerBase
    {
        // Being stored in
        private List<Individual> individuals = new List<Individual>();

        // GET /api/individuals
        [HttpGet]
        public ActionResult<IEnumerable<Individual>> Get()
        {
            return Ok(individuals.Where(i => i.Diagnosed).ToList());
        }

        // GET /api/individuals/{id}
        [HttpGet("{id}")]
        public ActionResult<Individual> Get(int id)
        {
            var individual = individuals.FirstOrDefault(i => i.Id == id && i.Diagnosed);
            if (individual == null)
            {
                return NotFound($"Individual with Id {id} not found.");
            }

            return Ok(individual);
        }

        // POST /api/individuals
        [HttpPost]
        public ActionResult<Individual> Post([FromBody] Individual individual)
        {
            individual.Id = individuals.Count + 1;
            individuals.Add(individual);
            return CreatedAtAction(nameof(Get), new { id = individual.Id }, individual);
        }

        // PUT /api/individuals/{id}
        [HttpPut("{id}")]
        public ActionResult<Individual> Put(int id, [FromBody] Individual updatedIndividual)
        {
            var existingIndividual = individuals.FirstOrDefault(i => i.Id == id && i.Diagnosed);
            if (existingIndividual == null)
            {
                return NotFound($"Individual with Id {id} not found.");
            }

            existingIndividual.Name = updatedIndividual.Name;
            existingIndividual.Age = updatedIndividual.Age;
            existingIndividual.Symptoms = updatedIndividual.Symptoms;
            existingIndividual.Diagnosed = updatedIndividual.Diagnosed;
            existingIndividual.Date_Diagnosed = updatedIndividual.Date_Diagnosed;

            return Ok(existingIndividual);
        }
    }

}

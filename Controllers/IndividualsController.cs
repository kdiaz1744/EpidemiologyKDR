﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpidemiologyKDR.Controllers
{
    [ApiController]
    [Route("api/individuals")]
    public class IndividualsController : ControllerBase
    {
        //****************************************************************************
        //*     NOTE: Individuals are being stored on this list, and for the sake of *
        //* this assignment, the list was made STATIC, which is not a good practice  *
        //* when making bigger projects, but for the sake of these examples, it's    *
        //* what I chose.                                                            *
        //****************************************************************************
        static private List<Individual> individuals = new List<Individual>();

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
                //If individual not found
                return NotFound($"Individual with Id {id} not found.");
            }

            return Ok(individual);
        }

        // POST /api/individuals
        [HttpPost]
        public ActionResult<Individual> Post([FromBody] Individual individual)
        {
            // Validate the input
            if (individual == null)
            {
                //If invalid input
                return BadRequest("Invalid input. Please provide valid data for the new individual.");
            }

            // Setting the properties for the new individual
            individual.Diagnosed = true;
            individual.Id = individuals.Count + 1;
            individuals.Add(individual);

            // Return response with the created individual
            return CreatedAtAction(nameof(Get), new { id = individual.Id }, individual);
        }

        // PUT /api/individuals/{id}
        [HttpPut("{id}")]
        public ActionResult<Individual> Put(int id, [FromBody] Individual updatedIndividual)
        {
            // Validate input
            if (updatedIndividual == null)
            {
                //If invalid input
                return BadRequest("Invalid input. Please provide valid data for updating the individual.");
            }

            // Find individual to update
            var existingIndividual = individuals.FirstOrDefault(i => i.Id == id && i.Diagnosed);

            // Check if individual is found
            if (existingIndividual == null)
            {
                return NotFound($"Individual with Id {id} not found.");
            }

            // Update properties of the existing individual
            existingIndividual.Name = updatedIndividual.Name;
            existingIndividual.Age = updatedIndividual.Age;
            existingIndividual.Symptoms = updatedIndividual.Symptoms;
            existingIndividual.Diagnosed = updatedIndividual.Diagnosed;
            existingIndividual.Date_Diagnosed = updatedIndividual.Date_Diagnosed;

            // Return response with the updated individual
            return Ok(existingIndividual);
        }


        // DELETE /api/individuals/{id}
        //  This function was made for testing purposes only, since it wasn't mentioned in the project requirements.
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var individualToDelete = individuals.FirstOrDefault(i => i.Id == id && i.Diagnosed);
            if (individualToDelete == null)
            {
                // If the individual is not found
                return NotFound($"Individual with Id {id} not found.");
            }

            // Remove the individual from the list
            individuals.Remove(individualToDelete);

            // Return to indicate a successful deletion
            return NoContent();
        }


    }
}

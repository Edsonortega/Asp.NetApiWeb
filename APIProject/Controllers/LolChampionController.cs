using APIProject.Models;
using APIProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers;

[ApiController]
[Route("[controller]")]
public class LolChampionController : ControllerBase{
    public LolChampionController(){

    }

    //Get All
    [HttpGet]
    public ActionResult<List<LolChampion>> GetAll() => LolChampionService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<LolChampion> GetById(int id){
        var champion = LolChampionService.Get(id);
        if(champion == null){
            return NotFound();
        }
        return Ok(champion);
    }
    // POST action
    [HttpPost]
    public IActionResult Create(LolChampion champion){
        LolChampionService.Add(champion);
        return CreatedAtAction(nameof(GetById), new{id = champion.Id}, champion);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, LolChampion champion){
        if(id != champion.Id){
            return BadRequest();
        }

        var existingChampion = LolChampionService.Get(id);
        if(existingChampion is null){
            return NotFound();
        }

        LolChampionService.Update(champion);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var champion = LolChampionService.Get(id);
        if(champion is null){
            return NotFound();
        }

        LolChampionService.Delete(id);
        return NoContent();

    }

}
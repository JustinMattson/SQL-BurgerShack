using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CombosController : ControllerBase
  {

    private readonly BurgerService _service;
    private readonly ComboService _comboService;

    // Depencency injection...
    public CombosController(BurgerService service, ComboService cs)
    {
      _service = service;
      _comboService = cs;
    }

    [HttpGet] // Get All
    public ActionResult<IEnumerable<DbCombo>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]  // Get Combo By Id
    public ActionResult<DbCombo> Get(int id)
    {
      try
      {
        return Ok(_service.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    // [HttpGet("{id}/combos")]  // Get Burger By Combo Id
    // public ActionResult<IEnumerable<Burger>> GetByBurgerId(int id)
    // {
    //   try
    //   {
    //     return Ok(_comboService.GetByBurgerId(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    public ActionResult<DbCombo> Create([FromBody] DbCombo newCombo)
    {
      try
      {
        return Ok(_comboService.Create(newCombo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<DbCombo> Edit([FromBody] DbCombo editCombo, int id)
    {
      try
      {
        editCombo.Id = id;
        return Ok(_comboService.Edit(editCombo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<DbCombo> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

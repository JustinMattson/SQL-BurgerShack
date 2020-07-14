using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgersController : ControllerBase
  {

    private readonly BurgerService _service;
    private readonly ComboService _comboService;

    // Depencency injection...
    public BurgersController(BurgerService service, ComboService cs)
    {
      _service = service;
      _comboService = cs;
    }

    [HttpGet] // Get All
    public ActionResult<IEnumerable<Burger>> Get()
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


    [HttpGet("{id}")]  // Get Burger By Id
    public ActionResult<Burger> Get(int id)
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



    [HttpGet("{id}/combos")]  // Get Burger By Combo Id
    public ActionResult<IEnumerable<Burger>> GetByBurgerId(int id)
    {
      try
      {
        return Ok(_comboService.GetByBurgerId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        return Ok(_service.Create(newBurger));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<Burger> Edit([FromBody] Burger editBurger, int id)
    {
      try
      {
        editBurger.Id = id;
        return Ok(_service.Edit(editBurger));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Burger> Delete(int id)
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

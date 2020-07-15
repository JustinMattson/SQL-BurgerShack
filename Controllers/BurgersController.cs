using System;
using System.Collections.Generic;
using System.Security.Claims;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        // Authorize will force the user to be logged in, but does not restrict access to POST, PUT, DELETE once logged in.
        string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // similar to req.userInfo.email
        newBurger.InspiredBy = UserEmail;
        return Ok(_service.Create(newBurger));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Burger> Edit([FromBody] Burger editBurger, int id)
    {
      try
      {
        string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // similar to req.userInfo.email
        editBurger.Id = id;
        return Ok(_service.Edit(editBurger, UserEmail));
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
        string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // similar to req.userInfo.email
        return Ok(_service.Delete(id, UserEmail));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

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
  public class SidesController : ControllerBase
  {

    private readonly SideService _service;
    private readonly ComboService _comboService;

    // Depencency injection...
    public SidesController(SideService service, ComboService cs)
    {
      _service = service;
      _comboService = cs;
    }

    [HttpGet] // Get All
    public ActionResult<IEnumerable<Side>> Get()
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


    [HttpGet("{id}")]  // Get Side By Id
    public ActionResult<Side> Get(int id)
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



    [HttpGet("{id}/combos")]  // Get Side By Combo Id
    public ActionResult<IEnumerable<Side>> GetBySideId(int id)
    {
      try
      {
        return Ok(_comboService.GetBySideId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Side> Create([FromBody] Side newSide)
    {
      try
      {
        string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // similar to req.userInfo.email
        newSide.InspiredBy = UserEmail;
        return Ok(_service.Create(newSide));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Side> Edit([FromBody] Side editSide, int id)
    {
      try
      {
        string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // similar to req.userInfo.email
        editSide.Id = id;
        return Ok(_service.Edit(editSide, UserEmail));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Side> Delete(int id)
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

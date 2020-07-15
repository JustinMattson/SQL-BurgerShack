using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class SideService
  {
    private readonly SideRepository _repo;
    public SideService(SideRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Side> Get()
    {
      return _repo.GetAll();
    }

    internal Side Get(int id)
    {
      Side found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Side Create(Side newSide)
    {
      _repo.Create(newSide);
      return newSide;
    }

    internal Side Edit(Side editSide, string userEmail)
    {
      Side original = Get(editSide.Id);
      if (original.InspiredBy != userEmail)
      {
        throw new UnauthorizedAccessException("You cannot modify this menu item!");
      }
      original.Name = editSide.Name == null ? original.Name : editSide.Name;
      original.Description = editSide.Description == null ? original.Description : editSide.Description;
      original.Price = editSide.Price > 0 ? editSide.Price : original.Price;

      _repo.Edit(original);
      return original;
    }
    internal Side Delete(int id, string userEmail)
    {
      Side sideToDelete = Get(id);
      if (sideToDelete.InspiredBy != userEmail)
      {
        throw new UnauthorizedAccessException("You did not inspire this side, burger off!");
      }
      _repo.Delete(sideToDelete);
      return sideToDelete;
    }
  }
}
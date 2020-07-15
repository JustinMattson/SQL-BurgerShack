using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _repo;
    public BurgerService(BurgerRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Burger> Get()
    {
      return _repo.GetAll();
    }

    internal Burger Get(int id)
    {
      Burger found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Burger Create(Burger newBurger)
    {
      _repo.Create(newBurger);
      return newBurger;
    }

    internal Burger Edit(Burger editBurger, string userEmail)
    {
      Burger original = Get(editBurger.Id);
      if (original.InspiredBy != userEmail)
      {
        throw new UnauthorizedAccessException("You cannot modify this menu item!");
      }
      // try this with UniQue
      original.Name = editBurger.Name == null ? original.Name : editBurger.Name;
      original.Description = editBurger.Description == null ? original.Description : editBurger.Description;
      original.Price = editBurger.Price > 0 ? editBurger.Price : original.Price;

      _repo.Edit(original);
      return original;
    }
    internal Burger Delete(int id, string userEmail)
    {
      Burger burgerToDelete = Get(id);
      if (burgerToDelete.InspiredBy != userEmail)
      {
        throw new UnauthorizedAccessException("You did not inspire this burger, burger off!");
      }
      _repo.Delete(burgerToDelete);
      return burgerToDelete;
    }
  }
}
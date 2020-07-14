using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class ComboService
  {
    private readonly ComboRepository _repo;
    public ComboService(ComboRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<DbCombo> Get()
    {
      return _repo.GetAll();
    }

    internal DbCombo Get(int id)
    {
      DbCombo found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid DbCombo Id");
      }
      return found;
    }

    internal IEnumerable<DbCombo> GetByBurgerId(int id)
    {
      return _repo.GetByBurgerId(id);
    }

    internal IEnumerable<DbCombo> GetBySideId(int id)
    {
      return _repo.GetBySideId(id);
    }

    internal DbCombo Create(DbCombo newDbCombo)
    {
      _repo.Create(newDbCombo);
      return newDbCombo;
    }

    internal DbCombo Edit(DbCombo editDbCombo)
    {
      DbCombo original = Get(editDbCombo.Id);
      original.Price = editDbCombo.Price > 0 ? editDbCombo.Price : original.Price;

      _repo.Edit(original);
      return original;

    }


    internal DbCombo Delete(int id)
    {
      DbCombo comboToDelete = Get(id);
      _repo.Delete(comboToDelete);
      return comboToDelete;
    }
  }
}
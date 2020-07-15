using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class SideRepository
  {
    public readonly IDbConnection _db;
    public SideRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Side> GetAll()
    {
      string sql = "SELECT * FROM sides;";
      return _db.Query<Side>(sql);
    }
    internal Side GetById(int id)
    {
      string sql = "SELECT * FROM sides WHERE id = @id";
      // Create a new object with the property id, and value of that variable from the parameter
      return _db.QueryFirstOrDefault<Side>(sql, new { id });
    }
    internal Side Create(Side newSide)
    {
      string sql = @"
      INSERT INTO sides
      (name, inspiredby, description, price)
      VALUES
      (@Name, @InspiredBy, @Description, @Price);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newSide);
      newSide.Id = id;
      return newSide;
    }
    internal Side Edit(Side original)
    {
      string sql = @"
      UPDATE sides
      SET
        name = @Name,
        inspiredby = @InspiredBy,
        price = @Price,
        description = @Description
      WHERE id = @Id;
      SELECT * FROM sides WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<Side>(sql, original);
    }
    internal Side Delete(Side sideToDelete)
    {
      string sql = "DELETE FROM sides WHERE id = @Id";
      _db.Execute(sql, sideToDelete);
      return sideToDelete;
    }
  }
}
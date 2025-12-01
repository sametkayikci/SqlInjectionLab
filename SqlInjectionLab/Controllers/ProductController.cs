using SqlInjectionLab.Data;
using SqlInjectionLab.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Npgsql;

namespace SqlInjectionLab.Controllers;


public class ProductController : Controller
{
    public IActionResult Search(string q)
    {
        var sql = $"SELECT id, name, price FROM products WHERE name ILIKE '%{q}%'";

        using var conn = new NpgsqlConnection(Db.Connection);
        var list = conn.Query<Product>(sql);

        return View(list);
    }

    #region Secure
    //public IActionResult Search(string q)
    //{
    //    var sql = "SELECT id, name, price FROM products WHERE name ILIKE @term";

    //    using var conn = new NpgsqlConnection(Db.Connection);
    //    return View(conn.Query<Product>(sql, new { term = $"%{q}%" }));
    //} 
    #endregion

    public IActionResult List(string sort = "1")
    {
        var sql = $"SELECT id, name, price FROM products ORDER BY {sort}";

        using var conn = new NpgsqlConnection(Db.Connection);
        var list = conn.Query<Product>(sql);

        return View(list);
    }
}

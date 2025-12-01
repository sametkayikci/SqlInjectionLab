using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SqlInjectionLab.Data;
using SqlInjectionLab.Models;

namespace SqlInjectionLab.Controllers;

public class AdminController : Controller
{
    public IActionResult Panel()
    {
        var role = HttpContext.Session.GetString("role");
        if (role != "admin")
            return Unauthorized();

        return View();
    }

    public IActionResult Users(string id)
    {
        var sql = $"SELECT id, username, role FROM users WHERE id = {id}";

        using var conn = new NpgsqlConnection(Db.Connection);
        var list = conn.Query<User>(sql);

        return View(list);
    }
}
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SqlInjectionLab.Data;
using SqlInjectionLab.Models;

namespace SqlInjectionLab.Controllers;

public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {

        var sql =
            $"SELECT id, username, role FROM users WHERE username = '{username}' AND password = '{password}'";

        using var conn = new NpgsqlConnection(Db.Connection);
        var user = conn.QueryFirstOrDefault<User>(sql);

        if (user != null)
        {
            HttpContext.Session.SetString("role", user.Role);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Login failed";

        return View();
    }

    #region Secure
    //[HttpPost]
    //public IActionResult Login(string username, string password)
    //{
    //    var sql = "SELECT id, username, role FROM users WHERE username = @username AND password = @password";

    //    using var conn = new NpgsqlConnection(Db.Connection);
    //    var user = conn.QueryFirstOrDefault<User>(sql, new { username, password });

    //    if (user != null)
    //    {
    //        HttpContext.Session.SetString("role", user.Role);
    //        return RedirectToAction("Index", "Home");
    //    }

    //    ViewBag.Error = "Login failed";
    //    return View();
    //} 
    #endregion
}
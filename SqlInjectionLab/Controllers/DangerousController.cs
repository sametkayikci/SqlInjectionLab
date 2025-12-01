using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SqlInjectionLab.Data;
using System;
using System.Data;

namespace SqlInjectionLab.Controllers;

public class DangerousController : Controller
{
    public IActionResult Execute(string sql)
    {
        if (string.IsNullOrWhiteSpace(sql))
            return View();

        try
        {
            using var conn = new NpgsqlConnection(Db.Connection);
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);


            if (sql.Trim().StartsWith("select", StringComparison.OrdinalIgnoreCase))
            {
                var table = new DataTable();
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(table);

                ViewBag.Table = table;
                ViewBag.Result = $"SQL çalıştırıldı: {sql}";
                return View("Result");
            }
            else
            {

                var affected = cmd.ExecuteNonQuery();
                ViewBag.Result = $"SQL çalıştırıldı: {sql} (Etkilenen satır: {affected})";
                return View("Result");
            }
        }
        catch (Exception ex)
        {
            ViewBag.Result = $"Hata: {ex.Message}";
            return View("Result");
        }
    }
}

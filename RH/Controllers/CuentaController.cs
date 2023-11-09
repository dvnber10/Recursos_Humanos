using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RH.Data;
using RH.Models;

namespace RH.Controllers
{
    [Route("[controller]")]
    public class CuentaController : Controller
    {
        private readonly Contexto _contexto;
        private readonly RecursosHumanosContext _context;
        public CuentaController(Contexto contexto, RecursosHumanosContext context)
        {
            _contexto = contexto;
            _context = context;
        }
        public IActionResult Login()
        {

            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null )
            {
                Console.WriteLine(c.Identity);
                if (c.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario u)
        {
            string correo = HttpContext.Request.Form["correo"];
            var userr = _context.Usuarios.Where(u => u.Correo == correo).FirstOrDefault();
            var idR = userr.IdRol;
            try
            {
                using (SqlConnection con = new(_contexto.Conexion))
                {
                    using (SqlCommand cmd = new("validar_datos", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar).Value = u.Correo;
                        cmd.Parameters.Add("@Contraseña", System.Data.SqlDbType.VarChar).Value = u.Contraseña;
                        con.Open();
                        Console.WriteLine(cmd.ToString());
                        var dr = cmd.ExecuteReader();
                        
                        while (dr.Read())
                        {
                            if (dr["Correo"] != null && u.Correo != null)
                            {
                                List<Claim> c = new List<Claim>(){
                                    new Claim(ClaimTypes.NameIdentifier, u.Correo),
                                    new Claim(ClaimTypes.Email,u.Correo!),
                                    new Claim(ClaimTypes.Name, u.Contraseña!),
                                    new Claim(ClaimTypes.Role, idR.ToString())
                                };
                                ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                                AuthenticationProperties p = new();
                                p.AllowRefresh = true;
                                p.IsPersistent = u.SesionActiva;

                                if (!u.SesionActiva)
                                {
                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1);
                                }
                                else
                                {
                                    p.ExpiresUtc = DateTimeOffset.MaxValue;
                                }
                                p.Items["Rol"] = u.IdRol.ToString();
                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                                if (idR.ToString()=="1")
                                {
                                    return RedirectToAction("Index","Admin");
                                }if (idR.ToString()=="2")
                                {
                                    
                                    return RedirectToAction("Index","Aspirante");
                                }if (idR.ToString()=="3")
                                {
                                    return RedirectToAction("Index","Empleado");
                                }if (idR.ToString()=="4")
                                {
                                    return RedirectToAction("Index","Gerente");
                                }if (idR.ToString()=="1")
                                {
                                    return RedirectToAction("Index","Gestor");
                                }
                            }else
                            {
                                ViewBag.Error = "Credenciales incorrectas o usuario no registrado";
                            }

                        }
                        con.Close();

                    }
                    return View();
                }
            }
            catch (System.Exception e)
            {
                ViewBag.Error = e.Message;
                Console.WriteLine(e); 
                return View();
            }
        }
    }
}
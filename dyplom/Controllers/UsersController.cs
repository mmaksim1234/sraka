using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dyplom.Data;
using dyplom.Models;

namespace dyplom.Controllers
{
    public class UsersController : Controller
    {
        private readonly dyplomContext _context;

        public UsersController(dyplomContext context)
        {
            _context = context;
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Models.Login model)

        {
            if (!ModelState.IsValid)
            {
                // Введено неправильний формат email, додавання відповідної помилки в ModelState
                ModelState.AddModelError(nameof(Models.Login.Email), "Неправильний формат email");
                return View(model);
            }
            var user = _context.User.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                if (user.Password == model.Password)
                {
                    HttpContext.Session.SetString("Id", user.Id.ToString());

                    return RedirectToAction("Index", "Home", user);
                }
            }
            
            

                // Помилка: невірний електронний лист або пароль
               
                
            ViewData["UserNotFound"] = true;
            return View();

            
        }
        // GET: Users
        
        public IActionResult Login()
        {
            return View();
        }
        // GET: Users/Details/5



        // GET: Users/Create
        public IActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Id")))
            {
                // User is already logged in, redirect to another action or return a view
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,repeatPassword")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}

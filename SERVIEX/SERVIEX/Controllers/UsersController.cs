using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SERVIEX.Contexts;
using SERVIEX.Entities;
using SERVIEX.Helpers;
using SERVIEX.Models;

namespace SERVIEX.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICombosHelper _combosHelper;

        public UsersController(ApplicationDbContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.users
                .Include(u => u.gender)
                .ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .Include(u => u.gender)
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            UserViewModel user = new UserViewModel
            {
                Genders = _combosHelper.GetComboGenders(),
            };
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    BornDate = model.BornDate,
                    gender = await _context.genders.FindAsync(model.GenderId),
                    Name = model.Name
                };

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            model.Genders = _combosHelper.GetComboGenders();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .Include(u => u.gender)
                .FirstOrDefaultAsync(u => u.id == id);

            if (user == null)
            {
                return NotFound();
            }

            UserViewModel model = new UserViewModel
            {
                id = user.id,
                BornDate = user.BornDate,
                GenderId = user.gender != null ? user.gender.id : 0,
                Genders = _combosHelper.GetComboGenders(),
                Name = user.Name,
                gender = user.gender,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserViewModel model)
        {
            if (id != model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User
                    {
                        BornDate = model.BornDate,
                        gender = await _context.genders.FindAsync(model.GenderId),
                        Name = model.Name,
                        id = model.id
                    };
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(model.id))
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
            model.Genders = _combosHelper.GetComboGenders();
            return View(model);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.users.FindAsync(id);
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.id == id);
        }
    }
}

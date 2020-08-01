using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(ApplicationDbContext context,
                                         UserManager<MyUser> userManager,
                                         RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ListWithUsers()
        {
            var applicationDbContext = await _userManager.Users.Include(e => e.Movie).ToListAsync();
            List<UserViewModel> model = new List<UserViewModel>();
            foreach (var user in applicationDbContext)
            {
                var userToModel = new UserViewModel();
                var roleUser = await _userManager.GetRolesAsync(user);

                if (roleUser.Count > 0)
                {
                    userToModel.Role = roleUser[0];
                }
                else
                {
                    userToModel.Role = "Acest utilizator nu are un rol alocat";
                }

                userToModel.ID = user.Id;
                userToModel.FullName = user.FullName;
                userToModel.PhoneNumber = user.PhoneNumber;
                model.Add(userToModel);
            }
            return View(model);

        }
        [AcceptVerbs("Post")]
        public async Task<IActionResult> EditRole(string email, string role)
        {
            if (role != null)
            {
                var myUser = await _userManager.FindByEmailAsync(email);
                var roleFromDb = await _userManager.GetRolesAsync(myUser);
                await _userManager.RemoveFromRolesAsync(myUser, roleFromDb.ToArray());
                var newRole = new IdentityRole();
                newRole.Name = role;
                await _userManager.AddToRoleAsync(myUser, newRole.Name);
                await _userManager.UpdateAsync(myUser);
                await _context.SaveChangesAsync();
            }
            
            
            return RedirectToAction("ListWithUsers");
        }

        public async Task<IActionResult> GiveEmail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var userProjectModel = new UserViewModel();

            userProjectModel.Email = user.Email;
            userProjectModel.FullName = user.FullName;

            return Json(new { success = true, data = userProjectModel, message = "Emailul a fost trimis in modal" });
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
             _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListWithUsers));
        }
    }
}
    


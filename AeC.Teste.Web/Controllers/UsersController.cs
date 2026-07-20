using AeC.Teste.Web.Services.Interfaces;
using AeC.Teste.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AeC.Teste.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICsvService _csvService;

        public UsersController(IUserService userService, ICsvService csvService)
        {
            _userService = userService;
            _csvService = csvService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _userService.UsernameExistsAsync(model.Username))
            {
                ModelState.AddModelError(nameof(model.Username),
                    "Já existe um usuário com esse nome de usuário.");

                return View(model);
            }

            await _userService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _userService.UsernameExistsAsync(model.Username, model.Id))
            {
                ModelState.AddModelError(nameof(model.Username),
                    "Já existe um usuário com esse nome de usuário.");

                return View(model);
            }

            await _userService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ExportCsv()
        {
            var users = await _userService.GetAllAsync();

            var exportData = users.Select(u => new UserExportViewModel
            {
                Nome = u.Name,
                Usuário = u.Username
            }).ToList();

            var csvBytes = _csvService.GenerateCsv(exportData);

            var fileName = $"usuarios_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            return File(csvBytes, "text/csv; charset=utf-8", fileName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, UserEditViewModel model)
        {
            await _userService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

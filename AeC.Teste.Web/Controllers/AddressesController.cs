using AeC.Teste.Web.Services.Interfaces;
using AeC.Teste.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AeC.Teste.Web.Controllers
{
    [Authorize]
    public class AddressesController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IActionResult> Index()
        {
            var addresses = await _addressService.GetAllAsync();

            return View(addresses);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var users = await _addressService.GetUsersSelectListAsync();

            ViewBag.Users = users;

            return View(new AddressCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var users = await _addressService.GetUsersSelectListAsync();
                ViewBag.Users = users;

                return View(model);
            }

            await _addressService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var address = await _addressService.GetByIdAsync(id);

            if (address == null)
                return NotFound();

            var users = await _addressService.GetUsersSelectListAsync();
            ViewBag.Users = users;

            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddressEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var users = await _addressService.GetUsersSelectListAsync();
                ViewBag.Users = users;

                return View(model);
            }

            await _addressService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _addressService.GetByIdAsync(id);

            if (address == null)
                return NotFound();

            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AddressEditViewModel model)
        {
            await _addressService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

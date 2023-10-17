using DSC.Models.DTOs;
using DSC.Models.Enums;
using DSC.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IEmailService _emailService;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_emailService = emailService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Login()
		{
			return View(new LoginDto());
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			if (!ModelState.IsValid) return View(loginDto);
			var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Email);
			if (user == null) return View(loginDto);
			var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, true, false);
			if (!result.Succeeded) return View(loginDto);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View(new RegsiterDto());
		}

		[HttpPost]
		public async Task<ActionResult> Register(RegsiterDto registerDto)
		{
			if (!ModelState.IsValid) return View(registerDto);

			if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
			{
				ModelState.AddModelError("Email", "The Email is Taken");
				return View(registerDto);
			}

			var user = new User
			{
				UserName = registerDto.Email,
				Email = registerDto.Email,
				PhoneNumber = registerDto.PhoneNumber,
				Mobile = registerDto.MobileNumber,
				Name = registerDto.Name,
				EmailConfirmed = false
			};

			var result = await _userManager.CreateAsync(user, registerDto.Password);

			if (!result.Succeeded) return View(registerDto);

			/*  var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
              var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
              await _emailService.SendAsync(user.Email, "Confirm Your Email", confirmationLink);*/

			await _signInManager.SignInAsync(user, true);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet("ConfirmEmail")]
		public async Task<IActionResult> ConfirmEmail(string token, string email)
		{
			if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
				return View();

			var user = await _userManager.FindByEmailAsync(email);

			if (user == null) return View();

			var result = await _userManager.ConfirmEmailAsync(user, token);

			if (!result.Succeeded)
				return View();

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> Profile()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null) return RedirectToAction("Index", "Error");

			var dto = new UserProfileDto()
			{
				Email = user.Email,
				FullName = user.Name,
				MobileNumber = user.Mobile,
				PhoneNumber = user.PhoneNumber,
			};

			return View(dto);
		}
	}
}
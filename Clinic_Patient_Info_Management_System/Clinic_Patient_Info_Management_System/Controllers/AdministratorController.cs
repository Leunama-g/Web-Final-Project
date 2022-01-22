using Clinic_Patient_Info_Management_System.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Clinic_Patient_Info_Management_System.Controllers
{
    public class AdministratorController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public AdministratorController() 
        { 
        }

        public AdministratorController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public List<SelectListItem> specialtyList()
        {
            var sp = context.Specialties.ToList();
            List<SelectListItem> sps = new List<SelectListItem>();

            foreach (var item in sp)
            {
                sps.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

            return sps;
        }

        public List<SelectListItem> roleList()
        {
            var sp = context.Roles.ToList();
            List<SelectListItem> sps = new List<SelectListItem>();

            foreach (var item in sp)
            {
                sps.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

            return sps;
        }

        public ActionResult Index()
        {
            var buffer = context.Employees.ToList();
            List<AdminIndexViewModel> model = new List<AdminIndexViewModel>();

            foreach (var item in buffer)
            {
                model.Add(new AdminIndexViewModel { UserID = item.UserID, FirstName = item.FirstName, LastName = item.LastName, Type = item.Type });
            }
            return View(model);
        }
        
        public ActionResult Edit(string UserID) 
        {
            Employee user = context.Employees.Where(emp => emp.UserID == UserID).FirstOrDefault();
            EditEmpViewModel model = new EditEmpViewModel();

            model.AccountType = user.Type;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Birthdate = user.Birthdate.Day;
            model.BirthMonth = user.Birthdate.Month;
            model.BirthYear = user.Birthdate.Year;
            model.Adderess = user.Adderess;
            model.PhoneNumber = user.PhoneNumber;
            model.Specialty = user.Specialty;
            
            ViewBag.specialties = specialtyList();
            ViewBag.roles = roleList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEmpViewModel model)
        {
            Employee NewUser = context.Employees.Where(emp => emp.Id == model.Id).FirstOrDefault();
            NewUser.FirstName = model.FirstName;
            NewUser.LastName = model.LastName;
            NewUser.Birthdate = new DateTime(model.BirthYear, model.BirthMonth, model.Birthdate);
            NewUser.Email = model.Email;
            NewUser.Adderess = model.Adderess;
            NewUser.PhoneNumber = model.PhoneNumber;
            NewUser.Type = model.AccountType;
            NewUser.Specialty = model.Specialty;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {

            ViewBag.specialties = specialtyList();
            ViewBag.roles = roleList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterEmpViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, model.AccountType);
                    Employee NewUser = new Employee();
                    NewUser.UserID = user.Id;
                    NewUser.FirstName = model.FirstName;
                    NewUser.LastName = model.LastName;
                    NewUser.Birthdate = new DateTime(model.BirthYear, model.BirthMonth, model.Birthdate);
                    NewUser.Email = model.Email;
                    NewUser.Adderess = model.Adderess;
                    NewUser.PhoneNumber = model.PhoneNumber;
                    NewUser.Type = model.AccountType;
                    NewUser.Specialty = model.Specialty;
                    context.Employees.Add(NewUser);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            ViewBag.specialties = specialtyList();
            ViewBag.roles = roleList();

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
    }
}
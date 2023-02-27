using lts.DTOS.Concrete;
using LTS.WEBUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace LTS.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<HesapUser> userManager;
        private readonly SignInManager<HesapUser> signInManager;
        private readonly RoleManager<HesapRol> _roleManager;
        public AccountController(UserManager<HesapUser> userManager, SignInManager<HesapUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            else
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Bu mail kayitli degildir");
                    return View(model);
                }

                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Bu mail onaylanmamistir. Lutfen mail box'inizi kontrol ediniz");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("UyeAnasayfasi", "Home");
                }

                ModelState.AddModelError("", "Email yada parola yanliş");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            else
            {
                var user = new HesapUser
                {

                    UserName=model.UserName,
                    Email = model.Email,
                    Tc = model.Tckimlik

                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    StringBuilder mailbuilder = new StringBuilder();
                    mailbuilder.Append("<html>");
                    mailbuilder.Append("<head>");
                    mailbuilder.Append("<meta charset='" + "utf-8'" + " />");
                    mailbuilder.Append("<title> Email Onaylama</title>");
                    mailbuilder.Append("</head>");
                    mailbuilder.Append("<body>");

                    mailbuilder.Append($"<p> Merhaba {user.UserName} </p><br/>");
                    mailbuilder.Append($"Mail adresinizi onaylamak için aşagida ki linki tıklayın.<br/>");

                    mailbuilder.Append($"<a href='https://localhost:5001/ConfirmEmail/?uid={user.Id}&code={code}'>Email Onaylayın</a>");

                    mailbuilder.Append("</body>");

                    mailbuilder.Append("</html>");

                    EmailHelper helper = new EmailHelper();

                    bool isSend = helper.SendEmail(user.Email, mailbuilder.ToString());

                    if (isSend)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mail gonderilemedi");
                        return View(model);
                    }
                }
                ModelState.AddModelError("", "büyük harf, . @ vb. Koyunuz.");
                return View(model);
            }
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string uid, string code)
        {

            ConfirmMailModel model = new ConfirmMailModel();

            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(code))
            {
                var user = await userManager.FindByIdAsync(uid);

                code = code.Replace(' ', '+');

                model.Email = user.Email;

                var result = await userManager.ConfirmEmailAsync(user, code);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    model.ErrorDescription = error.Description;
                    model.hasError = true;
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }
            return View(model);
        }
   
        public async Task<PartialViewResult> KullanicilariListele()
        {
            var result = await userManager.Users.ToListAsync();

            return PartialView("~/Views/Shared/Components/KullaniciIslemleri/KullaniciIslemleri.cshtml", result);
        }

        [HttpPost]
        public async Task<JsonResult> KullaniciKaydet(RegisterModel model)
        {
            Random random = new Random();
            var sifre = random.Next(100000, 999999).ToString();
            var user = new HesapUser
            {
                UserName = model.UserName,
                Email = model.Email,
                GeciciSifre = sifre
            };
        
            var result = await userManager.CreateAsync(user, "GeciciSifre1.");
            
            if (result.Succeeded)
            {
                var user1 = await userManager.FindByEmailAsync(user.Email);
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(user1);
                var emailToken = await userManager.GenerateEmailConfirmationTokenAsync(user1);
                StringBuilder mailbuilder = new StringBuilder();
                mailbuilder.Append("<html>");
                mailbuilder.Append("<head>");
                mailbuilder.Append("<meta charset='" + "utf-8'" + " />");
                mailbuilder.Append("<title>Kullanıcı İşlemleri</title>");
                mailbuilder.Append("</head>");
                mailbuilder.Append("<body>");
                mailbuilder.Append($"<p> Merhaba {user.UserName} </p><br/>");
                mailbuilder.Append($"Kullanıcınızı aktif etmek için <a href='https://localhost:5001/Account/ActivateUser/?uid={user1.Id}&code={resetToken}&emailCode={emailToken}'>tıklayınız.</a>.<br/>");
                mailbuilder.Append($"Tek kullanımlık şifrenizi girerek yeni şifrenizi oluşturup kullanıcınızı aktif edebilirsiniz.<br/>");
                mailbuilder.Append($"Tek kullanımlık şifre:{sifre}");
                mailbuilder.Append("</body>");
                mailbuilder.Append("</html>");

                EmailHelper helper = new EmailHelper();

                bool isSend = helper.SendEmail(user1.Email, mailbuilder.ToString());

                if (isSend)
                {
                    return Json(new { result = true });
                }
                else
                {
                    return Json(new { result = false });
                }
            }


            return Json(new { result = false });
        }

        [HttpGet]
        public async Task<IActionResult> ActivateUser(string uid, string code, string emailCode)
        {
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(emailCode))
            {
                var user = await userManager.FindByIdAsync(uid);
                if (user != null && user.GeciciSifre != null)
                {
                    KullaniciAktif model = new KullaniciAktif();
                    model.UserId = uid;
                    model.ResetCode = code;
                    model.EmailCode = emailCode;

                    return View(model);
                }
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ActivateUser(KullaniciAktif model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            
            if (user != null && user.GeciciSifre == model.Password)
            {
                KullaniciAktif kullanici = new KullaniciAktif();
                kullanici.UserId = model.UserId;
                kullanici.ResetCode = model.ResetCode;
                kullanici.EmailCode = model.EmailCode;
                return Json(new { result = true, url = Url.Action("KullaniciYeniSifre", kullanici) });
            }
            return Json(new { result = false });
        }

        [HttpPost]
        public IActionResult KullaniciYeniSifre(KullaniciAktif model)
        {
            return PartialView("~/Views/Shared/Components/KullaniciIslemleri/KullaniciAktifEt.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> ActivateUserNewPassword(KullaniciAktif model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            if (user != null && model.Password == model.RPassword)
            {
                model.ResetCode = model.ResetCode.Replace(' ', '+');
                model.EmailCode = model.EmailCode.Replace(' ', '+');
                IdentityResult resultEmail = await userManager.ConfirmEmailAsync(user, model.EmailCode);
                IdentityResult result = await userManager.ResetPasswordAsync(user, model.ResetCode, model.Password);

                if (result.Succeeded && resultEmail.Succeeded)
                {
                    user.GeciciSifre = null;
                    await userManager.UpdateAsync(user);
                    await userManager.UpdateSecurityStampAsync(user);
                    return Json(new { result = true });
                }
                else
                {
                    return Json(new { result = false });
                }
            }

            return Json(new { result = false });
        }
        
        
        [HttpPost]
        public async Task<IActionResult> KullaniciGuncelle(KullanicilarDTO model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                user.Tc = model.Tc;
                user.UserName = model.Ad;
                var result = await userManager.UpdateAsync(user);
                var result1 = await userManager.UpdateSecurityStampAsync(user);

                if (result.Succeeded && result1.Succeeded)
                {                   
                    return Json(new { result = true });
                }
                else
                {
                    return Json(new { result = false });
                }
            }

            return Json(new { result = false });
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciSil(KullanicilarDTO model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {             
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return Json(new { result = true });
                }
                else
                {
                    return Json(new { result = false });
                }
            }

            return Json(new { result = false });
        }

        [HttpGet]
        public IActionResult SifremiUnuttum()
        {
            return View(new KullanicilarDTO());
        }

        [HttpPost]
        public async Task<IActionResult> SifremiUnuttum(KullanicilarDTO model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);

                StringBuilder mailbuilder = new StringBuilder();
                mailbuilder.Append("<html>");
                mailbuilder.Append("<head>");
                mailbuilder.Append("<meta charset='" + "utf-8'" + " />");
                mailbuilder.Append("<title>Şifremi Unuttum</title>");
                mailbuilder.Append("</head>");
                mailbuilder.Append("<body>");
                mailbuilder.Append($"<p> Merhaba {user.UserName} </p><br/>");
                mailbuilder.Append($"Yeni şifre oluşturmak için <a href='https://localhost:5001/Account/KullaniciSifreYenileme/?uid={user.Id}&code={resetToken}'>tıklayınız.</a>.<br/>");
                mailbuilder.Append("</body>");
                mailbuilder.Append("</html>");

                EmailHelper helper = new EmailHelper();

                bool isSend = helper.SendEmail(user.Email, mailbuilder.ToString());

                if (isSend)
                {
                    return Json(new { result = true });
                }
                else
                {
                    return Json(new { result = false });
                }
            }
            else
            {
                return Json(new { result = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> KullaniciSifreYenileme(string uid, string code)
        {
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(uid))
            {
                var user = await userManager.FindByIdAsync(uid);
                if (user != null)
                {
                    KullaniciAktif model = new KullaniciAktif();
                    model.UserId = uid;
                    model.ResetCode = code;

                    return View(model);
                }
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciSifreYenileme(KullaniciAktif model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            if (user != null && model.Password == model.RPassword)
            {
                model.ResetCode = model.ResetCode.Replace(' ', '+');

                IdentityResult result = await userManager.ResetPasswordAsync(user, model.ResetCode, model.Password);

                if (result.Succeeded)
                {
                    return Json(new { result = true });
                }
                else
                {
                    return Json(new { result = false });
                }
            }

            return Json(new { result = false });
        }

        //[HttpGet]
        //public async Task<PartialViewResult> RolleriListele()
        //{
          

        //    return PartialView("~/Views/Shared/Components/KullaniciIslemleri/KullaniciIslemleri.cshtml", result);
        //}
    }
}
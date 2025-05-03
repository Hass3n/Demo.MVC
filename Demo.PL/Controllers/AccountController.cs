using System.Threading.Tasks;
using Demo.DAL.Models;
using Demo.PL.Utlities;
using Demo.PL.viewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Demo.PL.Controllers
{
    public class AccountController(UserManager<applicationUser> _userManager, SignInManager<applicationUser> _signInManager) : Controller
    {
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if(ModelState.IsValid)
            {

                //manual mapping
                var user = new applicationUser()
                {
                    UserName = viewModel.Email.Split("@")[0],  // hassan@gmail.com  [hassan
                    Email=viewModel.Email,
                    firstName = viewModel.FirstName,
                    lastName = viewModel.LastName,
                    IAgree =viewModel.IsAgree
                   
                };


                var result = _userManager.CreateAsync(user, viewModel.Password).Result;
                if (result.Succeeded)
                
                       return  RedirectToAction(nameof(LoginIn));

                
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }

                    return View(viewModel);
                }
            }

            return View(viewModel);
        }
        #endregion


        #region Login In
        [HttpGet]
        public IActionResult LoginIn()
        {
            return View();
        }


        [HttpPost]

        public IActionResult LoginIn(LoginViewModel viewModel)
        {

            if (!ModelState.IsValid) return View(viewModel);
            var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
            if(user is not null)
            {

                bool flag = _userManager.CheckPasswordAsync(user,viewModel.Password).Result;

                if (flag)
                {
                    /**
                   PasswordSignInAsync()  take third Parmeter  Ispersistant

                       token يمسح ال false  لو token  يعمل true  لو ب token ده مسؤل عن عمل ال  

                     عشان لو المستخدم علم عاليه يعمل التوكن لو معلمش يمسحهviewModel.RememberMe أنا هنا بعتله
                     
                     
                     */


                    /*****
                     *   PasswordSignInAsync()  take four Parmeter  Lock
                     * 
                     * true لو المستخدم حاول يدخل بالحساب بتاعه وكتبه خطا أكثر من مره تعمله لوك لوانتا بعت 
                     *  مش عاوز أفعل الخصيه دي false  لكن أنا هنا باعت 
                     * **************/
                    var result = _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false).Result;

                    if (result.IsNotAllowed)
                          ModelState.AddModelError(string.Empty, "Login is not allowed");
                    if (result.IsLockedOut)
                            ModelState.AddModelError(string.Empty, "Your Account Is locked out");

                     if(result.Succeeded)
                  
                             return   RedirectToAction(nameof(HomeController.Index),"Home");

                    
                }

           

              

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Invalid");

            }

            return View(viewModel);


        }


        #endregion

        #region SignOut
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(LoginIn));
        }
        #endregion


        #region ForgetPassword

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckyourInbox()
        {
            return View();
        }


        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel viewModel)
        {
            if(ModelState.IsValid)
            {

                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if(user is not null)
                {
                    // create Link with send To Email

                    //AddDefaultTokenProviders تضيف ده programe  محتاج في  Login غير الي بيتعمل في token ده 
                    var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;

                    var resetPasswordUrl = Url.Action("ResetPassword", "Account", new { email = viewModel.Email, token = token },Request.Scheme);


                    // send mail

                    var email = new Emails()
                    {
                        To = viewModel.Email,
                        Subject = "Reset Password",
                        Body = resetPasswordUrl

                    };

                    Emailsetting.sendEmail(email);

                    return RedirectToAction("CheckyourInbox");
                }
               
           
            }

            ModelState.AddModelError(string.Empty, "Invalid Opertion");
            return View(nameof(ForgetPassword), viewModel);
        }

        [HttpGet]
        public IActionResult ResetPassword(string email,string token)
        {
            // send Data from request to other request
            // email token هيجيب من اللينك الي بيتبعت علي الايميل 
            TempData["email"] = email;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            string email = TempData["email"] as string ??string.Empty;
            string token = TempData["token"] as string ?? string.Empty;
            var user = _userManager.FindByEmailAsync(email).Result;
            if(user is not null)
            {
              var result=  _userManager.ResetPasswordAsync(user, token, viewModel.Password).Result;

                if (result.Succeeded)
                    return RedirectToAction(nameof(LoginIn));
     

                else
                {
                    foreach (var item in result.Errors)
                    {

                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
                 
                


            }

            return View(nameof(ResetPassword),viewModel);

        }
        #endregion
    }
}

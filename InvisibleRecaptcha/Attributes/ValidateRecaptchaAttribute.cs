using InvisibleRecaptcha.Services;
using System.Web.Mvc;

namespace InvisibleRecaptcha.Attributes
{
    public class ValidateRecaptchaAttribute : ActionFilterAttribute
    {
        private const string RECAPTCHA_RESPONSE_KEY = "g-recaptcha-response";
        
        public ICaptchaValidationService CaptchaService { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!CaptchaService.Validate(filterContext.HttpContext.Request[RECAPTCHA_RESPONSE_KEY]))
                filterContext.Controller.ViewData.ModelState.AddModelError("Recaptcha", "Captcha validation failed.");
        }
    }
}
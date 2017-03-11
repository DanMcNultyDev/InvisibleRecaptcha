namespace InvisibleRecaptcha.Services
{
    public interface ICaptchaValidationService
    {
        bool Validate(string response);
    }
}
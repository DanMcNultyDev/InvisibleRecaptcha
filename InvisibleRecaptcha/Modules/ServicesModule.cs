using Autofac;
using InvisibleRecaptcha.Services;
using System.Configuration;

namespace InvisibleRecaptcha.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx =>
            {
                return new InvisibleRecaptchaValidationService(ConfigurationManager.AppSettings["Recaptcha:SecretKey"]);
            }).As<ICaptchaValidationService>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
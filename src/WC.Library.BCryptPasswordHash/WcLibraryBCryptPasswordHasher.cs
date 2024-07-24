using Autofac;

namespace WC.Library.BCryptPasswordHash;

public class WcLibraryBCryptPasswordHasher : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<BCryptPasswordHasher>()
            .As<IBCryptPasswordHasher>()
            .InstancePerLifetimeScope();
    }
}

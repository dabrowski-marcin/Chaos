using Autofac;
using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Models;

namespace Chaos.Src.Engine
{
    public class ServiceContainer
    {
        public static IContainer Container;

        static ServiceContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Gameboard>().As<IGameboard>().SingleInstance();
            builder.RegisterType<Spellboard>().As<ISpellboard>().SingleInstance();
            builder.RegisterType<GameboardActionHandler>().As<IGameboardActionHandler>().SingleInstance();

            Container = builder.Build();
        }
    }
}
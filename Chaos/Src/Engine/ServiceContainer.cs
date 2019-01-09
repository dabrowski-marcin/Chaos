using Autofac;
using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Engine.Handlers;
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

            builder.RegisterType<GameEventHandler>().As<IGameEventHandler>().SingleInstance();
            builder.RegisterType<GameboardHandler>().As<IGameboardHandler>().SingleInstance();
            builder.RegisterType<ButtonsHandler>().As<IButtonsHandler>().SingleInstance();
            builder.RegisterType<InfoStringHandler>().As<IInfoStringHandler>().SingleInstance();
            builder.RegisterType<SpellboardHandler>().As<ISpellboardHandler>().SingleInstance();

            Container = builder.Build();
        }
    }
}
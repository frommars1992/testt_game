using camera;
using gameLogic;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
using TestGame.Signals;
using TestGame.Signals.game_logic;
using UnityEngine;

namespace context
{
    public class TestContext : MVCSContext
    {
        public EnemySettings EnemySettings { get; set; }

        public TestContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        public override IContext Start()
        {
            base.Start();
            return this;
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            //change event binder to signal binder
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
            injectionBinder.Bind<MVCSContext>().ToValue(this).ToName(ContextKeys.CONTEXT);
        }

        protected override void mapBindings()
        {
            commandBinder.Bind<SignalEnemyDie>();
            commandBinder.Bind<SignalEnemyHit>();
            commandBinder.Bind<SignalPushInput>();
            commandBinder.Bind<SignalPlayerChangeMovement>();
            injectionBinder.Bind<EnemySettings>().ToValue(EnemySettings).ToSingleton();
            injectionBinder.Bind<IEnemyManager>().To<EnemyManager>().ToSingleton();
            injectionBinder.Bind<IEnemy>().To<Enemy>();
            mediationBinder.Bind<BowView>().To<Bow>();
            mediationBinder.Bind<EnemyView>().To<Enemy>();
            mediationBinder.Bind<CameraShakeView>().To<CameraShakeMediator>();
            mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
        }
    }
}
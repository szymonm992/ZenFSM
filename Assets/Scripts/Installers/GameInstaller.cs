using Zenject;
using FSM.GameManager;
using FSM.GameManager.States;
using FSM.Helper;
using UnityEngine.UI;
using UnityEngine;

namespace FSM.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public Text countdown_of_current, general_countdown;

        public GameObject ui_calibration,ui_menu,ui_anim2state,ui_exit;
        public override void InstallBindings()
        {
            //we calling the separated functions, just to split things
            InstallGameManager();
            InstallMisc();
        }

        private void InstallGameManager()
        {
            //binding all the necessery stuff
            Container.Bind<GameStateFactory>().AsSingle();

            //...and interfaces&classes connected to it
            Container.BindInterfacesAndSelfTo<CalibrationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimationOneState>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimationTwoState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExitState>().AsSingle();

            //binding factories
            Container.BindFactory<CalibrationState, CalibrationState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<MenuState, MenuState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<AnimationOneState, AnimationOneState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<AnimationTwoState, AnimationTwoState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<ExitState, ExitState.Factory>().WhenInjectedInto<GameStateFactory>();
            

        }

        private void InstallMisc()
        {
            //binding the coroutines-invoker
            Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
            //binding the curretn countdown text
            Container.Bind<Text>().WithId("ui_countdown").FromInstance(countdown_of_current).NonLazy();
            Container.Bind<Text>().WithId("ui_gen_countdown").FromInstance(general_countdown).NonLazy();

            //binding the canvas
            Container.Bind<GameObject>().WithId("ui_calibration").FromInstance(ui_calibration).NonLazy();
            Container.Bind<GameObject>().WithId("ui_menu").FromInstance(ui_menu).NonLazy();
            Container.Bind<GameObject>().WithId("ui_anim2state").FromInstance(ui_anim2state).NonLazy();
            Container.Bind<GameObject>().WithId("ui_exit").FromInstance(ui_exit).NonLazy();
        }
    }
}
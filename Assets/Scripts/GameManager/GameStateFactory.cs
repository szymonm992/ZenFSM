using ModestTree;
using FSM.GameManager.States;

namespace FSM.GameManager
{

    //all the available states
    internal enum GameState
    {
        Calibration,
        Menu,
        AnimationOneState,
        AnimationTwoState,
        Exit
    }


    //the constructor for the state factory
    public class GameStateFactory
    {
        readonly CalibrationState.Factory _calibrationFac;
        readonly MenuState.Factory _menuFac;
        readonly AnimationOneState.Factory _aoFac;
        readonly AnimationTwoState.Factory _atFac;
        readonly ExitState.Factory _exitFac;

        public GameStateFactory(
                                CalibrationState.Factory calFactory,
                                MenuState.Factory menFac,
                                AnimationOneState.Factory aocFac,
                                AnimationTwoState.Factory atFac,
                                ExitState.Factory exFac)
        {
            _calibrationFac = calFactory;
            _menuFac = menFac;
            _aoFac = aocFac;
            _atFac = atFac;
            _exitFac = exFac;
        }

        // Creates the requested game state entity
        internal GameStateEntity CreateState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Calibration:
                    return _calibrationFac.Create();                
                
                case GameState.Menu:
                    return _menuFac.Create();
                
                case GameState.AnimationOneState:
                    return _aoFac.Create();
                    
                case GameState.AnimationTwoState:
                    return _atFac.Create(); 
                
                case GameState.Exit:
                    return _exitFac.Create();

            }
            //when no state matches we throw an exception(just in case)
            throw Assert.CreateException("Exception found... just saying...");
        }
    }
}
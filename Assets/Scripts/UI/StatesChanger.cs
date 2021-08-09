using UnityEngine;
using UnityEngine.UI;
using Zenject;
using FSM.GameManager;
using System.Collections;

namespace UI
{
    public class StatesChanger : MonoBehaviour
    {
        [Inject]
        readonly GameManager _gameManager;

        [Inject(Id = "ui_gen_countdown")]
        Text countdown_text;

        bool isCountdownRunning = false;
        public void SwitchCalibration()
        {
            _gameManager.ChangeState(GameState.Calibration);
        }

        public void StartMenuState()
        {
            _gameManager.ChangeState(GameState.Menu);
            //at first occurence of menu state we start countdown
            if(!isCountdownRunning)
            {
                StartCoroutine(GenCountdown());
                isCountdownRunning = true;
            }
        }

        public void ChangeToExit()
        {
            _gameManager.ChangeState(GameState.Exit);
        }

        public void SwitchAnimationOne()
        {
            _gameManager.ChangeState(GameState.AnimationOneState);
        }
        public void SwitchAnimationTwo()
        {
            _gameManager.ChangeState(GameState.AnimationTwoState);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        void UpdateTimer(int cur)
        {
            //just update the interface
            countdown_text.text = cur.ToString();
        }


        IEnumerator GenCountdown()
        {
            //we could also do it in void update but coroutine looks more pro :))
            int countdown = 60;
            UpdateTimer(countdown);
            while (countdown > 0)
            {
                yield return new WaitForSeconds(1);
                countdown -= 1;
                UpdateTimer(countdown);
            }
            //quitting the application when countdown finishes
            Application.Quit();
        }
    }


    
}
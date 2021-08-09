using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using FSM.Helper;

namespace FSM.GameManager.States
{
    public class AnimationTwoState : GameStateEntity
    {
        readonly AsyncProcessor _asyncProcessor;
        readonly GameManager _gameManager;

        [Inject(Id = "ui_countdown")]
        internal Text countdown_text;

        [Inject(Id = "ui_anim2state")]
        GameObject canvas_assigned;

        public AnimationTwoState(AsyncProcessor asyncProcessor,
                             GameManager gameManager)
        {
            _asyncProcessor = asyncProcessor;
            _gameManager = gameManager;
        }

        public override void Initialize()
        {
            Debug.Log("Animation 2 state Initialized");
        }

        public override void Start()
        {
            Debug.Log("Animation 2 state Started");
            //lets start the countdown
            _asyncProcessor.StartCoroutine(Countdown(10));
        }

        void AfterCounting()
        {
            countdown_text.text = "";
            canvas_assigned.SetActive(true);
        }

        IEnumerator Countdown(int seconds)
        {
            //we call the local countdown for the current state
            int countdown = seconds;
            UpdateTimer(countdown);
            while (countdown > 0)
            {
                yield return new WaitForSeconds(1);
                countdown -= 1;
                UpdateTimer(countdown);
            }

            AfterCounting();
        }

        void UpdateTimer(int cur)
        {
            //update the interface
            countdown_text.text = cur.ToString();
        }

        public override void Tick()
        {
        }

        public override void Dispose()
        {
            canvas_assigned.SetActive(false);
            Debug.Log("Animation 2 state Disposed");
        }

        public class Factory : Factory<AnimationTwoState>
        {
        }
    }
}
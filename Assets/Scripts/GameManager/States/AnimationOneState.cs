using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using FSM.Helper;

namespace FSM.GameManager.States
{
    public class AnimationOneState : GameStateEntity
    {
        readonly AsyncProcessor _asyncProcessor;
        readonly GameManager _gameManager;

        [Inject(Id = "ui_countdown")]
        internal Text countdown_text;




        public AnimationOneState(AsyncProcessor asyncProcessor,
                             GameManager gameManager)
        {
            _asyncProcessor = asyncProcessor;
            _gameManager = gameManager;
        }

        public override void Initialize()
        {
            Debug.Log("Animation 1 state Initialized");
        }

        public override void Start()
        {
            Debug.Log("Animation 1 state Started");
            _asyncProcessor.StartCoroutine(Countdown(10));
        }

        void AfterCounting()
        {
            countdown_text.text = "";
            _gameManager.ChangeState(GameState.AnimationTwoState);
        }

        IEnumerator Countdown(int seconds)
        {
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
            countdown_text.text = cur.ToString();
        }

        public override void Tick()
        {
        }

        public override void Dispose()
        {
            Debug.Log("Animation 1 state Disposed");
        }

        public class Factory : Factory<AnimationOneState>
        {
        }
    }
}
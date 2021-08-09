﻿using UnityEngine;
using UnityEngine.UI;
using Zenject;
using FSM.GameManager.States;

namespace FSM.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private GameStateFactory _gameStateFactory;

        private GameStateEntity _gameStateEntity = null;

        [SerializeField]
        private GameState _currentGameState;
        [SerializeField]
        private GameState _previousGameState;

        public Text stateText;
        
        [Inject]
        public void Construct(GameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory;
        }

        private void Start()
        {
            //we set default state
            ChangeState(GameState.Calibration);
        }

        /// switches the game states
        internal void ChangeState(GameState gameState)
        {
            if (_gameStateEntity != null)
            {
                _gameStateEntity.Dispose();
                _gameStateEntity = null;
            }

            _previousGameState = _currentGameState;

            _currentGameState = gameState;

            stateText.text = gameState.ToString();

            _gameStateEntity = _gameStateFactory.CreateState(gameState);
            _gameStateEntity.Start();
        }


       


    }
}
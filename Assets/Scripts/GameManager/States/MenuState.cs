using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Collections;
using FSM.Helper;

namespace FSM.GameManager.States
{
    public class MenuState : GameStateEntity
    {
        [Inject(Id = "ui_menu")]
        GameObject canvas_assigned;

        public override void Initialize()
        {
            Debug.Log("Menu state initialized...");
        }

        public override void Start()
        {
            Debug.Log("Menu state started");
            canvas_assigned.SetActive(true);
        }

        public override void Tick()
        {
            // optionally overridden
        }

        public override void Dispose()
        {
            canvas_assigned.SetActive(false);
            Debug.Log("Menu state disposed");
        }

        public class Factory : Factory<MenuState>
        {
        }


       

    }
}
using UnityEngine;
using Zenject;

namespace FSM.GameManager.States
{
    public class ExitState : GameStateEntity
    {
        [Inject(Id = "ui_exit")]
        GameObject canvas_assigned;

        public override void Initialize()
        {
            Debug.Log("Exit state initialized...");
        }

        public override void Start()
        {
            Debug.Log("Exit state started");
            canvas_assigned.SetActive(true);
        }

        public override void Tick()
        {
            // optionally overridden
        }

        public override void Dispose()
        {
            canvas_assigned.SetActive(false);
            Debug.Log("Exit state disposed");
        }

        public class Factory : Factory<ExitState>
        {
        }




    }
}
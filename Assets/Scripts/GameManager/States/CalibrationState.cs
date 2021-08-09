using UnityEngine;
using Zenject;

namespace FSM.GameManager.States
{
    public class CalibrationState : GameStateEntity
    {
        [Inject(Id ="ui_calibration")]
        GameObject canvas_assigned;
        public override void Initialize()
        {
            Debug.Log("Calibration initialized...");
        }

        public override void Start()
        {
            Debug.Log("Calibration started...");
            canvas_assigned.SetActive(true);
        }

        public override void Tick()
        {
            // optionally overridden
        }

        public override void Dispose()
        {
            canvas_assigned.SetActive(false);
            Debug.Log("Calibration disposed...");
        }

        public class Factory : Factory<CalibrationState>
        {
        }
    }
}
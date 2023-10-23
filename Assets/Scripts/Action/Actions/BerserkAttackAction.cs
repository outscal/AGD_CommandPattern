using Command.Commands;
using Command.Input;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class BerserkAttackAction : IAction
    {
        private const float hitChance = 0.66f;
        private UnitController actorUnit;
        private UnitController targetUnit;
        public TargetType TargetType => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;

            actorUnit.PlayBattleAnimation(ActionType.BerserkAttack, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            if (IsSuccessful())
                targetUnit.TakeDamage(actorUnit.CurrentPower * 2);
            else
            {
                actorUnit.TakeDamage(actorUnit.CurrentPower * 2);
                Debug.Log("actor unit must be hit now.");
            }
        }

        public bool IsSuccessful() => Random.Range(0f, 1f) < hitChance;

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}
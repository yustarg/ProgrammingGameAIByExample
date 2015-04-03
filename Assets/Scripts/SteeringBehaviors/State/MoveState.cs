using UnityEngine;
using System.Collections;

namespace Steering
{
    public class MoveState<T> : GameEntityState<T> where T : Vehicle
    {

        public override void Enter(T entity)
        {

        }

        public override void Execute(T entity)
        {
            entity.Move();
        }

        public override void Exit(T entity)
        {

        }
    }
}

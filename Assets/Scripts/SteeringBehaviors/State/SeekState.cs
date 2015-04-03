using UnityEngine;
using System.Collections;

namespace Steering
{
    public class SeekState<T> : GameEntityState<T> where T : Vehicle
    {

        public override void Enter(T entity)
        {

        }

        public override void Execute(T entity)
        {
            entity.Move();
            entity.Seek(GameObject.Find("target"));
        }

        public override void Exit(T entity)
        {

        }
    }
}

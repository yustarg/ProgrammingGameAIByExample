using UnityEngine;
using System.Collections;

namespace Steering
{

    public abstract class GameEntityState<T> where T : BaseGameEntity
    {
        public abstract void Enter(T entity);
        public abstract void Execute(T entity);
        public abstract void Exit(T entity);
    }


}
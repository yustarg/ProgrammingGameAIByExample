using UnityEngine;
using System.Collections;

namespace WestWorld
{

    public abstract class State<T>
    {

        public abstract void Enter(T entity);
        public abstract void Excute(T entity);
        public abstract void Exit(T entity);
        public abstract bool OnMessage(T entity, Telegram msg);

    }
}
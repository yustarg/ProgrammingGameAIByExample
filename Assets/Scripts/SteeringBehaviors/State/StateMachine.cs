using UnityEngine;
using System.Collections;

namespace Steering
{
    public class StateMachine<T> where T : BaseGameEntity
    {
        private T m_Owner;
        private State<T> m_CurrentState;
        private State<T> m_GlobalState;
        private State<T> m_PreviousState;

        public State<T> CurrentState
        {
            set { m_CurrentState = value; }
        }
        public State<T> GlobalState
        {
            set { m_GlobalState = value; }
        }
        public State<T> PreviousState
        {
            set { m_PreviousState = value; }
        }

        public StateMachine(T owner)
        {
            m_Owner = owner;
            m_CurrentState = null;
            m_GlobalState = null;
            m_PreviousState = null;
        }

        public void Update()
        {
            if (m_GlobalState != null)
            {
                m_GlobalState.Excute(m_Owner);
            }

            if (m_CurrentState != null)
            {
                m_CurrentState.Excute(m_Owner);
            }
        }


        public void ChangeState(State<T> newState)
        {
            m_PreviousState = m_CurrentState;
            m_CurrentState.Exit(m_Owner);
            m_CurrentState = newState;
            m_CurrentState.Enter(m_Owner);
        }

        public void Revert2PreviousState()
        {
            ChangeState(m_PreviousState);
        }
    }
}

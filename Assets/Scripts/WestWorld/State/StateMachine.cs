using UnityEngine;
using System.Collections;

public class StateMachine<T> 
{
    private T m_pOwner;
    private State<T> m_pCurrentState;
    private State<T> m_pPreviousState;
    private State<T> m_pGlobalState;

    public State<T> CurrentState
    {
        set { m_pCurrentState = value; }
        get { return m_pCurrentState; }
    }

    public State<T> PreviousState
    {
        set { m_pPreviousState = value; }
        get { return m_pPreviousState; }
    }

    public State<T> GlobalState
    {
        set { m_pGlobalState = value; }
        get { return m_pGlobalState; }
    }

	public StateMachine(T owner)
    {
        m_pOwner = owner;
        m_pCurrentState = null;
        m_pPreviousState = null;
        m_pGlobalState = null;
    }

    public void Update()
    {
        if (m_pGlobalState != null)
        {
            m_pGlobalState.Excute(m_pOwner);
        }
        if (m_pCurrentState != null)
        {
            m_pCurrentState.Excute(m_pOwner);
        }
    }

    public bool HandleMessage(Telegram msg)
    {
        if (m_pCurrentState != null && m_pCurrentState.OnMessage(m_pOwner, msg))
        {
            return true;
        }
        if (m_pGlobalState != null && m_pGlobalState.OnMessage(m_pOwner, msg))
        {
            return true;
        }
        return false;
    }

    public void ChangeState(State<T> pNewState)
    {
        m_pPreviousState = m_pCurrentState;
        m_pCurrentState.Exit(m_pOwner);
        m_pCurrentState = pNewState;
        m_pCurrentState.Enter(m_pOwner);
    }

    public void RevertToPreviousState()
    {
        ChangeState(m_pPreviousState);
    }

    public bool IsInState(State<T> s)
    {
        return s.Equals(m_pCurrentState);
    }
}

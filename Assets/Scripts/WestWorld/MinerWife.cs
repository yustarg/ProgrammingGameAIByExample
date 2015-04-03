using UnityEngine;
using System.Collections;
using WestWorld;

public class MinerWife : BaseGameEntity {

    private StateMachine<MinerWife> m_pStateMachine;
    private LocationType m_location;
    private bool m_bCooking;

    public StateMachine<MinerWife> FSM
    {
        get { return m_pStateMachine; }
    }

    public LocationType Location
    {
        get { return m_location; }
        set { m_location = value; }
    }

    public bool IsCooking
    {
        get { return m_bCooking; }
        set { m_bCooking = value; }
    }

    public MinerWife(int id) : base(id) 
    {
        m_pStateMachine = new StateMachine<MinerWife>(this);
        m_pStateMachine.CurrentState = new DoHouseWork();
        m_pStateMachine.GlobalState = new WifeGlobalState();
        m_bCooking = false;
    }

    public override void Update()
    {
        m_pStateMachine.Update();
    }

    public override bool HandleMessage(Telegram msg)
    {
        return m_pStateMachine.HandleMessage(msg);
    }
}

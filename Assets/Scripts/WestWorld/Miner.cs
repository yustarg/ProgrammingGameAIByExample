using UnityEngine;
using System.Collections;

public class Miner : BaseGameEntity {

    //private State<Miner> m_pCurrentState;
    //private State<Miner> m_pPreviousState;
    //private State<Miner> m_pGlobalState;
    private StateMachine<Miner> m_pStateMachine;
    private LocationType m_location;
    private int m_iGoldCarried;
    private int m_iMoneyInBank;
    private int m_iThirst;
    private int m_iFatigue;


    public LocationType Location
    {
        get { return m_location; }
        set { m_location = value; }
    }

    public int GoldCarried
    {
        get { return m_iGoldCarried; }
        set { m_iGoldCarried = value; }
    }
    public int MoneyInBank
    {
        get { return m_iMoneyInBank; }
        set { m_iMoneyInBank = value; }
    }
    public int Thirst
    {
        get { return m_iThirst; }
        set { m_iThirst = value; }
    }
    public int Fatigue
    {
        get { return m_iFatigue; }
        set { m_iFatigue = value; }
    }

    public StateMachine<Miner> FSM
    {
        get { return m_pStateMachine; }
    }

    public Miner(int id) : base(id) 
    {
        m_iGoldCarried = 0;
        m_iMoneyInBank = 0;
        m_iThirst = 0;
        m_iFatigue = 0;
        m_pStateMachine = new StateMachine<Miner>(this);
        m_pStateMachine.CurrentState = new GoHomeAndSleepTilRested();
    }

    public void AddToGoldCarrier(int value)
    {
        m_iGoldCarried += value;
    }

    public void AddToWealth(int value)
    {
        m_iMoneyInBank += value;
    }

    public void IncreaseFatigue()
    {
        m_iFatigue++;
    }

    public bool IsPocketsFull()
    {
        return m_iGoldCarried >= 5;
    }

    public bool IsThirsty()
    {
        return m_iThirst >= 10;
    }

    public bool IsFatigue()
    {
        return m_iFatigue >= 5;
    }

    public void DecreaseFatigue()
    {
        m_iFatigue--;
        if (m_iFatigue < 0)
        {
            m_iFatigue = 0;
        }
    }
      
    public void BuyAndDrinkWiskey()
    {
        m_iThirst = 0;
    }

    //public void ChangeState(State<Miner> pNewState)
    //{
    //    m_pCurrentState.Exit(this);
    //    m_pCurrentState = pNewState;
    //    m_pCurrentState.Enter(this);
    //}

    public override void Update()
    {
        m_iThirst++;
        //if (m_pCurrentState != null)
        //{
        //    m_pCurrentState.Excute(this);
        //}
        m_pStateMachine.Update();
    }

    public override bool HandleMessage(Telegram msg)
    { 
        return m_pStateMachine.HandleMessage(msg);
    }
}

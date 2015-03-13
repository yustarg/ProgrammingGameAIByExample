using UnityEngine;
using System.Collections;

public class EnterMineAndDigForNugget : State<Miner>{



    public override void Enter(Miner miner)
    {
        if (miner.Location != LocationType.goldmine)
        {
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Walking to the goldmine");
            miner.Location = LocationType.goldmine;
        }
    }

    public override void Excute(Miner miner)
    {
        miner.AddToGoldCarrier(1);
        miner.IncreaseFatigue();
        Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Picking up a Nugget");
        if (miner.IsPocketsFull())
        {
            miner.FSM.ChangeState(new VisitBankAndDepositGold());
        }
        if (miner.IsThirsty())
        {
            miner.FSM.ChangeState(new QuenchThirst());
        }
    }

    public override void Exit(Miner miner)
    {
        Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Leaving the gold mine!!!");
    }

    public override bool OnMessage(Miner entity, Telegram tel)
    {
        return false;
    }
}

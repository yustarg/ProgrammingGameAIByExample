using UnityEngine;
using System.Collections;

public class EatStew : State<Miner> {


    public override void Enter(Miner miner)
    {
        Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Smells Reaaal goood Elsa!");
    }

    public override void Excute(Miner miner)
    {
        Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Tastes real good too!");
        miner.FSM.RevertToPreviousState();
    }

    public override void Exit(Miner miner)
    {
        Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Thankya li'lle lady. Ah better get back to whatever ah wuz doin'");
    }

    public override bool OnMessage(Miner miner, Telegram msg)
    {
        return false;
    }
}

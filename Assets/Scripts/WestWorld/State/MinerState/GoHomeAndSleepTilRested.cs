using UnityEngine;
using System.Collections;

public class GoHomeAndSleepTilRested : State<Miner>
{

    public override void Enter(Miner miner)
    {
        if (miner.Location != LocationType.shack)
        {
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Walkin' home");
            miner.Location = LocationType.shack;
            
            MessageDispatcher.Instance().DispatchMessage(0, //time delay
                                                         miner.GetID(),        //ID of sender
                                                         (int)EntityName.ent_Elsa,            //ID of recipient
                                                         WestWorldMessageType.Msg_HiHoneyImHome,   //the message
                                                         null);    
        }
    }

    public override void Excute(Miner miner)
    {
        if (!miner.IsFatigue())
        {
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": What a God darn fantastic nap! Time to find more gold");
            miner.FSM.ChangeState(new EnterMineAndDigForNugget());
        }
        else
        {
            miner.DecreaseFatigue();
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Zzzz...");
        }
    }

    public override void Exit(Miner miner)
    {
        Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Leaving the house");
    }

    public override bool OnMessage(Miner miner, Telegram msg)
    {
        switch(msg.msg)
        {
            case WestWorldMessageType.Msg_StewReady:
            Debug.Log("Message handled by " + Utility.GetNameOfEntity(miner.GetID()) + " at time: " + Utility.GetCurrentTime().ToString());
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Okay Hun, ahm a comin'!");
            miner.FSM.ChangeState(new EatStew());
            return true;
        }//end switch

        return false; //send message to global message handler
    }
}


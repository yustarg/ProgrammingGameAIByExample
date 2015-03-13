using UnityEngine;
using System.Collections;

public class QuenchThirst : State<Miner>
{

    public override void Enter(Miner miner)
    {
        if (miner.Location != LocationType.saloon)
        {
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Boy, ah sure is thusty! Walking to the saloon");
            miner.Location = LocationType.saloon;
        }
    }

    public override void Excute(Miner miner)
    {
        if (miner.IsThirsty())
        {
            miner.BuyAndDrinkWiskey();
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": That's mighty fine sippin liquer");
            miner.FSM.ChangeState(new EnterMineAndDigForNugget());
        }
        else
        {
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": \nERROR!\nERROR!\nERROR!");
        }
    }

    public override void Exit(Miner miner)
    {
        Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Leaving the saloon, feelin' good");
    }

    public override bool OnMessage(Miner entity, Telegram tel)
    {
        return false;
    }
}


using UnityEngine;
using System.Collections;

public class DoHouseWork : State<MinerWife> {


    public override void Enter(MinerWife wife)
    {
        
    }

    public override void Excute(MinerWife wife)
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Moppin' the floor");
                break;
            case 1:
                Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Washin' the dishes");
                break;
            case 2:
                Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Makin' the bed");
                break;
        }
    }

    public override void Exit(MinerWife wife)
    {
        
    }

    public override bool OnMessage(MinerWife entity, Telegram tel)
    {
        return false;
    }
}

using UnityEngine;
using System.Collections;

public class CookStew : State<MinerWife> {


    public override void Enter(MinerWife wife)
    {
        //if not already cooking put the stew in the oven
        if (!wife.IsCooking)
        {
            Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Putting the stew in the oven");
            //send a delayed message myself so that I know when to take the stew
            //out of the oven
            MessageDispatcher.Instance().DispatchMessage(1.5,                  //time delay
                                                         wife.GetID(),           //sender ID
                                                         wife.GetID(),           //receiver ID
                                                         WestWorldMessageType.Msg_StewReady,        //msg
                                                         null);
            wife.IsCooking = true;
        }
    }

    public override void Excute(MinerWife wife)
    {
        Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Fussin' over food");
    }

    public override void Exit(MinerWife wife)
    {
        Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Puttin' the stew on the table");
    }

    public override bool OnMessage(MinerWife wife, Telegram msg)
    {
        switch(msg.msg)
        {
            case WestWorldMessageType.Msg_StewReady:
            {
                Debug.Log("Message received by " + Utility.GetNameOfEntity(wife.GetID()) + " at time: " + Utility.GetCurrentTime().ToString());
                Debug.Log("Message received by " + Utility.GetNameOfEntity(wife.GetID()) + ": StewReady! Lets eat");
                //let hubby know the stew is ready
                MessageDispatcher.Instance().DispatchMessage(0,
                                                             wife.GetID(),
                                                             (int)EntityName.ent_Miner_Bob,
                                                             WestWorldMessageType.Msg_StewReady,
                                                             null);

                wife.IsCooking = false;

                wife.FSM.ChangeState(new DoHouseWork());               
            }
            return true;
        }//end switch
        return false;
    }
}

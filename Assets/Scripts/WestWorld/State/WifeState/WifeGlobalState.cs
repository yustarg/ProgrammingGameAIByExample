using UnityEngine;
using System.Collections;

namespace WestWorld
{

    public class WifeGlobalState : State<MinerWife>
    {


        public override void Enter(MinerWife wife)
        {

        }

        public override void Excute(MinerWife wife)
        {
            if (Random.Range(1, 10) < 2)
            {
                wife.FSM.ChangeState(new VisitBathroom());
            }
        }

        public override void Exit(MinerWife wife)
        {

        }

        public override bool OnMessage(MinerWife wife, Telegram msg)
        {
            switch (msg.msg)
            {
                case WestWorldMessageType.Msg_HiHoneyImHome:
                    {
                        Debug.Log("\nMessage handled by " + Utility.GetNameOfEntity(wife.GetID()) + " at time: " + Utility.GetCurrentTime().ToString());
                        Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + " : Hi honey. Let me make you some of mah fine country stew");

                        wife.FSM.ChangeState(new CookStew());
                    }
                    return true;
            }//end switch
            return false;
        }
    }
}
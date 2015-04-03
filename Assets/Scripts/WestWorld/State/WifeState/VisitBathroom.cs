using UnityEngine;
using System.Collections;

namespace WestWorld
{

    public class VisitBathroom : State<MinerWife>
    {


        public override void Enter(MinerWife wife)
        {
            Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public override void Excute(MinerWife wife)
        {
            Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Ahhhhhh! Sweet relief!");
            wife.FSM.RevertToPreviousState();
        }

        public override void Exit(MinerWife wife)
        {
            Debug.Log(Utility.GetNameOfEntity(wife.GetID()) + ": Leavin' the Jon");
        }

        public override bool OnMessage(MinerWife entity, Telegram tel)
        {
            return false;
        }
    }
}
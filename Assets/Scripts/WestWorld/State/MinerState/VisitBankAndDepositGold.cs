using UnityEngine;
using System.Collections;

namespace WestWorld
{

    public class VisitBankAndDepositGold : State<Miner>
    {
        private const int MoneyInBankThreshold = 5;

        public override void Enter(Miner miner)
        {
            if (miner.Location != LocationType.bank)
            {
                Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Goin' to the bank. Yes siree");
                miner.Location = LocationType.bank;
            }
        }

        public override void Excute(Miner miner)
        {
            miner.AddToWealth(miner.GoldCarried);
            miner.GoldCarried = 0;
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": Depositing gold. Total savings now: " + miner.MoneyInBank);
            if (miner.MoneyInBank >= MoneyInBankThreshold)
            {
                Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + ": WooHoo! Rich enough for now. Back home to mah li'lle lady ");
                miner.FSM.ChangeState(new GoHomeAndSleepTilRested());
            }
            else
            {
                miner.FSM.ChangeState(new EnterMineAndDigForNugget());
            }
        }

        public override void Exit(Miner miner)
        {
            Debug.Log(Utility.GetNameOfEntity(miner.GetID()) + "Leavin' the bank ");
        }

        public override bool OnMessage(Miner entity, Telegram tel)
        {
            return false;
        }
    }
}
using UnityEngine;
using System.Collections;

namespace WestWorld
{
    public class MinerManager : MonoBehaviour
    {

        private Miner m_pMiner;
        private MinerWife m_pMinerWife;

        // Use this for initialization
        void Start()
        {
            m_pMiner = new Miner((int)EntityName.ent_Miner_Bob);
            m_pMinerWife = new MinerWife((int)EntityName.ent_Elsa);
            EntityManager.Instance().RegisterEntity(m_pMiner);
            EntityManager.Instance().RegisterEntity(m_pMinerWife);
            StartCoroutine(UpdateMiner());
        }

        private IEnumerator UpdateMiner()
        {
            while (true)
            {
                m_pMiner.Update();
                m_pMinerWife.Update();
                MessageDispatcher.Instance().DispatchDelayMessage();
                yield return new WaitForSeconds(3f);
            }
        }
    }
}

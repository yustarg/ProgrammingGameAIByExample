using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MessageDispatcher  {

    private static MessageDispatcher m_instance;
    public static MessageDispatcher Instance()
    {
        if (m_instance == null)
        {
            m_instance = new MessageDispatcher();
        }
        return m_instance;
    }
    
    private Queue<Telegram> priorityQ = new Queue<Telegram>();

    public void DispatchMessage(double delay, int sender, int receiver, WestWorldMessageType msg, object extraInfo)
    {
        BaseGameEntity senderEntity = EntityManager.Instance().GetEntityFromID(sender);
        BaseGameEntity receiverEntity = EntityManager.Instance().GetEntityFromID(receiver);

        Telegram tel = new Telegram(DateTime.MinValue, sender, receiver, msg, extraInfo);
        
        if (delay <= 0.0f)
        {   
            Debug.Log("Instant telegram dispatched at time " + Utility.GetCurrentTime().ToString()
                        + " by " + Utility.GetNameOfEntity(senderEntity.GetID()) + " for " + Utility.GetNameOfEntity(receiverEntity.GetID()));
            //send the telegram to the recipient
            Discharge(receiverEntity, tel);
        }
        else
        {
            DateTime CurrentTime = Utility.GetCurrentTime();

            tel.dispatchTime = CurrentTime.AddSeconds(delay);

            ////and put it in the queue
            priorityQ.Enqueue(tel);

            //cout << "\nDelayed telegram from " << GetNameOfEntity(pSender->ID()) << " recorded at time "
            //        << Clock->GetCurrentTime() << " for " << GetNameOfEntity(pReceiver->ID())
            //        << ". Msg is " << MsgToStr(msg);
            Debug.Log("Delayed telegram from " + Utility.GetNameOfEntity(senderEntity.GetID()) + " for " + Utility.GetNameOfEntity(receiverEntity.GetID()));

        }
    }

    public void DispatchDelayMessage()
    { 
        DateTime CurrentTime = Utility.GetCurrentTime();
        //now peek at the queue to see if any telegrams need dispatching.
        //remove all telegrams from the front of the queue that have gone
        //past their sell by date
        while( priorityQ.Count > 0// &&
              /*(priorityQ.Peek().dispatchTime < CurrentTime) && 
              (priorityQ.Peek().dispatchTime > DateTime.MinValue)*/ )
        {
            //read the telegram from the front of the queue
            Telegram telegram = priorityQ.Dequeue();

            //find the recipient
            BaseGameEntity receiver = EntityManager.Instance().GetEntityFromID(telegram.receiver);

            Debug.Log("Queued telegram ready for dispatch: Sent to " + Utility.GetNameOfEntity(receiver.GetID()));

            //send the telegram to the recipient
            Discharge(receiver, telegram);
        }
    }

    private void Discharge(BaseGameEntity receiver, Telegram msg)
    {
        if (!receiver.HandleMessage(msg))
        {
            Debug.Log("Msg not handled!!");
        }
    }
}

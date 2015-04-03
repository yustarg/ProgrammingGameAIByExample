using System.Collections;
using System;

namespace WestWorld
{
    public class Telegram
    {

        public int sender;
        public int receiver;
        public WestWorldMessageType msg;
        public DateTime dispatchTime;
        public object extraInfo;

        public Telegram()
        {
            this.sender = -1;
            this.receiver = -1;
            this.msg = WestWorldMessageType.Msg_Null;
            this.dispatchTime = DateTime.MinValue;
            this.extraInfo = null;
        }

        public Telegram(DateTime dispatchTime, int sender, int receiver, WestWorldMessageType msg, object extraInfo)
        {
            this.dispatchTime = dispatchTime;
            this.sender = sender;
            this.receiver = receiver;
            this.msg = msg;
            this.extraInfo = extraInfo;
        }
    }
}

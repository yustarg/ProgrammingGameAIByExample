using System;
using UnityEngine;

namespace WestWorld
{

    public enum LocationType
    {
        shack,
        goldmine,
        bank,
        saloon
    }

    public enum EntityName
    {
        ent_Miner_Bob,
        ent_Elsa
    }

    public enum WestWorldMessageType
    {
        Msg_Null = -1,
        Msg_HiHoneyImHome = 1,
        Msg_StewReady
    }

    public class Utility
    {
        public static string GetNameOfEntity(int n)
        {
            switch (n)
            {
                case (int)EntityName.ent_Miner_Bob:
                    return "Miner Bob";
                case (int)EntityName.ent_Elsa:
                    return "Elsa";
                default:
                    return "UNKNOWN!";
            }
        }

        public static DateTime GetCurrentTime()
        {
            return DateTime.Now.Date;
        }
    }
}
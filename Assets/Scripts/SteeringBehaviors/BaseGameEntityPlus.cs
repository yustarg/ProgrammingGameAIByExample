using UnityEngine;
using System.Collections;

public abstract class BaseGameEntityPlus : MonoBehaviour{

    private int m_ID;
    private static int m_iNextValidID;
    private bool m_bTag;
    private int m_iEntityType;

    //the length of this object's bounding radius
    protected double m_dBoundingRadius;
    protected Transform m_tTrans;

    public double BoundingRadius
    {
        set { m_dBoundingRadius = value; }
        get { return m_dBoundingRadius; }
    }

    public int EntityType
    {
        set { m_iEntityType = value; }
        get { return m_iEntityType; }
    }

    public int ID
    {
        set 
        {
            this.m_ID = value;
            m_iNextValidID = value + 1;
        }
        get { return m_ID; }
    }

    public bool Tag
    {
        set { m_bTag = value; }
        get { return m_bTag; }
    }
    //public BaseGameEntityPlus(int id)
    //{
    //    SetID(id);
    //}
    private void Awake()
    {
        this.OnAwake();
    }

    public virtual void OnAwake() { this.m_tTrans = transform; }
    public virtual void OnUpdate() { }
    public virtual bool HandleMessage(Telegram msg) { return false; }

}
                                                                             
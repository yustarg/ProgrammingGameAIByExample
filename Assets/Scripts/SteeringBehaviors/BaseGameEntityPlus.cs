using UnityEngine;
using System.Collections;

public abstract class BaseGameEntityPlus : MonoBehaviour
{

    private int m_iID;
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
            this.m_iID = value;
            m_iNextValidID = value + 1;
        }
        get { return m_iID; }
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
        OnAwake();
    }

    private void Update()
    {
        OnUpdate();
    }

    protected virtual void OnAwake() { this.m_tTrans = transform; }
    protected virtual void OnUpdate() { }
    protected virtual bool HandleMessage(Telegram msg) { return false; }

}
                                                                             
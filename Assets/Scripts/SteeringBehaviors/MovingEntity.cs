using UnityEngine;
using System.Collections;

public abstract class MovingEntity : BaseGameEntityPlus {

    protected Vector2 m_vVelocity;
    protected Vector2 m_vSide;
    public float m_dMass;
    public float m_dMaxSpeed;
    public float m_dMaxForce;
    public float m_dMaxTurnRate;

    public float MaxSpeed
    {
        get { return m_dMaxSpeed; }
        set { m_dMaxSpeed = value; }
    }

    public Vector2 Velocity
    {
        get { return m_vVelocity; }
        set { m_vVelocity = value; }
    }
}

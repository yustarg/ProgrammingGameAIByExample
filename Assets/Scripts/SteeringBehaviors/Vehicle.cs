﻿using UnityEngine;
using System.Collections;

public class Vehicle : MovingEntity {

    private GameWorld m_pWorld;
    private SteeringBehavior m_pSteering;

    public GameWorld World
    {
        get { return m_pWorld; }
    }

    public SteeringBehavior Steering
    {
        get { return m_pSteering; }
    }

    public Vector2 Pos()
    {
        return new Vector2(m_tTrans.position.x, m_tTrans.position.y);
    }

    public void SetVehicle(GameWorld world,
                           Vector2 velocity,
                           float mass,
                           float max_force,
                           float max_speed,
                           float max_turn_rate)
    {
        this.m_pWorld = world;
        this.m_vVelocity = velocity;
        this.m_dMass = mass;
        this.m_dMaxForce = max_force;
        this.m_dMaxSpeed = max_speed;
        this.m_dMaxTurnRate = max_turn_rate;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector2 steeringForce = m_pSteering.Calculate();
        Vector2 accelaration = steeringForce / m_dMass;
        this.m_vVelocity += accelaration * Time.deltaTime;
        this.m_vVelocity = AIMath.Truncate(this.m_vVelocity, m_dMaxSpeed);
        Vector3 newPos = new Vector3(m_vVelocity.x * Time.deltaTime, m_vVelocity.y * Time.deltaTime, 0);
        m_tTrans.position += newPos;
        if (m_vVelocity.magnitude > 0.00001f)
        {
            Vector3 lookPos = new Vector3(m_vVelocity.x, m_vVelocity.y, 0);
            m_tTrans.LookAt(lookPos);
            m_vSide = AIMath.Perp(m_tTrans.forward);
        }
    }

    public override bool HandleMessage(Telegram msg)
    {
        return base.HandleMessage(msg);
    }
}
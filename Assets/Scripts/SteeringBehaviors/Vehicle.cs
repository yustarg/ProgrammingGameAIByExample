using UnityEngine;
using System.Collections;
using Steering;

public enum VehicleType { Audi, Farrari, Benz }

public class Vehicle : MovingEntity {

    private GameWorld m_World;
    private SteeringBehavior m_Steering;

    public GameWorld World
    {
        get { return m_World; }
    }

    public SteeringBehavior Steering
    {
        get { return m_Steering; }
    }

    public Vector2 GetPosition()
    {
        return new Vector2(m_Trans.position.x, m_Trans.position.z);
    }

    public static Vehicle CreateVehicle(VehicleType type)
    {
        Vehicle vihicle = null;
        switch (type)
        { 
            case VehicleType.Audi:
            case VehicleType.Benz:
            case VehicleType.Farrari:
                vihicle = new Vehicle(1, new Vector2(5, 5), 2, 5, 5, 5, "Assets/StreamingAssets/Prefabs/Vehicle.prefab");
                break;
        }
        return vihicle;
    }

    private Vehicle(int id,
                    Vector2 velocity,
                    float mass,
                    float max_force,
                    float max_speed,
                    float max_turn_rate,
                    string resPath)
        : base(id, resPath)
    {
        m_vVelocity = velocity;
        m_dMass = mass;
        m_dMaxForce = max_force;
        m_dMaxSpeed = max_speed;
        m_dMaxTurnRate = max_turn_rate;
        m_Steering = new SteeringBehavior(this);
        m_GameObject = LoadGameObject();
        m_Trans = m_GameObject.transform;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector2 steeringForce = m_Steering.Calculate();
        Vector2 accelaration = steeringForce / m_dMass;
        this.m_vVelocity += accelaration * Time.deltaTime;
        this.m_vVelocity = AIMath.Truncate(m_vVelocity, m_dMaxSpeed);
        Vector3 newPos = new Vector3(m_vVelocity.x * Time.deltaTime, 0, m_vVelocity.y * Time.deltaTime);
        m_Trans.position += newPos;
        if (m_vVelocity.magnitude > 0.00001f)
        {
            m_vSide = AIMath.Perp(m_Trans.forward);
        }
        WrapAround();
    }
    private void WrapAround()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(m_Trans.position);
        if (screenPoint.x > Screen.width)
        {
            m_Trans.position -= new Vector3(10, 0, 0);
        }
        if (screenPoint.x < 0)
        {
            m_Trans.position += new Vector3(10, 0, 0);
        }
        if (screenPoint.y < 0)
        {
            m_Trans.position += new Vector3(0, 0, 10);
        }
        if (screenPoint.y > Screen.height)
        {
            m_Trans.position -= new Vector3(0, 0, 10);
        }
    }
   


    public override bool HandleMessage(Telegram msg)
    {
        return base.HandleMessage(msg);
    }

    public void Seek(Vector2 target)
    {
        m_Steering.Seek(target);
    }
}

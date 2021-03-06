﻿using UnityEngine;
using System.Collections;
using Steering;

namespace Steering
{
    public enum VehicleType { Audi, Farrari, Benz }

    public class Vehicle : MovingEntity
    {

        private GameWorld m_World;
        private SteeringBehavior m_Steering;
        private StateMachine<Vehicle> m_StateMachine;

        private VehicleType type;

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

        public StateMachine<Vehicle> StateMachine
        {
            get { return m_StateMachine; }
        }

        public static Vehicle CreateVehicle(VehicleType type)
        {
            Vehicle vihicle = null;
            switch (type)
            {
                case VehicleType.Audi:
                    vihicle = new Vehicle(1, new Vector2(1, 1), 1, 1, 1, 1, "Assets/StreamingAssets/Prefabs/Vehicle.prefab");
                    vihicle.StateMachine.CurrentState = new MoveState<Vehicle>();
                    break;
                case VehicleType.Benz:
                case VehicleType.Farrari:
                    vihicle = new Vehicle(1, new Vector2(3, 3), 3, 3, 3, 3, "Assets/StreamingAssets/Prefabs/Vehicle.prefab");
                    vihicle.StateMachine.CurrentState = new MoveState<Vehicle>();
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
            m_StateMachine = new StateMachine<Vehicle>(this);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            CalculateVelocity();
            m_Steering.Move();
            //Arrive(GameObject.Find("target"));
            //if (m_vVelocity.magnitude > 0.00001f)
            //{
            //    m_vSide = AIMath.Perp(m_Trans.forward);
            //}
            m_Trans.LookAt(m_Trans.forward);
            WrapAround();
            //m_StateMachine.Update();
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

        public void CalculateVelocity()
        {
            Vector2 steeringForce = m_Steering.Calculate();
            Vector2 accelaration = steeringForce / m_dMass;
            this.m_vVelocity += accelaration * Time.deltaTime;
            this.m_vVelocity = AIMath.Truncate(m_vVelocity, m_dMaxSpeed);
        }

        public void Seek(GameObject target)
        {
            Vector2 targetPos;
            if (target)
            {
                targetPos = new Vector2(target.transform.position.x, target.transform.position.z);
            }
            else
            {
                targetPos = Vector2.zero;
            }
            m_vVelocity += m_Steering.Seek(targetPos);
        }

        public void Arrive(GameObject target)
        {
            Vector2 targetPos;
            if (target)
            {
                targetPos = new Vector2(target.transform.position.x, target.transform.position.z);
            }
            else
            {
                targetPos = Vector2.zero;
            }
            m_vVelocity += m_Steering.Arrive(targetPos, DecelerationType.Normal);
        }
    }
}
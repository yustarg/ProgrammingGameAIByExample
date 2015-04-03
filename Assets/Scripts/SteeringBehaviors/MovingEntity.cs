using UnityEngine;
using System.Collections;

namespace Steering
{
    public abstract class MovingEntity : BaseGameEntity
    {

        protected Vector2 m_vVelocity;
        protected Vector2 m_vSide;

        protected float m_dMass;
        protected float m_dMaxSpeed;
        protected float m_dMaxForce;
        protected float m_dMaxTurnRate;

        public MovingEntity(int id, string resPath)
            : base(id, resPath)
        {

        }


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
}
using UnityEngine;
using System.Collections;

namespace Steering
{

    public enum DecelerationType { Slow, Normal, Fast }
    public class SteeringBehavior
    {
        private Vehicle m_Vehicle;

        //the steering force created by the combined effect of all
        //the selected behaviors
        private Vector2 m_SteeringForce;

        //these can be used to keep track of friends, pursuers, or prey
        private Vehicle m_TargetAgent1;
        private Vehicle m_TargetAgent2;

        //the current target
        private Vector2 m_Target;

        //length of the 'detection box' utilized in obstacle avoidance
        double m_DBoxLength;

        public SteeringBehavior(Vehicle vehicle)
        {
            m_Vehicle = vehicle;
        }

        public Vector2 Calculate()
        {
            return Vector2.zero;
        }

        public void Move()
        {
            float random = Random.Range(0f, 1.5f);
            Vector2 v = new Vector2(-random, random);
            m_Vehicle.Velocity = v;
            Vector3 newPos = new Vector3(m_Vehicle.Velocity.x * Time.deltaTime, 0, m_Vehicle.Velocity.y * Time.deltaTime);
            m_Vehicle.Transform.position += newPos;
        }

        //this behavior moves the agent towards a target position
        public Vector2 Seek(Vector2 targetPos)
        {
            Vector2 desiredVelocity = (targetPos - m_Vehicle.GetPosition()).normalized * m_Vehicle.MaxSpeed;
            return (desiredVelocity - m_Vehicle.Velocity);
        }

        public Vector2 Flee(Vector2 targetPos)
        {
            Vector2 desiredVelocity = (m_Vehicle.GetPosition() - targetPos).normalized * m_Vehicle.MaxSpeed;
            return (desiredVelocity - m_Vehicle.Velocity);
        }

        public Vector2 Arrive(Vector2 targetPos, DecelerationType type)
        {
            Vector2 toTarget = targetPos - m_Vehicle.GetPosition();
            float dist = toTarget.magnitude;
            if (dist > 0)
            {
                const float decelerationTweaker = 0.3f;
                float speed = dist / (float)type * decelerationTweaker;
                speed = Mathf.Min(speed, m_Vehicle.MaxSpeed);

                Vector2 desiredVelocity = toTarget * speed / dist;
                return desiredVelocity - m_Vehicle.Velocity;
            }
            return Vector2.zero;
        }

        public Vector2 Pursuit(Vehicle evader)
        {
            Vector2 toEvader = evader.GetPosition() - m_Vehicle.GetPosition();
            Vector2 evaderHeading = new Vector2(evader.GameObject.transform.forward.x, evader.GameObject.transform.forward.z);
            Vector2 selfHeading = new Vector2(m_Vehicle.GameObject.transform.forward.x, m_Vehicle.GameObject.transform.forward.z);
            float ralativeHeading = Vector2.Dot(selfHeading, evaderHeading);
            if (ralativeHeading < 0.95 && Vector2.Dot(toEvader, selfHeading) > 0)
            {
                return Seek(evader.GetPosition());
            }
            float lookAheadTime = toEvader.magnitude / (m_Vehicle.MaxSpeed + evader.Velocity.magnitude);
            return Seek(evader.GetPosition() + evader.Velocity * lookAheadTime);
        }
    }
}
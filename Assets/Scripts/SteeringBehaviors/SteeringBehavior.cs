using UnityEngine;
using System.Collections;

public class SteeringBehavior
{
    private Vehicle m_pVehicle;

    //the steering force created by the combined effect of all
    //the selected behaviors
    private Vector2 m_vSteeringForce;

    //these can be used to keep track of friends, pursuers, or prey
    private Vehicle m_pTargetAgent1;
    private Vehicle m_pTargetAgent2;

    //the current target
    private Vector2 m_vTarget;

    //length of the 'detection box' utilized in obstacle avoidance
    double m_dDBoxLength;

    public SteeringBehavior(Vehicle vehicle)
    {
        m_pVehicle = vehicle;
    }

    public Vector2 Calculate()
    {
        return Vector2.zero;
    }

    //this behavior moves the agent towards a target position
    public Vector2 Seek(Vector2 targetPos)
    {
        Vector2 desiredVelocity = (targetPos - m_pVehicle.GetPosition()).normalized * m_pVehicle.MaxSpeed;
        return (desiredVelocity - m_pVehicle.Velocity);
    }
}

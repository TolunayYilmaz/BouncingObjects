using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rbObject;
    public int targetMinForce = 14;
    public int targetMaxForce = 18;
    public float targetTorqueValue = 10;
    public int targetPositionValue = 4;
    void Start()
    {

        #region  Allows targets to be thrown at random position with random force.

        rbObject = GetComponent<Rigidbody>();
        rbObject.AddForce(targetForce(), ForceMode.Impulse);
        rbObject.AddTorque(targetTorque(), ForceMode.Impulse);
        transform.position = targetPosition();
        #endregion
    }
    Vector3 targetForce()
    {
        return Vector3.up * Random.Range(targetMinForce, targetMaxForce);
    }
    Vector3 targetTorque()
    {
        return new Vector3(Random.Range(-targetTorqueValue, targetTorqueValue), Random.Range(-targetTorqueValue, targetTorqueValue), Random.Range(-targetTorqueValue, targetTorqueValue));
    }
    Vector3 targetPosition()
    {
        return new Vector3(Random.Range(-targetPositionValue, targetPositionValue), -6);
    }

}

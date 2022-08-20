using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rbObject;
    public int targetMinForce = 10;
    public int targetMaxForce = 14;
    public float targetTorqueValue = 10;
    public int targetPositionValue = 4;
    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;
    void Start()
    {

        #region  Allows targets to be thrown at random position with random force.

        rbObject = GetComponent<Rigidbody>();
        rbObject.AddForce(targetForce(), ForceMode.Impulse);
        rbObject.AddTorque(targetTorque(), ForceMode.Impulse);
        transform.position = targetPosition();
        #endregion
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    Vector3 targetForce()
    {
        return Vector3.up * Random.Range(targetMinForce, targetMaxForce);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    Vector3 targetTorque()
    {
        return new Vector3(Random.Range(-targetTorqueValue, targetTorqueValue), Random.Range(-targetTorqueValue, targetTorqueValue), Random.Range(-targetTorqueValue, targetTorqueValue));
    }
    Vector3 targetPosition()
    {
        return new Vector3(Random.Range(-targetPositionValue, targetPositionValue), -2);
    }

}

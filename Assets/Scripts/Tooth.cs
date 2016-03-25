using UnityEngine;
using System.Collections;

public class Tooth : MonoBehaviour {

    public InfectTeeth skull;
    public GameControl gameControl;

    private float _elapsedTime = 0.0f;

    void Update()
    {
        DamageSkull();
    }

    public void OnCollisionEnter(Collision collision)
    {        
        GameObject otherGO = collision.collider.gameObject;
        if(otherGO.tag == "Sweets")
        {
            Debug.Log("Hit");
            Rigidbody rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;

            Rigidbody otherGORigidBody = otherGO.GetComponent<Rigidbody>();
            rigidBody.velocity = otherGORigidBody.velocity;
            rigidBody.angularVelocity = otherGORigidBody.angularVelocity;

            Destroy(otherGORigidBody);

            if (this.GetComponent<Infection>() != null)
            {
                Infection infection = this.GetComponent<Infection>();
                if (infection._isFullyInfected == false)
                {
                    gameControl.DecreaseHealth();
                }                                 
            }
            else
            {
                gameControl.DecreaseHealth();
            }

            Destroy(otherGO);
            skull.RemoveTooth(this.gameObject);
        }
    }

    void DamageSkull()
    {
        if (this.GetComponent<Infection>() != null)
        {
            Infection infection = this.GetComponent<Infection>();
            if (infection._isFullyInfected)
            {
                _elapsedTime += Time.deltaTime;
                
                if (_elapsedTime >= 10.0f)
                {
                    gameControl.DecreaseHealth();
                    _elapsedTime = 0.0f;
                } 
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    private Collider agentCollider;

    public Collider AgentCollider
    {
        get { return agentCollider; }
    }
 
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }
    
    public void Update(Vector3 velocity)
    {
        var _transform = transform;
        _transform.forward = velocity;
        _transform.position += velocity * Time.deltaTime;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using GEL.Flock;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlockSystem : MonoBehaviour
{
    public FlockAgent agentPrefab;

    private List<FlockAgent> _agents = new List<FlockAgent>();

    public FlockBehavior behavior;

    [Range(10, 200)] public int agentCount = 50;

    private const float AgentDensity = 0.08f;
    [Range(1f, 100f)] public float driveFactor = 50f;
    [Range(1f, 10f)] public float maxSpeed = 5f;
    [Range(1f, 5f)] public float neighborRadius = 3f;
    [Range(0f, 1f)] public float avoidanceFactor = 0.5f;

    private float squareMaxSpeed;
    private float squareNeighborRadius;
    private float squareAvoidanceRadius;

    public float SquareAvoidanceRadius
    {
        get { return squareAvoidanceRadius; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = Mathf.Pow(maxSpeed, 2);
        squareNeighborRadius = Mathf.Pow(neighborRadius, 2);
        squareAvoidanceRadius = Mathf.Pow(neighborRadius*avoidanceFactor, 2);

        for (int i = 0; i < agentCount; i++)
        {
            FlockAgent agent = Instantiate(agentPrefab, Random.insideUnitSphere * agentCount * AgentDensity,
                Quaternion.Euler((Vector3.one) * Random.Range(0f, 360f)),
                transform);
            agent.name = "Agent "+ i.ToString();
            _agents.Add(agent);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var agent in _agents)
        {
            List<Transform> context = GetNeighborObjects(agent);
            Vector3 move = behavior.CalculateVelocity(agent, context, this);
        }
    }

    List<Transform> GetNeighborObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        foreach (var contextCollider in contextColliders)
        {
            if (contextCollider != agent.AgentCollider)
            {
                context.Add(contextCollider.transform);
            }
        }
        return context;
    }
}

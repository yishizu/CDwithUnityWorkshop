using System.Collections;
using System.Collections.Generic;
using GEL.Boids;
using UnityEngine;

namespace GEL.Designer
{
    public class BoidsBuilder : MonoBehaviour
    {
        public Vector3 center = Vector3.zero;
        public float boundsSize = 30f;
        public GameObject agentPrefab;

        private List<GameObject> agentObjects = new List<GameObject>();
        

        public BoidsSystem boidsSystem;
        // Start is called before the first frame update
        void Start()
        {
            boidsSystem = new BoidsSystem(100);
            Debug.Log(boidsSystem.agents.Count);
            CreateAgentObjects();
        }
        
        

        // Update is called once per frame
        void Update()
        {
            foreach (var boidAgent in boidsSystem.agents)
            {
                boidAgent.Update();
            }
        }

        public void CreateAgentObjects()
        {
            foreach (var boidAgent in boidsSystem.agents)
            {
                Vector3 pos = boidAgent.position;
                Vector3 vel = boidAgent.velocity;

                Quaternion rot = Quaternion.LookRotation(vel);
                GameObject agentObj = Instantiate(agentPrefab, pos, rot, this.transform);
                agentObjects.Add(agentObj);
            }
        }
    }
}


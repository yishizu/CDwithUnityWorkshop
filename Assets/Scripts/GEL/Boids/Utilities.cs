using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GEL.Boids
{
    public class Utilities
    {
        public static Vector3 GetRandomPosition(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
        {
            return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        }
        
        public static Vector3 GetRandomPosition(Bounds bounds)
        {
            return new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
        }

        public static Vector3 GetRandomVelocityXZ()
        {
            float angle = Random.Range(0, 2 * Mathf.PI);
            return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));

        }

        public static Vector3 GetRandomVelocity()
        {
            float theta = Random.Range(0, 2 * Mathf.PI);
            float phi = Random.Range(0, Mathf.PI);

            return new Vector3(Mathf.Sin(phi) * Mathf.Cos(theta), Mathf.Cos(phi), Mathf.Cos(phi) * Mathf.Cos(theta));
        }

        
    }
}




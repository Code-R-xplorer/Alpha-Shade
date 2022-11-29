using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Utilities
{
    public class Utils : MonoBehaviour
    {
        /// <summary>
        /// Generates positions on a nav mesh within a radius around the origin
        /// </summary>
        /// <param name="origin">The center of sphere</param>
        /// <param name="searchPoints">Amount of positions to generate</param>
        /// <param name="searchRadius">How large an area to generate points</param>
        /// <returns>Vector3 list of points on the nav mesh</returns>
        public static List<Vector3> GenerateSearchPoints(Vector3 origin, int searchPoints, int searchRadius) // Generates a list of positions based on an area for the guard to travel to
        {
            List<Vector3> searchPositions = new List<Vector3>();
            for (int i = 0; i < searchPoints; i++)
            {
                Vector3 newPos = RandomNavSphere(origin, searchRadius, -1);
                searchPositions.Add(newPos);
            }

            return searchPositions;
        }
        
        public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) 
        {
            /*************************************************************************************************
            *    Title: Random "Wander" AI using NavMesh
            *    Author: MysterySoftware
            *    Date: 2015
            *    Code version: 1.0
            *    Availability: https://forum.unity.com/threads/solved-random-wander-ai-using-navmesh.327950/
            **************************************************************************************************/

            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        
            randomDirection += origin;

            NavMesh.SamplePosition (randomDirection, out var navHit, distance, layermask);
        
            return navHit.position;
        }
    }
}
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
                if(newPos != Vector3.zero) searchPositions.Add(newPos);
            }

            return searchPositions;
        }

        private static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) 
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

            if (NavMesh.SamplePosition(randomDirection, out var navHit, distance, layermask))
            {
                return navHit.position;
            }

            return Vector3.zero;

        }
        
        /*************************************************************************************************
            *    Title: NavMeshPath.corners
            *    Author: Unity Technologies
            *    Date: 2022
            *    Code version: 1.0
            *    Availability: https://docs.unity3d.com/ScriptReference/AI.NavMeshPath-corners.html
            **************************************************************************************************/
        public static float CalculatePathLength(NavMeshPath path) {
            if (path.corners.Length < 2)
                return 0;
        
            float lengthSoFar = 0.0F;
            for (int i = 1; i < path.corners.Length; i++) {
                lengthSoFar += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
            return lengthSoFar;
        }
        
        public static T Clone<T>(T scriptableObject) where T : ScriptableObject
        {
            /*************************************************************************************************
            *    Title: Create copy of Scriptableobject (during runtime)
            *    Author: IainCarr
            *    Date: 2021
            *    Code version: 1.0
            *    Availability: https://forum.unity.com/threads/create-copy-of-scriptableobject-during-runtime.355933/
            **************************************************************************************************/
            
            if (scriptableObject == null)
            {
                Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object.");
                return (T)ScriptableObject.CreateInstance(typeof(T));
            }
 
            T instance = Object.Instantiate(scriptableObject);
            instance.name = scriptableObject.name; // remove (Clone) from name
            return instance;
        }
    }
    
    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) {}

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}

public static class ExtensionMethods {
     
    public static float Map (this float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
       
}
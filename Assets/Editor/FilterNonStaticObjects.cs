using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class FilterNonStaticObjects : EditorWindow
    {
        [MenuItem( "Custom/Select Non-Static" )]
        static void Init()
        {
            Object[] gameObjects = FindObjectsOfType( typeof ( GameObject ) );
            Object[] gameObjectArray = new Object[ gameObjects.Length ];
            int arrayPointer = 0;
            foreach ( var o in gameObjects )
            {
                var gameObject = (GameObject) o;
                if(!gameObject.activeSelf) continue;
                StaticEditorFlags flags = GameObjectUtility.GetStaticEditorFlags( gameObject );
                if ( ( flags & StaticEditorFlags.ContributeGI ) == 0 )
                {
                    gameObjectArray[ arrayPointer ] = gameObject;
                    arrayPointer += 1;
                }
            }
            Selection.objects = gameObjectArray;
        }
    }
}
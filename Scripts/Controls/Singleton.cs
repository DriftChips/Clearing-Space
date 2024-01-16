using UnityEngine;

public class SingletonTemplate<T> : MonoBehaviour where T : Component
{
    private static T _singleton;

    public static T Singleton
    {
        get 
        {
            if (_singleton == null)
            {
                var objs = FindObjectsOfType(typeof(T)) as T[];
                if (objs.Length > 0)
                {
                    _singleton = objs[0];
                }
                if (objs.Length > 1)
                {
                    Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                }
                if (_singleton == null)
                {
                    Debug.Log("Singleton " + typeof(T).FullName + " doesn't exist, creating it.");
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _singleton = obj.AddComponent<T>();
                }
            }
            return _singleton;
        }
        
    }
}

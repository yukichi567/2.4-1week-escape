using UnityEngine;


public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static bool Exists
	{
		get
		{
			return _instance != null;
		}
	}

	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<T>();
				if (_instance == null)
				{
					Debug.Log("í«â¡Ç≥ÇÍÇƒÇ¢ÇÈGameObjectÇ™ë∂ç›ÇµÇ‹ÇπÇÒÅB");
				}
			}

			return _instance;
		}
	}

	virtual protected void Awake()
	{
		if(FindObjectsOfType<T>().Length > 1)
        {
			Destroy(this);
        }
		else
        {
			DontDestroyOnLoad(this);
        }
	}
}
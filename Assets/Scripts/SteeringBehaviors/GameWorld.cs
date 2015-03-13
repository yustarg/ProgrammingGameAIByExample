using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour {

    private static GameWorld _instance;
    public static GameWorld Instance
    { 
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameWorld").GetComponent<GameWorld>();
            }
            return _instance;
        }
    }

    public Transform[] objects;

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

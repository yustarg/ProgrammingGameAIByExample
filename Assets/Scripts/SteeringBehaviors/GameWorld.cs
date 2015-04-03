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

    public Vehicle car;

    void Awake()
    {
        car.SetVehicle(this, new Vector2(2, 2), 2, 5, 5, 5);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

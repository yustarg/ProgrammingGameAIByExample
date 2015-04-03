using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Steering;

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

    public List<BaseGameEntity> gameEntityList = new List<BaseGameEntity>();

    void Awake()
    {
        AddGameEntity(Vehicle.CreateVehicle(VehicleType.Audi));
        AddGameEntity(Vehicle.CreateVehicle(VehicleType.Farrari));
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < gameEntityList.Count; i++)
        {
            gameEntityList[i].OnUpdate();
        }
	}

    public void AddGameEntity(BaseGameEntity entity)
    {
        if (!gameEntityList.Contains(entity))
        {
            gameEntityList.Add(entity);
        }
    }
}

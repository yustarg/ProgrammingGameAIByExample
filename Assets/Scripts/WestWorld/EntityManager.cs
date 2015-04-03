using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WestWorld;

public class EntityManager {

    private Dictionary<int, BaseGameEntity> m_EntityMap = new Dictionary<int,BaseGameEntity>();
    
    private static EntityManager m_instance;
    public static EntityManager Instance()
    {
        if (m_instance == null)
        {
            m_instance = new EntityManager();
        }
        return m_instance;
    }

    public void RegisterEntity(BaseGameEntity newEntity)
    {
        if (!m_EntityMap.ContainsValue(newEntity))
        {
            m_EntityMap.Add(newEntity.GetID(), newEntity);
        }
    }

    public BaseGameEntity GetEntityFromID(int id)
    {
        BaseGameEntity tempEntity = null;
        if (m_EntityMap.TryGetValue(id, out tempEntity))
        {
            return tempEntity;
        }
        else
        {
            return null;
        }
    }

    public void RemoveEntity(BaseGameEntity entity)
    {
        if (m_EntityMap.ContainsValue(entity))
        {
            m_EntityMap.Remove(entity.GetID());
        }
    }
}

using UnityEngine;
using System.Collections;

namespace Steering
{
    public abstract class BaseGameEntity
    {

        private int m_ID;
        private static int m_NextValidID;
        private bool m_Tag;
        private int m_iEntityType;

        //the length of this object's bounding radius
        protected double m_BoundingRadius;
        protected Transform m_Trans;
        protected GameObject m_GameObject;

        protected readonly string m_GameObjectPath;

        public BaseGameEntity(int id, string resPath)
        {
            ID = id;
            m_GameObjectPath = resPath;
        }

        public GameObject GameObject
        {
            get { return m_GameObject; }
        }

        public Transform Transform
        {
            get { return m_Trans; }
        }

        public double BoundingRadius
        {
            set { m_BoundingRadius = value; }
            get { return m_BoundingRadius; }
        }

        public int EntityType
        {
            set { m_iEntityType = value; }
            get { return m_iEntityType; }
        }

        public int ID
        {
            set
            {
                this.m_ID = value;
                m_NextValidID = value + 1;
            }
            get { return m_ID; }
        }

        public bool Tag
        {
            set { m_Tag = value; }
            get { return m_Tag; }
        }

        protected virtual GameObject LoadGameObject()
        {
            UnityEngine.Object obj = Resources.LoadAssetAtPath(m_GameObjectPath, typeof(GameObject));
            return UnityEngine.GameObject.Instantiate(obj) as GameObject;
        }

        public virtual void OnAwake() { }
        public virtual void OnUpdate() { }
        //public virtual bool HandleMessage(Telegram msg) { return false; }

    }

}
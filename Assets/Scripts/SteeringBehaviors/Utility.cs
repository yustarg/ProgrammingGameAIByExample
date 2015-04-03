using UnityEngine;
using System.Collections;

namespace Steering
{
    public class Utility : MonoBehaviour
    {

        public static Vector2 GetGameObjectPos2D(GameObject go)
        {
            Vector2 goPos;
            goPos = new Vector2(go.transform.position.x, go.transform.position.z);
            return goPos;
        }
    }
}
using Code.Controller;
using UnityEngine;

namespace Code
{
    public class RadarView:MonoBehaviour
    {
        public void Draw(RadarObject radarObject, Vector3 radarPos)
        {
            radarObject.Icon.transform.SetParent(transform);
            radarObject.Icon.transform.position = new Vector3(radarPos.x,
                radarPos.z, 0) + transform.position;
        }
    }
}
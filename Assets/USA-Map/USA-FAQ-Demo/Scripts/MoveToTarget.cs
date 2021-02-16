using UnityEngine;


namespace Scripts
{
    public class MoveToTarget : MonoBehaviour
    {
        public bool moveX, moveY;

        public void MoveTo(Transform target)
        {
            if (!moveX && !moveY)
            {
                Debug.LogError("MoveToTarget doesn't have MoveX or MoveY toggled, so nothing happens.");
                return;
            }

            Vector3 offset = target.position - transform.position;

            offset.z = 0;
            if (!moveX) offset.x = 0;
            if (!moveY) offset.y = 0;

            transform.position += offset;
        }
    }
}
using UnityEngine;

namespace CodeBase.Logic.Enemy.Chekers
{
    public class CheckPlatformEnd : MonoBehaviour
    {
        [SerializeField] private LayerMask GroundMask;
        [SerializeField] private Collider2D _collider2D;


        public bool Check()
        {
            Vector3 pos = _collider2D.bounds.min;
            if (transform.eulerAngles.y == 0)
            {
                pos += Vector3.right * _collider2D.bounds.size.x;
            }

            if (!Physics2D.OverlapCircle(pos, 0.1f, GroundMask))
            {
                return true;
            }
            
            pos = _collider2D.bounds.center + _collider2D.bounds.extents.x * transform.right;
            if (Physics2D.OverlapCircle(pos, 0.3f, GroundMask))
            {
                return true;
            }

            return false;
        }
    }
}
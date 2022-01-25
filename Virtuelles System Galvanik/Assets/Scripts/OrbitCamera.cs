using UnityEngine;

namespace haw.unitytutorium.w21
{
    public class OrbitCamera : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private float rotationSpeed = 5.0f;
        [SerializeField] private float scrollSpeed = 3.0f;

        [Header("Rotation Limits")] [SerializeField]
        private float maxVerticalRotation = 30.0f;

        [SerializeField] private float minVerticalRotation = -30.0f;

        [Header("Zoom Limits")] [SerializeField]
        private float maxZoomDistance = 10.0f;

        [SerializeField] private float minZoomDistance = 4.0f;

        [SerializeField] private float maxHorizontalRotation;

        private void Start()
        {
            transform.LookAt(target);
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButton(1))
            {
                RotateAroundTarget();
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                Zoom();
            }
        }

        private void RotateAroundTarget()
        {
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);

            #region Limit Vertical Rotation

            var transformPosition = transform.position;
            var targetPosition = target.position;

            var from = targetPosition - new Vector3(transformPosition.x, targetPosition.y, transformPosition.z);
            var to = targetPosition - transformPosition;
            var currentVerticalAngle = transformPosition.y < targetPosition.y
                ? -Vector3.Angle(from, to)
                : Vector3.Angle(from, to);
       
            var nextVerticalRot = Input.GetAxis("Mouse Y") * rotationSpeed;

            Debug.DrawLine(targetPosition, new Vector3(transformPosition.x, targetPosition.y, transformPosition.z),
                Color.magenta);
            Debug.DrawLine(targetPosition, transformPosition, Color.blue);

            if (currentVerticalAngle + nextVerticalRot >= maxVerticalRotation ||
                currentVerticalAngle + nextVerticalRot <= minVerticalRotation)
                return;

           

            #endregion

            var fromHorizantal = targetPosition - new Vector3(transformPosition.x, targetPosition.y, transformPosition.z);
            var toHorizontal = targetPosition - transformPosition;
            var currentHorizontalAngle = transformPosition.y < targetPosition.y
                ? -Vector3.Angle(from, to)
                : Vector3.Angle(from, to);

            transform.RotateAround(target.position, transform.right, nextVerticalRot);
        }

        private void Zoom()
        {
            var scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

            #region Limit Zoom Distance

            var nextZoomDistance = Vector3.Distance(target.position, transform.position) - scrollAmount;

            if (nextZoomDistance >= maxZoomDistance || nextZoomDistance <= minZoomDistance)
                return;

            #endregion

            transform.Translate(new Vector3(0, 0, scrollAmount), Space.Self);
        }


    }
}
using System;
using UnityEngine;

namespace haw.unitytutorium.w21
{
    public class MouseSelectionController : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;

        // The MouseOverGameObject is a Property with a public Getter and a private Setter
        // It can only be changed (written) within this script but it can be read by other scripts
        public GameObject MouseOverGameObject { get; private set; }

        private Camera cam;

        #region Events & Delegates

        public delegate void OnMouseClickDelegate(GameObject clickedObject);

        public event OnMouseClickDelegate OnMouseClick;

        public delegate void OnHoverEnterDelegate(GameObject hoveredObject);

        public event OnHoverEnterDelegate OnHoverEnter;
        
        public Action OnHoverExit;

        #endregion
        
        private void Awake() => cam = Camera.main;

        private void Update()
        {
            UpdateMouseOverGameObject();

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseClick?.Invoke(MouseOverGameObject);
            }
        }

        private void UpdateMouseOverGameObject()
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100, layerMask))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green);

                if (!MouseOverGameObject)
                {
                    // CASE 1: Mouse Pointer goes from No GameObject to a hovered GameObject.
                    // Mouse enters 'Selectable' GameObject and NO previous GameObject was hovered (MouseOverGameObject == null)
                    NotifyHoverEnter(hit.transform.gameObject);
                }
                else if (!MouseOverGameObject.Equals(hit.transform.gameObject))
                {
                    // CASE 2: Mouse Pointer goes from a hovered GameObject to a different hovered GameObject.
                    // Mouse enters 'Selectable' GameObject and a previous GameObject was hovered (MouseOverGameObject != null)
                    // We notify the hover exit event and set the previous MouseOverGameObject to null,
                    // so in the next frame (update call) the script will go in the if clause above
                    // and notify the hover enter event for the new hovered GameObject
                    NotifyHoverExit();
                }
            }
            else if (MouseOverGameObject)
            {
                // CASE 1: Mouse Pointer goes from a hovered GameObject to No GameObject.
                // If our Ray hits "nothing" but we hovered a GamObject in the previous frame this means that we just exited the GameObject with our mouse cursor.
                // In this case we also notify the hover exit event and set the previous MouseOverGameObject to null.
                NotifyHoverExit();
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.direction * 20, Color.red);
            }
        }

        private void NotifyHoverEnter(GameObject hoveredObject)
        {
            MouseOverGameObject = hoveredObject;
            OnHoverEnter?.Invoke(MouseOverGameObject);
        }
        
        private void NotifyHoverExit()
        {
            MouseOverGameObject = null;
            OnHoverExit?.Invoke();
        }
    }
}
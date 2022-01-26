using UnityEngine;

namespace haw.unitytutorium.w21
{
    public class MouseSelectionHighlight : MonoBehaviour
    {
        [SerializeField] private Material highlightMaterial = null;

        private Material defaultMaterial;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            defaultMaterial = meshRenderer.material;
        }

        private void OnMouseEnter()
        {
            meshRenderer.material = highlightMaterial;
        }

        private void OnMouseExit()
        {
            meshRenderer.material = defaultMaterial;
        }
    }
}
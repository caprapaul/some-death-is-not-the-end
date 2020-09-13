using UnityEngine;

namespace Camera
{
    public class GreyscaleCamera : MonoBehaviour
    {
        public Material Material;

        private void Start()
        {
            Material.SetFloat("_Power", 0.0f);
        }

        public void ToDark()
        {
            Material.SetFloat("_Power", 1.0f);
        }

        public void ToColor()
        {
            Material.SetFloat("_Power", 0.0f);
        }

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, Material);
        }
    }
}
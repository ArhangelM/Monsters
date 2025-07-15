using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.UI.Utils
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class InfiniteParallax : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float parallaxMultiplier = 0.5f;

        private Transform[] tiles = new Transform[3];
        private float textureWidth;
        private Vector3 lastCameraPosition;

        private void Start()
        {
            if (cameraTransform == null)
                cameraTransform = UnityEngine.Camera.main.transform;

            lastCameraPosition = cameraTransform.position;

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            float pixelsPerUnit = sr.sprite.pixelsPerUnit;
            float spriteWidth = sr.sprite.texture.width;

            textureWidth = spriteWidth / pixelsPerUnit * transform.localScale.x;

            // —творити 3 тайли
            tiles[0] = Instantiate(transform, transform.position - Vector3.right * textureWidth, Quaternion.identity);
            tiles[1] = transform;
            tiles[2] = Instantiate(transform, transform.position + Vector3.right * textureWidth, Quaternion.identity);

            // ¬идалити скрипт ≥з клон≥в, щоб не дублювати лог≥ку
            Destroy(tiles[0].GetComponent<InfiniteParallax>());
            Destroy(tiles[2].GetComponent<InfiniteParallax>());
        }

        private void LateUpdate()
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

            // ѕараллакс зсув
            foreach (var tile in tiles)
            {
                tile.position += new Vector3(deltaMovement.x * parallaxMultiplier, 0f, 0f);
            }

            lastCameraPosition = cameraTransform.position;

            // ѕерев≥р€Їмо, чи крайн≥й тайл вийшов за межу Ч ≥ перем≥щаЇмо його вперед
            float cameraX = cameraTransform.position.x;

            for (int i = 0; i < tiles.Length; i++)
            {
                float distance = cameraX - tiles[i].position.x;

                if (Mathf.Abs(distance) >= textureWidth * 1.5f)
                {
                    // якщо л≥вий дуже далеко Ч перем≥стити праворуч
                    if (distance > 0)
                    {
                        float newX = tiles[i].position.x + textureWidth * 3;
                        tiles[i].position = new Vector3(newX, tiles[i].position.y, tiles[i].position.z);
                    }
                    else // правий дуже далеко Ч перем≥стити л≥воруч
                    {
                        float newX = tiles[i].position.x - textureWidth * 3;
                        tiles[i].position = new Vector3(newX, tiles[i].position.y, tiles[i].position.z);
                    }
                }
            }
        }
    }
}
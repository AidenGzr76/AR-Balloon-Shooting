using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private GameObject smokePrefab;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private LayerMask hitLayers; // اختیاری، برای تمیزتر کردن Raycast

    public void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position,
                            arCamera.transform.forward,
                            out hit,
                            maxDistance,
                            hitLayers))
        {
            // به جای چک کردن name، کامپوننت Balloon رو چک می‌کنیم
            Balloon balloon = hit.transform.GetComponent<Balloon>();
            if (balloon != null)
            {
                balloon.Pop(hit.point, hit.normal, smokePrefab);
            }
        }
    }
}

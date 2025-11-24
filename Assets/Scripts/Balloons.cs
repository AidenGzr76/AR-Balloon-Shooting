using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.2f;
    [SerializeField] private float maxHeight = 5f;
    [SerializeField] private int scoreValue = 10; // امتیاز هر بالن

    void Update()
    {
        transform.Translate(Vector3.up * (riseSpeed * Time.deltaTime), Space.World);

        if (transform.position.y > maxHeight)
        {
            Destroy(gameObject);
        }
    }

    public void Pop(Vector3 hitPoint, Vector3 hitNormal, GameObject smokePrefab)
    {
        // اول امتیاز بده
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreValue);
        }

        // بعد افکت دود
        if (smokePrefab != null)
        {
            var vfx = Instantiate(smokePrefab, hitPoint, Quaternion.LookRotation(hitNormal));
            Destroy(vfx, 2f);
        }

        // در نهایت خود بالن حذف بشه
        Destroy(gameObject);
    }
}

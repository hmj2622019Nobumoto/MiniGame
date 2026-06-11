using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Camera fpsCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));//ScreenPointToRay(Mouse.current.position.value);
        if (Physics.Raycast(ray,out hit))
        {
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.Hit();
            }
        }
    }
}

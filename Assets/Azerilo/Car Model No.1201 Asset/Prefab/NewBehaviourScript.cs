using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject prefab;
    public Material[] colors;
    public float scaleMultiplier = 1.1f;
    public AudioSource clickSound;

    private int colorIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject newObject = Instantiate(prefab, hit.point, Quaternion.identity);
                newObject.transform.localScale *= scaleMultiplier;

                if (colors.Length > 0)
                {
                    newObject.GetComponent<Renderer>().material = colors[colorIndex];
                    colorIndex = (colorIndex + 1) % colors.Length;
                }

                if (clickSound != null)
                {
                    clickSound.Play();
                }
            }
        }
    }
}

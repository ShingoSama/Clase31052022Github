using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float Range;
    public GameObject ArrowPrefab;
    RaycastHit hit;
    public Transform ArrowSpawnPosition;
    public GameObject handArrow;
    void Shoot()
    {
        handArrow.gameObject.SetActive(false);
        Vector2 ScreenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        if(Physics.Raycast(ray, out hit, Range))
        {
            GameObject arrowInstantiate = GameObject.Instantiate(ArrowPrefab, ArrowSpawnPosition.transform.position, ArrowSpawnPosition.transform.rotation);
            arrowInstantiate.GetComponent<Arrow>().SetTarget(hit.point);
        }
    }
}

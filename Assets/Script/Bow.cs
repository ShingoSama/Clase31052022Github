using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [System.Serializable]
    public class BowSettings
    {
        [Header("Arrow Settings")]
        public float arrowCount;
        public GameObject arrowPrefab;
        public Transform arrowPos;
        
        [Header("Bow Equip & Unequip Settings")]
        public Transform EquipPos;
        public Transform UnEquipPos;

        public Transform UnEquipParent;
        public Transform EquipParent;

        [Header("Bow String Settings")]
        public Transform bowString;
        public Transform stringInitialPos;
        public Transform stringHandPullPos;
        public Transform stringInitialParentPos;
    }
    [SerializeField]
    public BowSettings bowSettings;

    [Header("Crosshair Settings")]
    public GameObject crosshairPrefab;
    private GameObject currentCrosHair;

    bool canPullString = false;
    bool canFireArrow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EquipBow()
    {
        this.transform.position = bowSettings.EquipPos.position;
        this.transform.rotation = bowSettings.EquipPos.rotation;
        this.transform.parent = bowSettings.EquipParent;
    }
    void UnEquipBow()
    {
        this.transform.position = bowSettings.UnEquipPos.position;
        this.transform.rotation = bowSettings.UnEquipPos.rotation;
        this.transform.parent = bowSettings.UnEquipParent;
    }
    public void ShowCrossHair(Vector3 crosshairPos)
    {
        if (!currentCrosHair)
        {
            currentCrosHair = Instantiate(crosshairPrefab) as GameObject;
        }
        currentCrosHair.transform.position = crosshairPos;
        currentCrosHair.transform.LookAt(Camera.main.transform);
    }
    public void RemoveCrossHair()
    {
        if (currentCrosHair)
        {
            Destroy(currentCrosHair);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;
    void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }

    void Update()
    {
        // 키보드에서 i를 누를 경우
        if (Input.GetKeyDown(KeyCode.I))
        {
            // activeInventory를 반전시킴
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
}

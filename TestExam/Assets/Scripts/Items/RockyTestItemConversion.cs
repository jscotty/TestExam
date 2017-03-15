using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyTestItemConversion : MonoBehaviour
{
    public CharacterItemController itemController;
    public ItemBase item;
    public Forge forge;
    public GameObject ingotPos;

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && item != null)
        {
            forge.PutItemIn(item, itemController);
            item = null;
        }
        if (Input.GetKeyDown(KeyCode.H) && forge.IsItemReady())
        {
            forge.CollectHandout().transform.position = ingotPos.transform.position;
        }
    } 
#endif
}

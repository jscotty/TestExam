using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToBuild : MonoBehaviour {

    [SerializeField] private GameObject _itemUIPrefab;
    private List<GameObject> _currentRecipes = new List<GameObject>();

    private void Start() {
        CreateRecipe();
    }

    public void CreateRecipe (int iRecipe = 0) {
        if(iRecipe == 0) {
            iRecipe = Random.Range(1, 4);
            Debug.Log(iRecipe);
        }
        GameObject tItemUI = Instantiate(_itemUIPrefab, this.transform, false);
        tItemUI.transform.position = transform.position;
        tItemUI.GetComponent<ItemImageSelect>().SetImages(iRecipe - 1);
        _currentRecipes.Add(tItemUI);
    }
}

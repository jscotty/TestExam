using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToBuild : MonoBehaviour {

    [SerializeField] private GameObject _itemUIPrefab;
    private List<GameObject> _currentRecipes = new List<GameObject>();
    [SerializeField] private RecipeHolder _recipeHolder;
    private List<Items> _currentItems = new List<Items>();

    public void CreateRecipe () {
        Recipe tRecipe = _recipeHolder.GetRandomRecipe();
        GameObject tItemUI = Instantiate(_itemUIPrefab, this.transform, false);
        tItemUI.transform.position = transform.position;
        tItemUI.GetComponent<ItemImageSelect>().SetImages(tRecipe);
        _currentRecipes.Add(tItemUI);
        _currentItems.Add(tRecipe.whatItemWillIBecome);
    }

    public bool canHandInItem(Items iItem) {
        for (int item = 0; item < _currentItems.Count; item++) {
            if(_currentItems[item] == iItem) {
                Destroy(_currentRecipes[item]);
                _currentItems.RemoveAt(item);
                _currentRecipes.RemoveAt(item);
                return true;
            }
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsToBuild : MonoBehaviour {

    [SerializeField]
    private GameObject _itemUIPrefab;
    private List<GameObject> _currentRecipes = new List<GameObject>();
    [SerializeField]
    private RecipeHolder _recipeHolder;
    private List<Items> _currentItems = new List<Items>();
    [SerializeField]
    private Scores _scores;

    private void Start() {
        CreateRecipe();
        StartCoroutine(WaitBeforeRecipe(16));
        StartCoroutine(WaitBeforeRecipe(61));
    }

    /// <summary>
    /// Creates a delay before creating a recipe
    /// </summary>
    /// <param name="iSecondsToWait"></param>
    /// <returns></returns>
    IEnumerator WaitBeforeRecipe(int iSecondsToWait) {
        yield return new WaitForSeconds(iSecondsToWait);
        CreateRecipe();
    }

#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log(canHandInItem(Items.bow));
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            Debug.Log(canHandInItem(Items.shield));
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            Debug.Log(canHandInItem(Items.sword));
        }
    }
#endif
    /// <summary>
    /// Creates a recipe and instantiates a prefab to show which item has to be made
    /// </summary>
    public void CreateRecipe() {
        if (_scores.CurrentScore < _scores.MaxScore - _currentRecipes.Count) {
            Recipe tRecipe = _recipeHolder.GetRandomRecipe();
            GameObject tItemUI = Instantiate(_itemUIPrefab, this.transform, false);

            tItemUI.GetComponent<ItemImageSelect>().SetImages(tRecipe);
            _currentRecipes.Add(tItemUI);
            _currentItems.Add(tRecipe.whatItemWillIBecome);
        }
    }

    /// <summary>
    /// Returns if an item can be handed in. If it can it will do background calculations and remove the prefab showing the recipe
    /// </summary>
    /// <param name="iItem"></param>
    /// <returns></returns>
    public bool canHandInItem(Items iItem) {
        for (int item = 0; item < _currentItems.Count; item++) {
            Debug.Log(_currentItems[item]);
            if (_currentItems[item] == iItem) {
                GameObject tRecipe = _currentRecipes[item];
                _currentRecipes.RemoveAt(item);
                Destroy(tRecipe);

                _currentItems.RemoveAt(item);
                _scores.FinishedItem();
                if (_scores.CurrentScore == _scores.MaxScore) {
                    FinishedGame();
                }
                StartCoroutine(WaitBeforeRecipe(5));
                return true;
            }
        }
        return false;
    }

    public void FinishedGame() {
        Debug.Log("Game Finished, " + _scores.CurrentScore + " out of " + _scores.MaxScore + " recipes completed");
    }
}

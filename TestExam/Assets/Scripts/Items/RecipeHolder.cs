using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeHolder : Singleton<RecipeHolder> {

    public List<Recipe> recipeList;

    public Recipe GetRandomRecipe()
    {
        return recipeList[Random.Range(0,recipeList.Count)];
    }

    /// <summary>
    /// returns a recipe from 2 itembase classes
    /// </summary>
    /// <returns>a recipe class returnns null if not found</returns>
    public Recipe ReturnRecipeFromItem(ItemBase iItemOne, ItemBase iItemTwo)
    {
        for (int i = 0; i < recipeList.Count; i++)
        {
            if (recipeList[i].CheckIfItemsMakeRecipe(iItemOne,iItemTwo))
            {
                return recipeList[i];
            }
        }
        return null;
    }
}

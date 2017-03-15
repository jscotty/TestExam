using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Recipe
{
    public Items itemOne;
    public Items itemTwo;
    public Items whatItemWillIBecome;

    public bool CheckIfItemsMakeRecipe(ItemBase iItemOne, ItemBase iItemTwo)
    {
        if (iItemOne.whatItemAmI == itemOne && iItemTwo.whatItemAmI == itemTwo)
        {
            return true;
        }
        else if (iItemOne.whatItemAmI == itemTwo && iItemTwo.whatItemAmI == itemOne)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

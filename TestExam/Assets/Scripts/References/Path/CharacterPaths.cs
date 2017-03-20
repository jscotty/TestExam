namespace Exam.Reference.Path
{
    using System.Collections.Generic;
    class CharacterPaths
    {
        public const string CHARACTER_YELLOW = "Prefabs/Characters/Character_Yellow";
        public const string CHARACTER_RED = "Prefabs/Characters/Character_Red";
        public const string CHARACTER_GREEN = "Prefabs/Characters/Character_Green";
        public const string CHARACTER_BLUE = "Prefabs/Characters/Character_Blue";

        public static readonly Dictionary<CharacterType, string> CHARACTER_PATH = new Dictionary<CharacterType, string>() {
            { CharacterType.CHARACTER_YELLOW, CHARACTER_YELLOW },
            { CharacterType.CHARACTER_RED, CHARACTER_RED },
            { CharacterType.CHARACTER_GREEN, CHARACTER_GREEN },
            { CharacterType.CHARACTER_BLUE, CHARACTER_BLUE },
        };

        public static readonly Dictionary<string, CharacterType> CHARACTER_COLOR = new Dictionary<string, CharacterType>() {
            { CHARACTER_YELLOW, CharacterType.CHARACTER_YELLOW },
            { CHARACTER_RED, CharacterType.CHARACTER_RED },
            { CHARACTER_GREEN, CharacterType.CHARACTER_GREEN },
            { CHARACTER_BLUE, CharacterType.CHARACTER_BLUE },
        };
    }
}


public enum CharacterType
{
    CHARACTER_YELLOW,
    CHARACTER_RED,
    CHARACTER_GREEN,
    CHARACTER_BLUE,
}
namespace CodeBase.Static
{
    public static class Constants
    {
        private static float _epsilon = 0.001f;
        private static string _playerPrefabLocaliton = "Player/Player";
        private static string _level1 = "Level1";
        private static string _mainMenu = "MainMenu";
        private static string _initialGame = "InitialGame";
        private static string _playerInititalPointTag = "PlayerInitialPoint";

        public static float Epsilon => _epsilon;

        public static string PlayerPrefabLocation => _playerPrefabLocaliton;

        public static string Level1 => _level1;

        public static string MainMenu => _mainMenu;

        public static string InitialGame => _initialGame;

        public static string PlayerInitialPointTag => _playerInititalPointTag;
    }
}
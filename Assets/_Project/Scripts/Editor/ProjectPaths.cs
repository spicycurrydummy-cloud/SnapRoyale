namespace SnapRoyale.Editor
{
    /// <summary>
    /// エディタ拡張から参照するプロジェクト内の標準パス。
    /// フォルダ構成を変更した場合は Docs/02_Tech/ProjectStructure.md と合わせて更新する。
    /// </summary>
    public static class ProjectPaths
    {
        public const string Root = "Assets/_Project";
        public const string Scenes = Root + "/Scenes";
        public const string Prefabs = Root + "/Prefabs";
        public const string Data = Root + "/Data";
        public const string Sprites = Root + "/Art/Sprites";
    }
}

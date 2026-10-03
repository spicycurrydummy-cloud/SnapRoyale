# フォルダ構成

## リポジトリ全体

```
SnapRoyale/
├── CLAUDE.md              AI 向け開発ルール（最初に読む）
├── README.md
├── Docs/                  仕様書・設計書（Markdown）
├── Assets/
│   ├── _Project/          ★ 自作アセットはすべてここ
│   ├── ThirdParty/        外部から導入したアセット（Asset Store 等）
│   ├── Settings/          URP 設定（テンプレート由来。触らない）
│   └── Scenes/            テンプレート由来のサンプルシーン
├── Packages/              パッケージ定義（manifest.json）
├── ProjectSettings/       Unity プロジェクト設定
└── Library/ Temp/ Logs/ UserSettings/   生成物（Git 管理外）
```

## Assets/_Project

```
_Project/
├── Scripts/
│   ├── Runtime/           SnapRoyale.Runtime.asmdef（ゲーム本体のコード）
│   │   ├── Core/          ゲーム全体の基盤（ゲーム進行管理、共通ユーティリティ）
│   │   ├── Gameplay/      ゲームプレイ（プレイヤー、敵、ギミック等）
│   │   └── UI/            UI ロジック
│   └── Editor/            SnapRoyale.Editor.asmdef（エディタ拡張・ビルドスクリプト）
├── Tests/
│   ├── EditMode/          SnapRoyale.Tests.EditMode.asmdef（ロジックの単体テスト）
│   └── PlayMode/          SnapRoyale.Tests.PlayMode.asmdef（実行時の挙動テスト）
├── Scenes/                ゲームのシーン
├── Prefabs/               プレハブ
├── Data/                  ScriptableObject（ゲームパラメータ・マスターデータ）
├── Art/
│   ├── Sprites/           スプライト画像
│   ├── Animations/        AnimationClip / AnimatorController
│   ├── Materials/         マテリアル
│   └── Tiles/             Tilemap 用タイル・パレット
├── Audio/
│   ├── BGM/
│   └── SE/
└── UI/                    UI 用アセット（UXML/USS、UI 用スプライト等）
```

## ルール

- 自作アセットは必ず `Assets/_Project/` 配下に置く。外部アセットは `Assets/ThirdParty/` に置き、直接改変しない。
- `_Project` という汎用名にしているのは、プロジェクト名変更の影響を受けないため。
- Runtime 配下のサブフォルダは機能が増えたら追加してよい（例: `Gameplay/Player/`）。追加したらこのドキュメントを更新する。
- 空フォルダには `.gitkeep` を置く（Git は空フォルダを管理しないため）。中身ができたら削除してよい。
- `Assets/Scenes/SampleScene.unity` と `Assets/Settings/` はテンプレート由来。ゲーム用シーンは `_Project/Scenes/` に新規作成する。

## アセンブリ依存関係

```
SnapRoyale.Runtime  ← SnapRoyale.Editor
        ↑
        ├── SnapRoyale.Tests.EditMode
        └── SnapRoyale.Tests.PlayMode
SnapRoyale.Runtime → Unity.InputSystem
```

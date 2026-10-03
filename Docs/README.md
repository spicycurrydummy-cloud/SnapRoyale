# ドキュメント索引

| フォルダ | 内容 | 主な更新者 |
|---|---|---|
| [00_Overview/](00_Overview/) | ゲームのコンセプト・全体像 | ユーザー（Claude が清書） |
| [01_GameDesign/](01_GameDesign/) | 機能ごとのゲーム仕様書（**仕様の唯一の正**） | ユーザー ⇄ Claude |
| [02_Tech/](02_Tech/) | 技術設計・フォルダ構成・規約・CLI 手順 | Claude |
| [03_Progress/](03_Progress/) | ロードマップ・タスク管理 | Claude（優先順位はユーザー） |
| [04_Decisions/](04_Decisions/) | 重要な決定の記録（ADR） | Claude |
| [_Templates/](_Templates/) | 仕様書・ADR のテンプレート | — |

## 主要ドキュメント

- [ゲームコンセプト](00_Overview/GameConcept.md)
- [仕様書一覧](01_GameDesign/README.md)
- [フォルダ構成](02_Tech/ProjectStructure.md)
- [アーキテクチャ方針](02_Tech/Architecture.md)
- [コーディング規約](02_Tech/CodingConventions.md)
- [Unity CLI 操作ガイド](02_Tech/UnityCLI.md)
- [ロードマップ](03_Progress/Roadmap.md)
- [バックログ](03_Progress/Backlog.md)
- [決定記録一覧](04_Decisions/README.md)

## 仕様の決め方（ユーザー向け）

1. やりたいことを会話で Claude に伝える（箇条書き・ラフで OK）。
2. Claude が `01_GameDesign/` に仕様書を起こし、不明点を質問する。
3. ユーザーが確認・修正して「承認」したら、Claude が実装に入る。
4. 実装後、仕様書の「状態」が `実装済` に更新される。

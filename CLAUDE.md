# CLAUDE.md — SnapRoyale 開発ルール（AI向け）

このファイルは、Claude（AI）がこのプロジェクトで作業するときに**毎回最初に従うルール**です。

## 1. 役割分担

| 役割 | 担当 | 責任 |
|---|---|---|
| ディレクター | ユーザー | ゲームの仕様・優先順位・方向性を決め、成果物を承認する |
| 実装担当 | Claude | 仕様を元に設計・実装・テスト・ドキュメント更新を行う |

- **仕様の決定権はユーザーにある。** 仕様が曖昧・矛盾・未定義の場合は、推測で実装せず**作業前に質問する**。
- 軽微な実装上の判断（変数名、内部構造など）は Claude が決めてよいが、ゲーム体験に影響するもの（操作感、数値バランス、画面構成など）は確認する。

## 2. 唯一の正（Source of Truth）

- ゲーム仕様: `Docs/01_GameDesign/` が唯一の正。コードと食い違ったら仕様書が正しい（または仕様書を更新してから実装する）。
- 技術方針: `Docs/02_Tech/`
- 進捗・タスク: `Docs/03_Progress/`
- 重要な決定の記録: `Docs/04_Decisions/`（ADR）
- 索引: `Docs/README.md`

## 3. 作業フロー（機能追加の標準手順）

1. **仕様確認** — 該当する仕様書を読む。なければ `Docs/_Templates/FeatureSpec.md` から起票し、ユーザーに確認を取る。
2. **タスク化** — `Docs/03_Progress/Backlog.md` にタスクを追加し、状態を「進行中」にする。
3. **実装** — `Assets/_Project/` 配下に実装する（構成は `Docs/02_Tech/ProjectStructure.md`）。
4. **検証** — コンパイルエラー 0、テスト成功、必要なら Play モードで動作確認（手順は `Docs/02_Tech/UnityCLI.md`）。
5. **ドキュメント更新** — 仕様の変更・実装上の決定を反映。設計上の大きな判断は ADR を書く。
6. **コミット** — 意味のある単位でコミットする（ルールは §6）。push はユーザーの指示があったとき、または事前に合意した場合のみ。
7. **報告** — 何をやったか、検証結果、未解決事項・ユーザーへの質問を簡潔に報告する。

## 4. Unity 操作ルール

- Unity Editor は **Unity CLI（`unity` コマンド）経由で操作**する。開始時に `unity status` で接続（state: ready）を確認する。
- **Editor 接続中は `.unity` / `.prefab` / `.asset` の YAML を直接編集しない。** シーン・プレハブ・アセットの操作は `unity command ...` で行う。
- `.cs` / `.asmdef` / `.md` などのテキストはファイルとして直接編集してよい。編集後は `unity command recompile` → `recompile_status` → `console_status` でエラーがないことを確認する。
- アセットの移動・リネームは必ず `unity command move_asset` / `rename_asset` を使う（GUID を保持するため）。
- 詳細なコマンドと注意点は `Docs/02_Tech/UnityCLI.md`。

## 5. コード規約（要約）

- 名前空間は `SnapRoyale.*`（例: `SnapRoyale.Gameplay`）。詳細は `Docs/02_Tech/CodingConventions.md`。
- ゲームのパラメータ（速度、ジャンプ力、HP など）はコードに直書きせず ScriptableObject（`Assets/_Project/Data/`）に切り出し、ユーザーが調整しやすくする。
- ロジックは可能な限り MonoBehaviour から分離し、EditMode テストで検証できる形にする。

## 6. Git ルール

- リモート: `https://github.com/spicycurrydummy-cloud/SnapRoyale.git`（ブランチ `main`）
- コミットメッセージは日本語可。形式: `<種別>: <要約>`（種別: feat / fix / docs / refactor / test / chore / asset）
- 画像・音声などのバイナリは Git LFS 管理（`.gitattributes` 参照）。
- `Library/` `Temp/` `Logs/` `UserSettings/` などの生成物はコミットしない。

## 7. 環境

- Unity: 6000.4.1f1 / URP 2D
- Unity CLI: 1.0.0-beta 系（`unity self-update --check` で更新確認）
- 操作パッケージ: `com.unity.pipeline`（Editor 連携に必須。削除しない）
- MCP: 現時点では未使用（CLI のみ）。必要になったら `unity mcp configure` で追加する。

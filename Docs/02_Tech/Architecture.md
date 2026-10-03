# アーキテクチャ方針

> 状態: 初期方針（ゲーム仕様確定後に具体化する）

## 基本方針

1. **データとロジックの分離** — 調整用の数値は ScriptableObject に置き、ユーザーが Inspector から変更できるようにする。
2. **テストしやすい設計** — 判定・計算などの純粋なロジックは MonoBehaviour に依存しない C# クラスにし、EditMode テストで検証する。MonoBehaviour は Unity との橋渡し（入力・描画・物理）に徹する。
3. **疎結合** — コンポーネント間は直接参照を最小限にし、イベント（C# event / ScriptableObject イベント等）で連携する。具体的な方式は仕様確定後に ADR で決める。
4. **CLI で検証可能** — 主要な状態はログ・テスト・`unity command eval` で外部から確認できるようにする。

## 採用技術

| 領域 | 採用 | 備考 |
|---|---|---|
| 描画 | URP 2D Renderer | テンプレート既定 |
| 入力 | Input System | `Assets/InputSystem_Actions.inputactions`（テンプレート既定、仕様に合わせて調整） |
| 物理 | Physics2D | 横視点・下方向重力 |
| UI | 未定（uGUI / UI Toolkit） | 仕様確定後に決定 |
| テスト | Unity Test Framework | EditMode / PlayMode |

## 未決事項

- [ ] ゲームの状態管理方式（ステートマシン等）
- [ ] UI 方式
- [ ] セーブデータの要否・方式
- [ ] マルチプレイの要否（あれば通信方式）

# コーディング規約

## 命名

| 対象 | 規則 | 例 |
|---|---|---|
| 名前空間 | `SnapRoyale.<領域>` | `SnapRoyale.Gameplay` |
| クラス・構造体・enum | PascalCase | `PlayerController` |
| public メソッド・プロパティ | PascalCase | `TakeDamage()` |
| private フィールド | `_camelCase` | `_moveSpeed` |
| SerializeField | `[SerializeField] private` + `_camelCase` | `[SerializeField] private float _jumpPower;` |
| 定数 | PascalCase | `MaxHp` |
| ScriptableObject アセット | `<種類>_<名前>` | `PlayerParams_Default.asset` |
| プレハブ | PascalCase | `Player.prefab` |

## ルール

- 1 ファイル 1 クラス。ファイル名 = クラス名。
- public フィールドは使わず、`[SerializeField] private` + 必要ならプロパティで公開する。
- `GameObject.Find` / `SendMessage` などの文字列ベースの参照は使わない。
- `Update` 内での `GetComponent` やアロケーションを避ける。
- マジックナンバーは ScriptableObject か定数に切り出す。
- コメントは日本語。「何をするか」より「なぜそうするか」を書く。public API には `/// <summary>` を付ける。
- 新しい asmdef を作ったら `ProjectStructure.md` の依存関係図を更新する。

## テスト

- テストクラス名: `<対象クラス>Tests`、テストメソッド名: `<対象>_<条件>_<期待結果>`
- 新しいロジックには可能な限り EditMode テストを書く。

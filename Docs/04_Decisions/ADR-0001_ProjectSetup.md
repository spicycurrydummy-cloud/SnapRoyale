# ADR-0001: 開発体制とプロジェクト初期構成

- 日付: 2026-10-03
- 状態: 採用
- 決定者: ユーザー

## 背景

ユーザーがディレクターとして仕様を決め、実装は主に AI（Claude）が行う体制で開発する。AI が管理しやすく、ユーザーが仕様を追いやすい構成が必要。

## 決定

| 項目 | 決定内容 |
|---|---|
| プロジェクト名 | SnapRoyale（旧名 SnapFight） |
| エンジン | Unity 6000.4.1f1 / URP 2D |
| ゲーム形式 | 2D・横視点・下方向重力 |
| Editor 操作 | Unity CLI（`com.unity.pipeline`）のみ。MCP は必要時に追加 |
| バージョン管理 | Git + GitHub（`spicycurrydummy-cloud/SnapRoyale`）、バイナリは Git LFS |
| ドキュメント | `Docs/` 配下に Markdown（日本語） |
| アセット配置 | 自作は `Assets/_Project/`、外部は `Assets/ThirdParty/` |
| コード構成 | asmdef で Runtime / Editor / Tests(EditMode, PlayMode) に分割 |

## 影響

- AI は `CLAUDE.md` のルールに従って作業する。
- 仕様は `Docs/01_GameDesign/` を唯一の正とし、曖昧な点は実装前にユーザーへ確認する。

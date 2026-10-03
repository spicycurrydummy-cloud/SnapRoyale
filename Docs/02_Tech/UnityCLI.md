# Unity CLI 操作ガイド

Claude が Unity Editor を操作するときの手順と、実際に動かして分かった注意点をまとめる。

## 前提

- Unity Editor でこのプロジェクトを開いておく（`com.unity.pipeline` パッケージで CLI と連携する）。
- 起動していなければ `unity open .`、続けて `unity status --until-ready` で準備完了を待つ。

## 基本コマンド

```bash
unity status                         # Editor 接続確認（state: ready ならOK）
unity command                        # 利用可能なコマンドのタグ一覧
unity command --tag assets           # タグ内のコマンド一覧
```

### コンパイル確認

```bash
unity command recompile --focus true
unity command recompile_status       # completed / up_to_date になるまでポーリング
unity command console_status         # groundTruth.compilationFailed と consoleErrors を確認
unity command console --tail 20 --level warning
```

### テスト

```bash
unity command run_tests --mode EditMode
unity command run_tests --mode PlayMode --async_tests true   # PlayMode は async 必須
unity command test_status                                    # async の結果確認
```

### アセット操作

```bash
unity command create_folder --path Assets/_Project/Foo
unity command move_asset --asset <path> --destination <path>   # GUID 保持
unity command create_asset --path <path>.asset --type <型名>
```

### 任意の C# 実行

```bash
unity command eval --code 'return UnityEngine.Application.unityVersion;'
```

## 既知の注意点（ハマりどころ）

| 症状 | 原因 / 対処 |
|---|---|
| `eval` が `Main thread operation timed out after 5000ms` | Editor が非フォーカスでメインスレッドが止まっている。`recompile --focus true` 等で代替するか、ユーザーに Editor ウィンドウを一度前面にしてもらう |
| `run_tests --mode PlayMode` が `0/0 件` | 同期実行では PlayMode が動かない。`--async_tests true` を付け、`test_status` で結果を取る |
| JSON 引数（`--settings` 等）が「〜が必要ですが」エラー | PowerShell のクォート問題。**Bash ツールから** `--settings '{"key":"value"}'` の形で渡す |
| `unity status` に何も出ない / 接続できない | コンパイルエラーで Safe Mode の可能性。`unity pipeline list` で確認し、エラーを修正して Editor を再起動 |
| asmdef に「no scripts associated」警告 | asmdef 配下に .cs が 1 つもない。最低 1 ファイル置く |

## ビルド

ターゲットプラットフォーム確定後に `Assets/_Project/Scripts/Editor/` にビルドスクリプトを追加し、ここに手順を追記する。

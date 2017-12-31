// 元ソース uri: https://qiita.com/logikuma/items/fcfa2761d9166ae282d4

namespace Formatter

module Format = begin
  /// 変換指定子を用いて文字列を変換する
  let SPrintF style value : string =
    // 受け取った書式文字列をPrintFormat型にキャスト
    let f = Printf.StringFormat<_>(style)
    // sprintfで書式変更した結果を返却
    sprintf f value
end

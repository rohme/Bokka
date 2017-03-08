# ![Bokka](http://i.imgur.com/kiCp6aX.png)Bokka（歩荷）

Bokkaはクーリエワークスの戦略物資宅配を支援するツールです

![Bokka](http://i.imgur.com/2KuS8N0.jpg)

## 使用方法
1. FF11を起動し、キャラクター選択後にBokkaを管理者モードで起動してください。
2. このツールはWindowerアドオンのenternityを使用している前提で作成されています。起動してない場合は`//lua l enternity`で起動してください。  
さらに、Waypointは`選択後の再確認をしない`設定にしてください。
3. Bokkaが起動しない場合、[動かない場合](#user-content-動かない場合)を参照してください。
4. 使用枚数・停止条件を設定後、COUカウンター前で実行してください。
5. 初回実行時、COUカウンターでどのエリアの宅配を受ける所で一時停止します。宅配したいエリアを選択してください。
6. 同様にWaypointでも一時停止するので、受けたエリア及びビバックを選択してください。
7. 目的に合わせて設定を変更してください。

## 画面説明
![Bokka](http://i.imgur.com/2KuS8N0.jpg)

* 使用枚数  
一度に使用するチケットの枚数を指定します。
* カミール#3モード  
チェックすると配達先に飛んだあと、AdministratorやWaypointの近くに移動したり、方向を合わせるのを省略し、ボットっぽさを無くすような動きをします。
* 残チケット  
残チケットが指定枚数以下になった場合、配達を停止します。
* 残CP  
残CPが指定数以下になった場合、配達を停止します。
* 戦略物資インデックス  
COUカウンターで、配達先選択時のメニューインデックスを指定します。（－１にしておくと、実行時に自動設定）
* エリアインデックス  
Waypointの届け先（エリア）選択時、配達先のメニューインデックスを指定します。（－１にしておくと、実行時に自動設定）
* ビバックインデックス  
Waypointの届け先（ビバック）選択時、配達先のメニューインデックスを指定します。（－１にしておくと、実行時に自動設定）
* クリア  
全てのメニューインデックスを初期化します。

## 動かない場合
* Windowerアドオンのenternityを起動してください。
* 管理者権限で実行してください。
* [Windower4](http://windower.net/)をインストールする。
* 最新の[EliteAPI (EliteMMO.API)](http://www.elitemmonetwork.com/)をインストールする。  
* [VisualStudio2015のランタイム](https://www.microsoft.com/ja-JP/download/details.aspx?id=48145)をインストールする。**（必ずx86版を使用してください）**
* [.Net4.0](http://www.microsoft.com/ja-JP/download/details.aspx?id=17718)をインストールする。

##今後の予定

## 開発環境
* Windows10 Pro 64bit
* [Microsoft Visual Studio Express 2015](http://www.visualstudio.com/ja-jp/products/visual-studio-express-vs.aspx)
* [.NET Framework 4.0](http://www.microsoft.com/ja-jp/net/)
* [Windower4](http://windower.net/)
* [EliteAPI (EliteMMO.API)](http://www.elitemmonetwork.com/)

## ソース
Bokkaは以下のサイトで、GPLv2ライセンスにて公開しています。  
https://github.com/rohme/  
障害報告・質問とかあればIssuesに登録して頂いて結構です。

## 免責事項
本ソフトはフリーソフトです。自由にご使用ください。  
このソフトウェアを使用したことによって生じたすべての障害・損害・不具合等に関しては、作者は一切の責任を負いません。各自の責任においてご使用ください。  

## 修正履歴
* **2017-03-08 Ver0.0.4**
    - COUワークス近くのWaiypointのインデックスが変更されたので修正
	- 開発ツールをVisualStudio2015に変更  
	**[VisualStudio2015のランタイム(x86)](https://www.microsoft.com/ja-jp/download/details.aspx?id=48145)が必要になりますので、インストールをお願いします。**
* **2015-11-19 Ver0.0.3**
    - COUワークス近くのWaiypointのインデックスが変更されたので修正
* **2015-06-10 Ver0.0.2**
    - いろいろ修正
* **2015-05-13 Ver0.0.1**
    - 初回リリース

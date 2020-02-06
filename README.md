# unity-space
Unityで太陽系を作成しました。各惑星は太陽からの引力を受けて等速円運動をします。  
宇宙を題材としたアプリのベースなどにご利用ください。  
※シンプルな作りを重視しているため、惑星の軌道やスケールは現実に忠実ではありません。  
※UnityもOSSも初心者なので至らない点があるかもしれません。  
![demo](https://github.com/ronron-gh/unity-space/blob/master/demo/capture.png)  
## こだわった点
・各惑星の運動は共通のスクリプトで記述している。惑星は次の動きをする。  
　・太陽から受ける引力で等速円運動する。  
　・自転する。自転軸の傾きは惑星毎に設定できる。  
・月も実装した（衛星用のスクリプトを別途作成）。  
・各惑星にはテクスチャを貼り付けてリアルな見た目にした（NASAが公開するフラット画像を使用）。  
・土星の輪はBlenderで作成。  
・光は太陽の位置から全方位に照射。  
・カメラのPitch、Yawはスマホのジャイロでも調整可能（カメラ用スクリプト内の＃ENABLE_GYROを有効化してスマホ向けにビルドすることで使用可能）。  

## 開発に用いたUnityバージョン  
2018.2.15f1  

## 使い方
Unityプロジェクト一式となっていますので、cloneしたフォルダをUnityで開いてください。
Assets->Scenes->SampleScene をHierarchyにドラッグ＆ドロップすると、デバッグ実行できる状態になります。  
また、demoフォルダに、Windows向けにビルドしたexeファイル（Windows10で動作確認済み）と、android用のインストーラ(.apk)が入っていますのでお試しください。

## 惑星のテクスチャ画像の配布元
以下のサイトから集めましたが、配布元はNASAのようです。  
NASAの画像は通常著作権フリーのようですが、商用利用は自己責任でお願いします。  
・地球  
　Blue Marble (https://earthobservatory.nasa.gov/features/BlueMarble/BlueMarble_2002.php)  
・水星、金星、火星、木星、天王星、海王星  
　壁紙 宇宙館（http://powerforce.moo.jp/list1297.html)  
・土星、土星の輪  
　JHT's Planetary Pixel Emporium (http://planetpixelemporium.com/index.php)  
・月  
　CGBeginner (https://cgbeginner.net/create-moon/)  

 

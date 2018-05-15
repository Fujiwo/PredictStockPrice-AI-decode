# PredictStockPrice-AI-decode
PredictStockPrice Sample for Microsoft de:code 2018 AI sessions

[Microsoft Azure Machine Learning Studio](https://studio.azureml.net) による株価予想プログラム

---
### 概要:
Microsoft Azure Machine Learning Studio 上で、株価データを Python で加工し、機械学習させ、API を作成し、Web アプリケーションから JavaScript で使ってみるところまでのチュートリアル。

### 狙い:
Azure Machine Learning Studio を使って簡単に機械学習を利用した API が作れ、自分のアプリケーションで利用できるようになる。

### レポジトリーの中のファイル:

| ファイル名 | 説明 | 使用されている章 | 
| ---- | ---- | ---- |
| 9790.csv | 株価データ (CSV) | 2.6 |
| AzureMachineLearningScript.1.py | Microsoft Azure Machine Learning Studio で用いる Python Script | 3.13 |
| PredictStockPrice.Console/Program.cs | Microsoft Azure Machine Learning Studio で作成した API を呼び出す C# のサンプル コード | 5 |


### 目次:

* [1. SQL データベースの作成](#section1)
* [2. SQL データベースへのデータのアップロード](#section2)
* [3. Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](#section3)
* [4. Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](#section4)
* [5. C# から API を呼んでみるテスト](#section5)

---
## <a id="section1"></a>1. SQL データベースの作成

### 1.1 [Azure ポータル](https://portal.azure.com) にサインインして、SQL データベースを作成します。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(04).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.2 「データベース名」を入力し、「サブスクリプション」を選択、「リソースグループ」を入力し、サーバーの構成を行います。
サーバーの構成では、サーバー管理者ログインやパスワードなどを設定します。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(06).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.3 「価格レベル」を設定し、「作成」します。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(07).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.4 作成されたデータベースの「接続文字列」を確認してみましょう。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(08).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.5 サーバー名などが含まれた「接続文字列」が確認できます。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(10).png?raw=true "SQL データベースの作成 | Microsoft Azure")

---
## <a id="section2"></a>2. SQL データベースへのデータのアップロード

### 2.1 [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/ja-jp/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) を起動し、SQL データベースに接続します。
先ほどの接続文字列の中のサーバー名と、サーバーの構成で設定したサーバー管理者ログインやパスワードなどを入力します。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(00).png?raw=true "SQL データベースへのデータのアップロード")

### 2.2 Azure にサインインします。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(11).png?raw=true "SQL データベースへのデータのアップロード")

### 2.3 ファイアウォール ルールを設定します。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(01).png?raw=true "SQL データベースへのデータのアップロード")

### 2.4 SQL データベースに接続されました。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(12).png?raw=true "SQL データベースへのデータのアップロード")

### 2.5 データベースに対して、タスクからフラットファイルをインポートしましょう。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(13).png?raw=true "SQL データベースへのデータのアップロード")

### 2.6 本レポジトリーの中の「9790.csv」を指定します。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(14).png?raw=true "SQL データベースへのデータのアップロード")

### 2.7 データがプレビューされます。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(15).png?raw=true "SQL データベースへのデータのアップロード")

### 2.8 各列のデータ タイプや主キーを設定します。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(16).png?raw=true "SQL データベースへのデータのアップロード")

### 2.9 インポートされたら、テーブルの中のデータを確認してみましょう。

![SQL データベースへのデータのアップロード](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(17).png?raw=true "SQL データベースへのデータのアップロード")

---
## <a id="section3"></a>3. [Microsoft Azure Machine Learning Studio](https://studio.azureml.net) によるマシーンラーニング (機械学習)

### 3.1 [Microsoft Azure Machine Learning Studio](https://studio.azureml.net) にサインインします。
料金プランを選びます。ここでは、「Free Workspace」を選ぶことにします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(18).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.2 「EXPERIMENTS」-「NEW」で新しい Experiment の追加を開始します。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(20).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.3 Blank Experiment を選んで追加します。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(21).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.4 左側のツール パレットから、「Data Input and Output」の中の「Import Data」を中央の作図エリアの先頭の箱にドラッグ アンド ドロップします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(23).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.5 「Import Data」のプロパティを設定します。
「Launch Import Data Wizard」をクリックして、インポート データ ウィザードを起動します。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(32).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.6 「Azure SQL Database」を選択して、次へ行きます。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(33).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.7 「Subscription ID」、「Database server name」、「Database name」、「User name」そして「Password」を入力します。
「Test Connection」で接続に成功することを確認して、次へ行きます。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(34).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.8 「Database query」として、SELECT [Adjusted] FROM [dbo].[9790] と入力し、ウィザードを完了します。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(39).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.9 「Import Data」の動作を確認してみましょう。
下のバーの「RUN」をクリックします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(40).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.10 「RUN」が完了したら、「Import Data」を右クリックし、「Results dataset」から「Visualize」をクリックします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(41).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.11 SQL データベースからインポートされたデータを見ることができます。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(42).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.12 このままのデータではマシーンラーニング (機械学習) に使うのに適さないため、プログラミング言語 Python を使って、データを加工することにします。
左のツール パレットの「Python Language Modules」から「Execute Python Script」を中央の作図領域にドラッグ アンド ドロップします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(43).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.13 プロパティの「Python script」には、本レポジトリーの中の「AzureMachineLearningScript.1.py」の中のテキストをコピーしてください。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(44).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.14 「Import Data」の下部の小円から「Execute Python Script」の上部の一番左の小円までをドラッグ アンド ドロップして、「Import Data」の出力を「Execute Python Script」の入力とします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(45).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.15 「Import Data」のときと同様、「RUN」してから「Execute Python Script」を右クリックして、「Result dataset」から「Visualize」を選んでみましょう。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(46).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.16 Python で加工後のデータを見ることができます。
この Python では、単純な株価1列だけのデータを、各行が、14日分の株価の上昇率のデータと翌日株価が実際に上昇したかどうかの教師データという、15列からなるデータに加工しています。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(47).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.17 次にこのデータを学習用データと評価用データに分割します。
ツール パレットの「Data Transformation」の中の「Sample and Split」から「Split Data」を、作図領域にドラッグ アンド ドロップします。
「Execute Python Script」の出力を「Split Data」の入力とします。
「Split Data」のプロパティの「Fraction of rows in the first output dataset」の値を 0.8 にします。
これにより、データは分割され、80%が1番から 20%が2番から出力されます。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(49).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.18 いよいよマシーン ラーニング (機械学習) を行う「Train Model」を追加します。
ツール パレットの「Machine Learning」の中の「Train」から「Train Modal」を、作図領域にドラッグ アンド ドロップします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(50).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.19 次に、ツール パレットの「Machine Learning」の中の「Initialize Model」の「Classification」から「Two Class Support Vector Machine」を、作図領域にドラッグ アンド ドロップします。
[サポート ベクター マシン](https://ja.wikipedia.org/wiki/%E3%82%B5%E3%83%9D%E3%83%BC%E3%83%88%E3%83%99%E3%82%AF%E3%82%BF%E3%83%BC%E3%83%9E%E3%82%B7%E3%83%B3) は、は、教師あり学習を用いたパターン認識方法で、今回は株価が上がるか否かの分類に用います。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(51).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.21 「Two Class Support Vector Machine」の出力を「Train Model」の1つ目の入力とし、「Split Data」の1つ目の出力を「Train Model」の2つ目の入力とします。
また、「Train Model」のプロパティから「Launch column selector」をクリックします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(52).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.22 データの中から、教師データとする列を選びます。
「WITH RULES」 - 「Include」「column names」を選び、列名として Answer と入力します。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(53).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.23 次に、マシーン ラーニング (機械学習) の結果を、評価用データを使って評価してみます。
ツール パレットの「Machine Learning」の中の「Score」から「Score Model」を、作図領域にドラッグ アンド ドロップします。
「Train Model」の出力を「Score Model」の1つ目の入力、「Split Data」の2つ目の出力 (評価用データ) を「Score Model」の1つ目の入力とします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(56).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.24 ツール パレットの「Machine Learning」の中の「Evaluate」から「Evaluate Model」を、作図領域にドラッグ アンド ドロップします。
「Score Model」の出力を「Evaluate Model」入力とします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(58).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

### 3.25 「RUN」します。
上から順番に動作していき、成功すると緑のチェックが付きます。
全部が完了するまで、待ちましょう。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(59).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

## 3.26 「RUN」が完了したら、結果を確認してみましょう。
「Evaluate Model」を右クリックし、「Evaluation results」から「Visualize」をクリックします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(60).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

## 3.27 「Accuracy」が 0.571 などと表示されているのが分かります。57% の精度で予測できたようです。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(61).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")

---
## <a id="section4"></a>4. [Microsoft Azure Machine Learning Studio](https://studio.azureml.net) でマシーンラーニング (機械学習) したモデルから API を作成

## 4.1 学習済みのモデルから、API を作ってみましょう。
画面下部の「Predictice Web Service」をクリックします。

![Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(62).png?raw=true "Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成")

## 4.2 「Predictice Experiment」というタブが作られます。
画面下部の「RUN」をクリックしてみましょう。
すべての実行が終わるまで待ちましょう。

![Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(77).png?raw=true "Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成")

## 4.3 すべての実行が完了したら、画面下部の「DEPLOY WEB SERVICE」をクリックしてみます。

![Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(78).png?raw=true "Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成")

## 4.4 学習済みモデルを利用した API が作られます。
API を呼び出すための「API key」が表示されます。
また、画面左下の「API HELP PAGE」 - 「REQUEST/RESPONSE」をクリックすると、作られた API の使い方を見ることができます。

![Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(79).png?raw=true "Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成")

## 4.5 API の使い方が表示されます。

![Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(80).png?raw=true "Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成")

例えば、呼び出すときに入力として渡す JSON の例が示されています。
ただし、この API の入力には15日分の株価を必要としますので、Values は、大きさ15の配列にする必要があります。

![Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(81).png?raw=true "Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成")

また、同じページの下部の方には、C#、Python、R のサンプル コードが示されています。

![Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(82).png?raw=true "Microsoft Azure Machine Learning Studio でマシーンラーニング (機械学習) したモデルから API を作成")

---
## <a id="section5"></a>5. C# から API を呼んでみるテスト

上述の API の使い方のページに示された C# のサンプル コードをベースに、作成したものが、本レポジトリーの中の PredictStockPrice.Console/Program.cs です。

このコード中の、

const string apiKey = "your api key"; // Replace this with the API key for the web service

の apiKey の値は、ご自身の API の使い方のページに示された「API key」を入力します。

また、

client.BaseAddress = new Uri("your api URI"); // Replace this with the URI for the web service

には、ご自身の API の使い方のページの「API HELP PAGE」 - 「REQUEST/RESPONSE」をクリックして表示されたページの中の C# のサンプル コード中の、

client.BaseAddress = new Uri("XXX");

の行をコピーしてお使いください。


---

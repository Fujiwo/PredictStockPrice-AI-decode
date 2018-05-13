# PredictStockPrice-AI-decode
PredictStockPrice Sample for Microsoft de:code 2018 AI sessions

Azure Machine Learning Studio による株価予想プログラム

### 概要:
Azure Machine Learning Studio 上で、株価データを Python で加工し、機械学習させ、API を作成し、Web アプリケーションから JavaScript で使ってみるところまでのチュートリアル。

### 狙い:
Azure Machine Learning Studio を使って簡単に機械学習を利用した API が作れ、自分のアプリケーションで利用できるようになる。

=======
## 1. SQL データベースの作成

### 1.1 [Azure ポータル](https://portal.azure.com) にサインインして、SQL データベースを作成します。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(04).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.2 「データベース名」を入力し、「サブスクリプション」を選択、「リソースグループ」を入力し、サーバーの構成を行います。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(06).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.3 「価格レベル」を設定し、「作成」します。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(07).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.4 作成されたデータベースの「接続文字列」を確認してみましょう。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(08).png?raw=true "SQL データベースの作成 | Microsoft Azure")

### 1.5 サーバー名などが含まれた「接続文字列」が確認できます。

![SQL データベースの作成 | Microsoft Azure](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(10).png?raw=true "SQL データベースの作成 | Microsoft Azure")

# PredictStockPrice-AI-decode
PredictStockPrice Sample for Microsoft de:code 2018 AI sessions

[Microsoft Azure Machine Learning Studio](https://studio.azureml.net) による株価予想プログラム

### 概要:
Microsoft Azure Machine Learning Studio 上で、株価データを Python で加工し、機械学習させ、API を作成し、Web アプリケーションから JavaScript で使ってみるところまでのチュートリアル。

### 狙い:
Azure Machine Learning Studio を使って簡単に機械学習を利用した API が作れ、自分のアプリケーションで利用できるようになる。

=======
## 1. SQL データベースの作成

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

## 2. SQL データベースへのデータのアップロード

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

## 3. [Microsoft Azure Machine Learning Studio](https://studio.azureml.net) によるマシーンラーニング (機械学習)

### 3.1 [Microsoft Azure Machine Learning Studio](https://studio.azureml.net) にサインインします。
料金プランを選びます。ここでは、「Free Workspace」を選ぶことにします。

![Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)](https://github.com/Fujiwo/PredictStockPrice-AI-decode/blob/master/images/2018-05-12%20(18).png?raw=true "Microsoft Azure Machine Learning Studio によるマシーンラーニング (機械学習)")



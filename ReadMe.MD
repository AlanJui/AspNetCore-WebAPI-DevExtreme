# 專案指引

本專案所開發之 Web API Service ，主要目的為搭配 Web 前端工具 DevExtreme 所用。

專案特性：
 - ASP.NET Core 2.0
 - 採用 RESTful Web API Service 標準
 - 搭配 DevExtreme 17.1 符合其對 CustomStore 所做之規範
 - 資料庫 MS SQL Server

為能正常操作以下「步驟」，請依據「事前準備」章節，備妥應安裝之軟體套件及資料庫。


---


## 開發機作業程序

#### （1）下載原始程式檔案
```
$ git clone git@github.com:AlanJui/AspNetCore-WebAPI-DevExtreme.git
```

#### （2）進入專案資料夾
```
$ cd AspNetCore-WebAPI-DevExtreme.git
```

#### （3）安裝程式所需套件
```
$ dotnet restore
```

#### （4）編譯與組建（Build）程式
```
$ dotnet build
```

#### （5）啟動程式
```
$ dotnet run
```

#### （6）驗證程式已正常運作
使用 Web 瀏覽器，瀏覽網址： http://127.0.0.1:5000/api/orders


---


## 測試機作業流程


### 啟始作業程序

#### （1）進入專案資料夾根路徑
測試機的「啟始作業」，僅需執行一次。
```
$ git clone git@github.com:AlanJui/AspNetCore-WebAPI-DevExtreme.git
```

#### （2）建立測試機設定檔
為指定測試機所使用的 Port ，故需建立設定檔： `hosting.json` 。
```
$ touch hosting.json
```
【註】：以上指令，僅適用於 Mac OS X 或 Linux 作業平台。

`hosting.json` 設定檔需有以下內容：
```
{
  "urls": "http://0.0.0.0:5100"
}

```

為避免錯誤或為省事，亦可將專案的檔案 `hosting.json.staging` ，透過以下指令進行檔案名稱變更：
```
$ mv hosting.json.staging hosting.json
```


### 更新版本作業程序


#### （1）進入專案資料夾根路徑
```
$ cd AspNetCore-WebAPI-DevExtreme
```

#### （2）下載新版原始程式檔案
```
$ git pull
```

#### （3）安裝程式所需套件
```
$ dotnet restore
```

#### （4）編譯與組建（Build）程式
```
$ dotnet build
```

#### （5）啟動程式
```
$ dotnet run
```

#### （6）驗證程式已正常運作
使用 Web 瀏覽器，瀏覽網址： http://127.0.0.1:5100/api/orders

【註】：需注意「測試機」使用的 Port 為 5100 ；非預設的 5000 。


---


## 正式機作業程序

#### （1）進入專案資料夾根路徑
正式機的「啟始作業」，僅需執行一次。
```
$ git clone git@github.com:AlanJui/AspNetCore-WebAPI-DevExtreme.git
```


### 更新版本作業程序


#### （1）進入專案資料夾根路徑
```
$ cd AspNetCore-WebAPI-DevExtreme
```

#### （2）下載新版原始程式檔案
```
$ git pull
```

#### （3）安裝程式所需套件
```
$ dotnet restore
```

#### （4）編譯與組建（Build）程式
```
$ dotnet build
```

#### （5）啟動程式
```
$ dotnet run
```

#### （6）驗證程式已正常運作
使用 Web 瀏覽器，瀏覽網址： http://127.0.0.1:5000/api/orders


---


## 事前準備

### 編譯及執行程式
不論是：開發機（Development）、測試機（Staging）、正式機（Production），均須安裝以下所列之軟體：

 - [Git](https://git-scm.com/)
 - [.NET Core 2 SDK](https://www.microsoft.com/net/core)
 - [NodeJS & NPM](https://nodejs.org/en/)
 - [Bower](https://bower.io/) 

### 資料庫

Microsoft SQL Server 須與 Web API Service 安裝在同一台機器。使用的版本為 Microsoft SQL Server 2017 for Linux 。

由於範例使用「北風貿易公司」的資料，請於程式執行前，先將 Northwind 資料，Restore 到 MS SQL Server 的資料庫之中。


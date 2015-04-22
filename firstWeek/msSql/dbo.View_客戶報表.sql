USE [F:\保哥上課\MVC5\HOMEWORK\FIRSTWEEK\FIRSTWEEK\FIRSTWEEK\APP_DATA\客戶資料.MDF]
GO

/****** 物件: View [dbo].[View_客戶報表] 指令碼日期: 2015/4/22 下午 03:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_客戶報表]
AS
SELECT          Id, 客戶名稱,
                                (SELECT          COUNT(*) AS Expr1
                                  FROM               dbo.客戶銀行資訊 AS t1
                                  WHERE           (客戶Id = t0.Id)) AS 銀行數量,
                                (SELECT          COUNT(*) AS Expr1
                                  FROM               dbo.客戶聯絡人 AS t2
                                  WHERE           (客戶Id = t0.Id)) AS 聯絡人數量
FROM              dbo.客戶資料 AS t0

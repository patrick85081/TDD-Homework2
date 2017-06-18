# TDD-Homework2

## 題目情境
哈利波特一到五冊熱潮正席捲全球，世界各地的孩子都為之瘋狂。
出版社為了慶祝Agile Tour第一次在台灣舉辦，決定訂出極大的優惠，來回饋給為了小孩四處奔波買書的父母親們。
定價的方式如下：

1. 一到五集的哈利波特，每一本都是賣100元  

你的任務是，設計一個哈利波特的購物車，能提供最便宜的價格給這些爸爸媽媽。

#### Feature: PotterShoppingCart  
In order to 提供最便宜的價格給來買書的爸爸媽媽. As a 佛心的出版社老闆.I want to 設計一個哈利波特的購物車

#### Scenario: 第一集買了一本，其他都沒買，價格應為100*1=100元
- Given 第一集買了 1 本
- And 第二集買了 0 本
- And 第三集買了 0 本
- And 第四集買了 0 本
- And 第五集買了 0 本
- When 結帳
- Then 價格應為 100 元


#### 個人思路
此題目總共有五個測試需求，但是不是一次寫完，而是寫完一個Commit一次，用意應該是模擬現實狀況，需求是隨著時間出現，一開始的需求往往不是最後的結果。  

### 購物車API 設計思路  
一個商場可能會同時包含多種的價格計算方式(優惠價格)，所以我認為我應該將價格計算方式抽象出來定義一個```interface```，購物車內使用```IDictionary```來記錄購買商品以及數量。
```c#
IDictionary<Product, int> product;
```
設計此```interface```來計算商品金額  
```c#
/// <summary>  
/// 商品計算方式  
/// </summary>  
public interface ICalculate  
{  
    /// <summary>  
    /// 計算產品總金額  
    /// </summary>  
    /// <param name="products">購買產品清單及數量</param>  
    /// <returns>總金額</returns>  
    double Calculate(IDictionary<Product, int> products);  
}  
```
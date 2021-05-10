# Day1 


## 界面结构
#### 主场景
button：点击打开商店；

#### 商店界面
在 Panel 控件下加入 Scroll View 作主界面，Text 作标题。

在 Scroll View 中的 Content 加上 Grid Layout Group 排序组件。

### Prefab
包括商品 Prefab 和 商店页面 Prefab。

### Hierachy
Canvas 下应包括 主界面的 Button 按钮，商店页面（StorePanel）。

在StorePanel 页面下有 Scroll View 控件和 标题 Text。

Scroll View 中的 Content 应该包括所有的 Card，实例化生成的 Card 设父对象为 Content。

Card ： 包括购买按钮、花费 text 等等。

### Script

#### UI相关
HomePages: 打开商店面板。

DailyItem：商品属性，包括花费、数量等等和物品购买操作。

StoreDialog：商店页面，包括标题，倒计时、页面等开关和商品等加载等。

#### 数据相关
ItemConfig：商品数据，从Json文件中解析数据放入列表。

RewardType：数据参数。

#### Utils
SimpleJSON：json解析文件。

TimeUtils：使用协程实现倒计时操作。

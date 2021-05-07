# Day1 


## 界面结构
#### 主场景
button：点击打开商店；

#### 商店界面
在 Panel 控件下加入 Scroll View 作主界面，Text 作标题。
在 Scroll View 中的 Content 加上 Grid Layout Group 排序组件。

### Prefab
将 Card 部分做成 Prefab，在打开商店页面的时候实例化 prefab。
根据 Json 文件中的数据 生成不同的 Card。

### Hierachy
Canvas 下应包括 主界面的 Button 按钮，商店页面（StorePanel）。
在Store 页面下有 Scroll View 控件和 标题 Text。
Scroll View 中的 Content 应该包括所有的 Card，实例化生成的 Card 设父对象为 Content。
Card : 包括购买按钮、花费 text、image等等。

### Script
Click：包含对商店页面的控制，，放入 Button 的 Click 方法，在此方法中包含 商店页面的初始化即实例化生成 Card。根据 Json 数据调整 Card 的相关属性。

Save：数据存储类，即保存 Json 数据的参数，序列化。

Purchase：购买操作，完成对 Card 的控制。包含对 Card 组件对获取和控制。

![](Pictures/Day1.jpg)
# Reaction Tester - Unity设置指南

## 第一步：打开项目

1. 打开Unity Hub
2. 点击"Add"按钮
3. 选择此项目文件夹
4. 使用Unity 2020.3或更高版本打开

## 第二步：设置场景

### 创建游戏管理器对象

1. 在Unity中打开 `Assets/Scenes/MainScene.unity（如果已创建）
2. 或创建新场景：File → New Scene → 2D

### 创建UI界面

按照以下步骤创建UI：

#### 1. 创建Canvas
- 右键 Hierarchy → UI → Canvas
- 设置 Canvas Scaler: UI Scale Mode = "Scale With Screen Size"
- Reference Resolution: 1920x1080

#### 2. 创建背景
- 右键 Canvas → UI → Image
- 命名为 "Background"
- 设置颜色为深灰色 (0.2, 0.2, 0.2)
- 拉伸到全屏

#### 3. 创建文本元素
创建以下Text元素（右键 Canvas → UI → Text：

**TitleText:**
- 位置: (0, 300)
- 字体大小: 60
- 文本: "反应力测试"
- 对齐: 居中

**InstructionText:**
- 位置: (0, 150)
- 字体大小: 36
- 文本: "点击开始按钮开始测试"
- 对齐: 居中

**ResultText:**
- 位置: (0, 0)
- 字体大小: 100
- 字体样式: Bold
- 文本: ""
- 对齐: 居中

**ScoreText:**
- 位置: (-600, 0)
- 字体大小: 24
- 对齐: 左上
- 文本: ""

**BestScoreText:**
- 位置: (0, -400)
- 字体大小: 28
- 字体样式: Bold
- 颜色: 黄色
- 对齐: 居中

#### 4. 创建按钮
创建以下Button（右键 Canvas → UI → Button）：

**StartButton:**
- 位置: (0, -200)
- 大小: 250x80
- 按钮文本: "开始"
- 按钮颜色: 绿色

**ResetButton:**
- 位置: (0, -300)
- 大小: 250x80
- 按钮文本: "重置"
- 按钮颜色: 红色

#### 5. 创建点击区域
- 右键 Canvas → UI → Image
- 命名为 "ClickArea"
- 拉伸到全屏
- 颜色: 白色，透明度 5%
- 初始状态: 禁用

### 添加脚本

1. 将 `ReactionTester.cs` 拖到场景中的任意对象上（或创建空对象命名为 "GameManager"）
2. 在Inspector中连接所有UI引用：
   - Title Text: 拖入 TitleText
   - Instruction Text: 拖入 InstructionText
   - Result Text: 拖入 ResultText
   - Score Text: 拖入 ScoreText
   - Best Score Text: 拖入 BestScoreText
   - Start Button: 拖入 StartButton
   - Reset Button: 拖入 ResetButton
   - Background Image: 拖入 Background
   - Click Area: 拖入 ClickArea

## 第三步：保存和测试

1. File → Save Scene As → 保存为 "MainScene"
2. 点击 Play 按钮测试游戏
3. 点击"开始"按钮开始测试

## 提示

- 确保相机设置为 Orthographic 视角
- 检查所有UI引用都已正确连接
- 测试时注意观察颜色变化（灰色→黄色→绿色）

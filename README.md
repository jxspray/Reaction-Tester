# Reaction Tester

反应力测试游戏 - 测试你的反应速度！

## 游戏特性

- 🎮 简单直观的游戏玩法
- ⏱️ 精确的毫秒级计时
- 📊 多轮测试和成绩统计
- 🏆 历史最佳成绩记录
- 🎨 美观的彩色UI界面

## 游戏玩法

1. 点击"开始"按钮开始游戏
2. 等待屏幕变绿（黄色表示准备阶段）
3. 屏幕变绿后立即点击屏幕或按空格键
4. 重复5轮测试
5. 查看你的平均成绩和最佳成绩

## 项目结构

```
Assets/
├── Scripts/
│   └── ReactionTester.cs  # 核心游戏逻辑
├── Scenes/
│   └── MainScene.unity     # 主场景
├── Prefabs/
├── Resources/
├── Materials/
└── Fonts/
```

## 开发说明

使用Unity 2020或更高版本打开此项目。

### 核心脚本 - ReactionTester.cs

主要功能：
- 游戏状态管理
- 反应时间测量
- 成绩统计和记录
- UI界面控制

### 可配置参数

在ReactionTester组件中可以调整：
- `minWaitTime`: 最小等待时间（秒）
- `maxWaitTime`: 最大等待时间（秒）
- `maxAttempts`: 测试轮数

## 技术栈

- Unity 3D
- C#
- Unity UI

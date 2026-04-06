# Reaction Tester - 快速入门指南

## 🚀 最简单的使用方式

### 方法一：使用自动设置（推荐）

1. 在Unity中打开这个项目
2. 创建一个新场景
3. 创建一个空游戏对象，命名为 "Bootstrap"
4. 给 "Bootstrap" 对象添加以下脚本：
   - `SceneSetup`
   - `AutoSetup`
5. 点击 Play 按钮！

### 方法二：手动设置

详细步骤请参考 [SETUP_GUIDE.md](file:///workspace/SETUP_GUIDE.md)

## 📁 项目文件说明

### 核心脚本

- [ReactionTester.cs](file:///workspace/Assets/Scripts/ReactionTester.cs) - 主要游戏逻辑
- [SceneSetup.cs](file:///workspace/Assets/Scripts/SceneSetup.cs) - 自动创建场景和UI
- [AutoSetup.cs](file:///workspace/Assets/Scripts/AutoSetup.cs) - 自动连接所有组件

### 配置文件

- [ProjectSettings.asset](file:///workspace/ProjectSettings/ProjectSettings.asset) - Unity项目设置
- [manifest.json](file:///workspace/Packages/manifest.json) - 包管理配置

## 🎮 游戏特性

- 5轮测试
- 毫秒级精度计时
- 历史最佳成绩记录
- 彩色UI反馈
- 键盘和鼠标支持

## ⌨️ 操作说明

- **开始/重置**：点击对应按钮
- **测试反应**：当屏幕变绿时，点击鼠标或按空格键
- **太早点击**：屏幕变红，本次无效

## 🛠️ 自定义设置

在Unity编辑器中选择 ReactionTester 组件，可以调整：

- `Min Wait Time` - 最小等待时间（秒）
- `Max Wait Time` - 最大等待时间（秒）
- `Max Attempts` - 测试轮数
- 各种颜色设置

## 📝 注意事项

- 需要Unity 2020.3或更高版本
- 确保项目使用TextMeshPro或标准UI Text
- 首次运行会自动创建所有需要的UI元素

## 🎯 下一步

1. 打开Unity Hub
2. 添加此项目
3. 按上述方法设置场景
4. 开始测试你的反应力！

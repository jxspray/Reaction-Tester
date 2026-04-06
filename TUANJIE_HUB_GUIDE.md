# Tuanjie Hub 导入指南

## 📱 如何导入到 Tuanjie Hub

### 方法一：从 GitHub 克隆（推荐）

1. 打开 Tuanjie Hub
2. 点击 "导入项目"
3. 选择 "从 Git 克隆"
4. 输入仓库地址：`https://github.com/jxspray/Reaction-Tester.git`
5. 选择分支：`master`
6. 点击 "克隆" 开始导入

### 方法二：本地导入

1. 下载项目压缩包
2. 解压到本地文件夹
3. 打开 Tuanjie Hub
4. 点击 "导入项目"
5. 选择 "本地导入"
6. 选择解压后的项目文件夹
7. 点击 "导入"

## 🛠️ 项目配置检查

### 必要文件

- ✅ `Assets/` 文件夹 - 包含所有游戏资源
- ✅ `Packages/` 文件夹 - 依赖包配置
- ✅ `ProjectSettings/` 文件夹 - 项目设置
- ✅ `ProjectSettings/ProjectVersion.txt` - Unity版本信息
- ✅ `ProjectSettings/EditorSettings.asset` - 编辑器设置（已配置为2D模式）
- ✅ `ProjectSettings/ProjectSettings.asset` - 项目全局设置

### 依赖项

项目包含以下核心依赖：

- `com.unity.ugui` - UI系统
- `com.unity.modules.core` - 核心模块
- `com.unity.modules.engine` - 引擎模块
- `com.unity.modules.physics2d` - 2D物理（备用）
- `com.unity.modules.ui` - UI模块
- `com.unity.modules.imgui` - IMGUI界面
- `com.unity.modules.unityanalytics` - 分析模块
- `com.unity.modules.unitywebrequest` - 网络请求
- `com.unity.modules.jsonserialize` - JSON序列化

## 🎮 首次运行步骤

1. **导入项目**后，等待Unity导入所有资源
2. **打开场景**：选择 `Assets/Scenes/Bootstrap.unity`
3. **运行游戏**：点击Play按钮
4. **开始测试**：点击"开始"按钮开始反应力测试

## ⚠️ 注意事项

1. **Unity版本**：推荐使用 Unity 2020.3 或更高版本
2. **网络连接**：导入时需要网络连接以下载依赖
3. **权限**：确保有足够的磁盘空间和文件权限
4. **防火墙**：如果导入失败，检查防火墙设置

## 📞 故障排除

### 导入失败
- 检查网络连接
- 确认GitHub仓库地址正确
- 尝试使用不同的Unity版本

### 运行错误
- 检查控制台错误信息
- 确保所有依赖都已正确导入
- 尝试重新导入项目

### UI显示问题
- 检查Canvas设置
- 确保UI元素位置正确
- 调整屏幕分辨率

## 🎯 项目特性

- ✅ 2D模式配置
- ✅ 自动场景设置
- ✅ 完整的反应力测试功能
- ✅ 毫秒级计时
- ✅ 历史最佳成绩记录
- ✅ 彩色UI反馈

## 📧 支持

如果遇到导入问题，请参考此指南或联系技术支持。

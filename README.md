<h1 align="center">clear-image-action</h1>

> 🔧 Clean up unreferenced images. | 清理未引用图片 | GitHub Actions

[![repo size](https://img.shields.io/github/repo-size/yiyungent/clear-image-action.svg?style=flat)]()
[![LICENSE](https://img.shields.io/github/license/yiyungent/clear-image-action.svg?style=flat)](https://github.com/yiyungent/clear-image-action/blob/main/LICENSE)


## 介绍

Clean up unreferenced images. | 清理未引用图片 | GitHub Actions

## 功能

- [x] 清理未引用图片
  - 自动扫描仓库指定文件夹, 发起 `Pull Request`: 图片扫描报告
- [] 检查 引用的图片 是否有效
  - [x] 检查 引用的本地图片 是否存在
  - [] 检查 引用的网络图片 是否有效 (200 非 404)

## 使用

### 创建 clear-image.yml

> .github/workflows/clear-image.yml

```yml
name: clear-image

on:
  push:
    branches: [main] # 注意更改为你的 branch, 例如 master

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout source
        uses: actions/checkout@v2

      - name: Clear image
        uses: yiyungent/clear-image-action@main
        with:
          # 默认为空, 即为仓库根目录
          scan_directory: ""
          # 多个路径之间用 英文逗号 , 隔开, 用相对于仓库根目录的 相对路径
          ignore_paths: ""

```

![](screenshots/1.png)


## Related Projects

- [yiyungent/coo: 🧰 .NET 自用CLI, 工具集](https://github.com/yiyungent/coo)    
  - 本项目 核心依赖


## Donate

clear-image-action is an MIT licensed open source project and completely free to use. However, the amount of effort needed to maintain and develop new features for the project is not sustainable without proper financial backing.

We accept donations through these channels:
- <a href="https://afdian.net/@yiyun" target="_blank">爱发电</a>

## Author

**clear-image-action** © [yiyun](https://github.com/yiyungent), Released under the [MIT](./LICENSE) License.<br>
Authored and maintained by yiyun with help from contributors ([list](https://github.com/yiyungent/clear-image-action/contributors)).

> GitHub [@yiyungent](https://github.com/yiyungent) Gitee [@yiyungent](https://gitee.com/yiyungent)



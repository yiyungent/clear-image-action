<h1 align="center">upyun-action</h1>

> ☁️ upyun | 又拍云 | GitHub Actions

[![repo size](https://img.shields.io/github/repo-size/yiyungent/upyun-action.svg?style=flat)]()
[![LICENSE](https://img.shields.io/github/license/yiyungent/upyun-action.svg?style=flat)](https://github.com/yiyungent/upyun-action/blob/master/LICENSE)


## 介绍

upyun | 非官方 | 又拍云 for GitHub Actions

## 功能

- [x] 批量刷新缓存
  - 利用 GitHub Actions 在更新博文等 后 立即刷新缓存

## 使用

### 创建 upyun-refresh.yml

> .github/workflows/upyun-refresh.yml

```yml
name: upyun refresh

on:
  push:
    branches: [main] # 注意更改为你的 branch, 例如 master

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Upyun Refresh
        uses: yiyungent/upyun-action@main
        with:
          # 在 Settings->Secrets 配置 UPYUN_USERNAME, UPYUN_PASSWORD
          upyun_username: ${{ secrets.UPYUN_USERNAME }}
          upyun_password: ${{ secrets.UPYUN_PASSWORD }}
          # 要刷新的url, 支持匹配符 *, 多个url中间用 \n 隔开
          refresh_cache_urls: "https://moeci.com/posts/*\nhttps://moeci.com/about"

```

### 注意

> 如果你使用的是 Hexo 等部署, 源代码在此仓库, 那么需要在部署完后再刷新缓存, 例如下方:       
> 利用 GitHub Actions 发布 Hexo, 然后再刷新又拍云CDN   

```yml
name: Build and Deploy Hexo
on:
  push:
    branches:
      - master
jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    steps:
    - name: Checkout 🛎️
      uses: actions/checkout@master
      
    - name: Use Node.js 12
      uses: actions/setup-node@v2-beta
      with:
        node-version: '12'

    - name: Install Pandoc
      run: |
        sudo apt-get install pandoc
        
    - name: Install and Build 🔧 
      run: |
        npm install -g hexo-cli
        npm install
        hexo clean
        hexo generate

    - name: Deploy 🚀
      uses: JamesIves/github-pages-deploy-action@3.7.1
      with:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
        BRANCH: gh-pages
        FOLDER: public

    - name: Upyun Refresh
      uses: yiyungent/upyun-action@main
      with:
        # 在 Settings->Secrets 配置 UPYUN_USERNAME, UPYUN_PASSWORD
        upyun_username: ${{ secrets.UPYUN_USERNAME }}
        upyun_password: ${{ secrets.UPYUN_PASSWORD }}
        # 要刷新的url, 支持匹配符 *, 多个url中间用 \n 隔开
        refresh_cache_urls: "https://moeci.com/*"

```



## Donate

upyun-action is an MIT licensed open source project and completely free to use. However, the amount of effort needed to maintain and develop new features for the project is not sustainable without proper financial backing.

We accept donations through these channels:
- <a href="https://afdian.net/@yiyun" target="_blank">爱发电</a>

## Author

**upyun-action** © [yiyun](https://github.com/yiyungent), Released under the [MIT](./LICENSE) License.<br>
Authored and maintained by yiyun with help from contributors ([list](https://github.com/yiyungent/upyun-action/contributors)).

> GitHub [@yiyungent](https://github.com/yiyungent) Gitee [@yiyungent](https://gitee.com/yiyungent)



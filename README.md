<h1 align="center">clear-image-action</h1>

> ð§ Image detection. | å¾çæ£æµ | GitHub Actions

[![repo size](https://img.shields.io/github/repo-size/yiyungent/clear-image-action.svg?style=flat)]()
[![LICENSE](https://img.shields.io/github/license/yiyungent/clear-image-action.svg?style=flat)](https://github.com/yiyungent/clear-image-action/blob/main/LICENSE)
[![QQ Group](https://img.shields.io/badge/QQ%20Group-894031109-deepgreen)](https://jq.qq.com/?_wv=1027&k=q5R82fYN)


> æ³¨æ: æ¬é¡¹ç®éç¨ `Star License + MIT License`, ä½ å¿é¡» Star æ¬é¡¹ç® æè½å¨ä½ çä»åºä¸­è¿è¡æ¬ GitHub Action

## ä»ç»

ä½¿ç¨ `GitHub Action` èªå¨æ£æµä½ ä»åºå ç±äºè¯¯å ,å¾åºå¤±æç­å¯¼è´çå¼ç¨æ æ,è®©ä½ ç¬¬ä¸æ¶é´äºè§£ä¸¢å¤±äºåªäºå¾ç;èªå¨æ¸çæ ç¨åä½åå¾å¾ç,æ éåæå¨ç®¡çå¾ç, æ¸é¤æ ç¨å¾çã

## åè½

- [x] èªå¨æ«æä»åºæå®æä»¶å¤¹, åèµ· `Pull Request`: å¾çæ«ææ¥å
- [x] æ¸çæªå¼ç¨å¾ç
  - ä»¥ `Pull Request` å½¢å¼åèµ·, åªæä½ åæåå¹¶å, æ¸çæçæ
- [x] æ£æ¥ å¼ç¨çå¾ç æ¯å¦ææ
  - [x] æ£æ¥ å¼ç¨çæ¬å°å¾ç æ¯å¦å­å¨
  - [x] æ£æ¥ å¼ç¨çç½ç»å¾ç æ¯å¦ææ (200 é 404)

## ä½¿ç¨

### åå»º clear-image.yml

> .github/workflows/clear-image.yml

```yml
name: clear-image

on:
  push:
    branches: [main] # æ³¨ææ´æ¹ä¸ºä½ ç branch, ä¾å¦ master

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout source
        uses: actions/checkout@v2

      - name: Clear image
        uses: yiyungent/clear-image-action@main
        with:
          # é»è®¤ä¸ºç©º, å³ä¸ºä»åºæ ¹ç®å½
          scan_directory: ""
          # å¤ä¸ªè·¯å¾ä¹é´ç¨ è±æéå· , éå¼, ç¨ç¸å¯¹äºä»åºæ ¹ç®å½ç ç¸å¯¹è·¯å¾
          ignore_paths: ""

```

## Screenshots

> é¨å `Pull Request` æªå¾

![](screenshots/1.png)


## Related Projects

- [yiyungent/coo: ð§° .NET èªç¨CLI, å·¥å·é](https://github.com/yiyungent/coo)    
  - æ¬é¡¹ç® æ ¸å¿ä¾èµ


## Donate

clear-image-action is an MIT licensed open source project and completely free to use. However, the amount of effort needed to maintain and develop new features for the project is not sustainable without proper financial backing.

We accept donations through these channels:
- <a href="https://afdian.net/@yiyun" target="_blank">ç±åçµ</a>

## Author

**clear-image-action** Â© [yiyun](https://github.com/yiyungent), Released under the [MIT](./LICENSE) License.<br>
Authored and maintained by yiyun with help from contributors ([list](https://github.com/yiyungent/clear-image-action/contributors)).

> GitHub [@yiyungent](https://github.com/yiyungent) Gitee [@yiyungent](https://gitee.com/yiyungent)



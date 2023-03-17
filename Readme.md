# [Netizen.ID](https://github.com/chenshenchao/netizen-id)

一个生成ID的库。

- Int64IDMaker 64位
- Char24IDMaker 24字符

## 示例

```bat
@rem 通过 dotnet 命令安装
dotnet add package Netizen.ID

@rem 通过 Packager Manager 命令安装
NuGet\Install-Package Netizen.ID
```

```csharp
Int64IDMaker i64mkr = new Int64IDMaker();
long iid = i64mkr.Make();

Char24IDMaker c24mkr = new Char24IDMaker();
string sid = c24mkr.Make();
```

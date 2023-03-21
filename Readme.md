# [Netizen.ID](https://github.com/chenshenchao/netizen-id)

一个生成ID的库。

- Int64IDMaker 64位
- Char20PlusIDMaker 24字符

## 示例

```bat
@rem 通过 dotnet 命令安装
dotnet add package Netizen.ID

@rem 通过 Packager Manager 命令安装
NuGet\Install-Package Netizen.ID
```

```csharp
Int64IDMaker i64mkr = new Int64IDMaker(1);
long iid = i64mkr.Make();

Char20PlusIDMaker c20pmkr = new Char20PlusIDMaker("netz");
string sid = c20pmkr.Make();

Byte10IDMaker b10mkr = new Byte10IDMaker(1);
byte[] = b10mkr.Make();

Charset32IDMaker c32mkr = new Charset32IDMaker(1);
string c32id = c32mkr.Make();
```

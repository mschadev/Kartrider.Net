# Kartrider.Net
[![standard-readme compliant](https://img.shields.io/badge/standard--readme-OK-green.svg)](https://github.com/RichardLitt/standard-readme)
![example workflow](https://github.com/zxc010613/Kartrider.Net/actions/workflows/dotnet.yml/badge.svg)
![](https://img.shields.io/nuget/dt/Kartrider.Api)


카트라이더 OPEN API 라이브러리  
**특징**   
+ [HttpClient](https://docs.microsoft.com/ko-kr/dotnet/api/system.net.http.httpclient?view=netcore-3.1)클래스 사용
+ [NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md)
+ [RiotSharp](https://github.com/BenFradet/RiotSharp) 라이브러리의 디렉터리 구조, Http Requester를 참고함.

| Package                       | Description                                          | Link |
|-------------------------------|------------------------------------------------------|------|
| Kartrider.Api           | Nexon Kartrider OPEN API wrapper library.         |   ![](https://img.shields.io/nuget/vpre/Kartrider.Api)   |
| Kartrider.Api.AspNetCore | Nexon Kartrider OPEN API wrapper library for ASP.NET Core.     |   ![](https://img.shields.io/nuget/vpre/Kartrider.Api.AspNetCore)   |
  
해당 프로젝트의 ![](https://img.shields.io/nuget/vpre/Kartrider.Api)은 0.X.X버전입니다.  
1.0.0이상 Release시, 최신버전인 [kartrider.api.net](https://github.com/zxc010613/kartrider.api.net) `1.0.6`은 삭제됩니다.
## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainers](#maintainers)
- [Contributing](#contributing)
- [License](#license)

## Install

```sh
## If ASP.NET Core env.
Install-Package Kartrider.Api.AspNetCore -Version 0.1.0
## Otherwise
Install-Package Kartrider.Api -Version 0.1.0
```

## Usage
```cs
using Kartrider.Api;
using Kartrider.Api.Endpoints.UserEndpoint;

using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IKartriderApi kartriderApi = KartriderApi.GetInstance("API_KEY");
            User user = await kartriderApi.User.GetUserByNicknameAsync("extern");
            Console.WriteLine($"Nickname: {user.Nickname}");
            Console.WriteLine($"Level: {user.Level}");
            Console.WriteLine($"AccessId: {user.AccessId}");
        }
    }
}
```
## Maintainers

[@zxc010613](https://github.com/zxc010613)

## Contributing

PRs accepted.

## License
[MIT](./LICENSE)

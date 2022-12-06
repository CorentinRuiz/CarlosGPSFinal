msbuild %~dp0\CarlosGPS\Server\Server.sln

start %~dp0CarlosGPS\Server\ProxyCache\bin\Debug\ProxyCache.exe

start %~dp0CarlosGPS\Server\RoutingServer\bin\Debug\RoutingServer.exe

activemq start
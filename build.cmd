@echo off

if not exist nuget.exe (
  echo Unable to find nuget.exe
  exit
) 

nuget restore packages.config -PackagesDirectory OpenCover

dotnet restore OpenCover\OpenCover.sln

dotnet build OpenCover\OpenCover.sln -c release

OpenCover\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:"dotnet.exe" -targetargs:"test OpenCover\OpenCover.Tests\OpenCover.Tests.csproj --no-build -c release" -register:user -threshold:10 -oldStyle -safemode:off -output:.\Coverage.xml -hideskipped:All  -returntargetcode" 

SET PATH=C:\\Python34;C:\\Python34\\Scripts;%PATH%
pip install codecov
codecov -f "Coverage.xml"
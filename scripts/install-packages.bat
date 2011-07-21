@echo off
set SCRIPT_DIR=%~dp0
set NUGET=%SCRIPT_DIR%..\tools\NuGet\NuGet.exe
set PACKAGES=%SCRIPT_DIR%..\src\packages.config
set DESTINATION=%SCRIPT_DIR%..\lib\
set DEFAULT_FEED="https://go.microsoft.com/fwlink/?LinkID=206669"

echo [Installing NuGet Packages]
if NOT EXIST %DESTINATION% mkdir %DESTINATION%

%NUGET% install %PACKAGES% -o %DESTINATION% -Source %DEFAULT_FEED%

echo.
echo Done

@echo off

ECHO Checking publish prerequisites met&ECHO.
SET nugetCmd=nuget.exe
where nuget.exe
IF NOT ERRORLEVEL 1 (
	GOTO nuget_found
)

for /f "tokens=* delims=" %%A in ('where /r "%CD%" nuget') do (
	set foundNuget=1
    set nugetCmd=%%A
)

IF NOT DEFINED foundNuget ECHO.&ECHO nuget.exe not found on path or recursively from executing folder&Exit /B 1
:nuget_found

IF [%GSMANUGETAPIKEY%] EQU [] (
	ECHO.&ECHO No nuget api key for GSMA saved, set environment variable to GSMANUGETAPIKEY
	EXIT /B 1
)

ECHO.&ECHO Packaging for Nuget&ECHO.
%nugetCmd% pack %~dp0GSMA.MobileConnect.csproj -Build -IncludeReferencedProjects -Properties Configuration=Release

IF ERRORLEVEL 1 (
	ECHO.&ECHO Nuget pack failed
	EXIT /B 1
)

ECHO.&ECHO Publishing to Nuget&ECHO.
%nugetCmd% push "%~dp0GSMA.MobileConnect.*.*.*.*.nupkg" %GSMANUGETAPIKEY% -Source nuget.org

IF ERRORLEVEL 1 (
	ECHO.&ECHO Nuget push failed
	EXIT /B 1
)

XCOPY "GSMA.MobileConnect.*.nupkg" "%~dp0..\NugetPublished\" /Y
DEL "GSMA.MobileConnect.*.nupkg"

@echo off
if "%1"=="" goto usage

SET SOURCE=bin\Release\Organization-%1
SET TARGET=bin\Staging-%1

del %TARGET% /s /q

xcopy bin\Release\ShomreiTorah.Billing.exe %TARGET%\ 
xcopy bin\Release\ShomreiTorah.Billing.exe.config %TARGET%\ 
xcopy bin\Release\*.dll %TARGET%\ 
xcopy %SOURCE%\* %TARGET%\ /s

goto :EOF

:usage
echo Usage:
echo   Create-Staging ^<Organization Name^>
echo Creates a Staging-Name directory with all files from Release and Release\Organization-Name
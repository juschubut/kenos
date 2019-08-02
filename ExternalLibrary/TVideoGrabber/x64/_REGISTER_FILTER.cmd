@ECHO OFF

rem _____________________________________________________________________
rem 
rem               Directshow filters registration utility
rem                            v2.3.161003
rem 
rem                    Copyright ©2016 Datastead
rem
rem  USAGE:
rem
rem  . copy __REGISTER_FILTERS.cmd, __UNREGISTER_FILTERS.cmd and
rem    _RegisterFilter.cmd into the folder where are located the .ax files
rem
rem  . run __REGISTER_FILTERS.cmd to register the filters
rem
rem  . run __UNREGISTER_FILTERS.cmd to register the filters
rem 
rem  (right-click "Run as Administrator") 
rem
rem _____________________________________________________________________

FOR /F "usebackq delims==" %%D IN ('%0') DO SET CURDRV=%%~dD
FOR /F "usebackq delims==" %%R IN ('%0') DO SET CURDIR=%%~spR
if "%CURDRV%" == "\\" goto NOTTHERE
if "%CURDIR%" == "\Windows\" goto NOTTHERE
if "%CURDIR%" == "\Windows\System32\" goto NOTTHERE
if "%CURDIR%" == "\Windows\SysWOW64\" goto NOTTHERE
goto OK
:NOTTHERE
echo this utility must NOT be ran into the system's folders
goto END
:OK
%CURDRV%
CD "%CURDIR%"
FOR %%A IN ("Datastead*.ax") DO (
   regsvr32.exe /s "%CURDIR%%%A"
   if NOT ERRORLEVEL 1 ECHO %%A successfully registered.
   if ERRORLEVEL 1 ECHO !FAILED TO %3REGISTER %%A
)

if ERRORLEVEL 1 GOTO ERROR

Echo .
Echo The filters are successfully registered.
Echo .
GOTO END

:ERROR
Echo .
Echo THE REGISTRATION OF THE FILTERS FAILED.
Echo .
Echo - be sure to run this script as administrator (right-click "Run as Administrator")
Echo - Also verify if the filter .ax files are located in the script's folder
Echo .

:END
PAUSE



rem  copy_all.cmd "C:\dev\VER4.5.3.X\eMergeInteg\BC.NETCore\EbcNetCore\dist\" "C:\Program Files (x86)\Sapiens\eMerge Client Tools\ebc\"
@echo off

@echo Argument src folder: %1
@echo Argument ebc folder: %2
echo.

if [%1]==[] goto:blank
if [%2]==[] goto:blank

xcopy %1EbcNetCore.dll %2Core /f /i /y /s
xcopy %1EbcNetCore.pdb %2Core /f /i /y /s

xcopy %1log4net.dll %2Core /f /i /y /s
xcopy %1log4net.xml %2Core /f /i /y /s
xcopy .\EbcNetCore.log4net.config %2Core /f /i /y /s


goto:eof

:blank
echo "Usage: copy_all.cmd <Source> <Destination>" 
echo "	<Source> - is a Folder containing the compiled Framework Projects." 
echo "	<Destination> - is sapiens ebc a Folder." 
echo.


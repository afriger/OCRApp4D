rem echo off
"c:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe" OCRApp4D.csproj /property:Configuration=release;OutDir=../dist

xcopy ..\dist\OCRApp4D.exe  C:\dev\tools\OCR\4DC  /f /i /y /s
xcopy ..\dist\OCRApp4D.pdb  C:\dev\tools\OCR\4DC  /f /i /y /s


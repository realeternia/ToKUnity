cd ..\Config

IF NOT EXIST ".\ConfigData" MD ".\ConfigData"

ExcelToCsv.exe
cd .\ConfigData
csc /target:library /r:../NarlonLib.dll /r:../BaseType.dll /out:../ConfigData.dll *.cs
if not "%ERRORLEVEL%" == "0" GOTO :ERROR

cd ..
copy "./ConfigData.dll" "../Client/Assets/plugins/"
@copy "./ConfigData.dll" "../Tool/bin/"

GOTO :END

:ERROR
@ECHO COMPILATION FAILED
PAUSE

:END

@ECHO OFF

SET SrcFolder=C:\Code\Utilities\LogViewer\src\bin\Release
SET DestFolder=C:\Program Files\ProData\Log Viewer

XCOPY /Q /Y "%SrcFolder%\LogViewer.exe" "%DestFolder%"
XCOPY /Q /Y "%SrcFolder%\LogViewer.exe.config" "%DestFolder%"

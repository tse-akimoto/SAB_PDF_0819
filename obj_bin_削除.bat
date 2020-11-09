rem objが残っていてInstaller Projectsがエラーになったことがあったのでお掃除するバッチ

rmdir /S /Q .\Exe

rmdir /S /Q .\SABPdf\obj
rmdir /S /Q .\SABPdf\bin

pause

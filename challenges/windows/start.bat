@echo off
cd C:\Windows\Microsoft.NET\Framework\v4.0.30319\
installutil.exe C:\YCEP\Service\gwservice.exe
installutil.exe C:\YCEP\Service\InterceptionService.exe
installutil.exe C:\YCEP\Service\WinLogin.exe

cd C:\Users\admin\Desktop\
schtasks /create /tn "Start EventLog" /xml TaskScheduling.xml
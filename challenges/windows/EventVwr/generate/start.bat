@echo off
cd C:\Users\admin\Desktop
schtasks /create /tn "Start EventLog" /xml TaskScheduling.xml
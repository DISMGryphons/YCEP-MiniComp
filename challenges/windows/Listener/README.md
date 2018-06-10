# Listener

## Question Text

I have a service listening on port 10000, can you help me get the name of the service?

*E.g. If service name is "Windows Update Service":* `MC{WINDOWS_UPDATE_SERVICE}`

### Hints (Optional)
1. Google netstat!

## Setup Guide
### Client
1. Place `WinLogin.exe` in `C:\YCEP\Service`.
2. Open command prompt as administrator.
3. Run the following commands:  
```
// Service should automatically start on next bootup
C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\YCEP\Service\WinLogin.exe
```

### Distribution
- WinLogin.exe
    - SHA1: `99c5043d882a47bb6b2003ef1409da75efc5204d`
    - To be loaded on Window VM before mini-competiton

## Solution
Run the `netstat -anb` from the command line.
Find the program listening at port 0.0.0.0:10000

### Flag
`MC{WINDOWS_LOGIN_APPLICATION}`

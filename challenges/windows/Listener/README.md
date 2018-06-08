# Listener

## Question Text

I have a service listening on port 10000, can you help me get the name of the service?

*E.g. If service name is "Windows Update Service":* `MC{WINDOWS_UPDATE_SERVICE}`

### Hints (Optional)
1. Google netstat!

## Setup Guide
### Client
1. Place `WinLogin.exe` in `%SYSTEMROOT%\System32\`.
2. Open command prompt as administrator.
3. Run the following commands:  
```
// Service should automatically start on next bootup
C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\Windows\System32\WinLogin.exe
```

### Distribution
- WinLogin.exe
    - SHA1: `5c715135f6240e8ed7f960e66b06b631ca1752c1`
    - To be loaded on Window VM before mini-competiton

## Solution
Solution to this challenge

### Flag
`MC{WINDOWS_LOGIN_APPLICATION}`

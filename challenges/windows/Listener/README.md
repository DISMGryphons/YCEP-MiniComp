# Listener

## Question Text

I have a service listening on port 10000, can you help me get the name of the service?

### Hints (Optional)
1. Google netstat!

## Setup Guide
### Client
1. Place `WinLogin.exe` in `%SYSTEMROOT%\System32\`.
2. Open command prompt as administrator.
3. Run the following commands:  
```
// Service should automatically start on next bootup
C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\Windows\System32\winlogin.exe
```

### Service
1. Run ./build.sh in 

## Distribution
- WinLogin.exe
    - SHA1: `4306654c663e0a2e5bb01c8a0d2d9af04c12ed75`
    - To be loaded on Window VM before mini-competiton

## Solution
Solution to this challenge

### Flag
`MC{TH#_W4LL_15_D0WN}`

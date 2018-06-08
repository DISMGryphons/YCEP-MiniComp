# Interception

## Question Text

There is a service on port 15000 that connects to an external service. You might want to try and intercept the transmission.

## Setup Guide
### Client
1. Place `InterceptionService.exe` in `%SYSTEMROOT%\System32\`.
2. Open command prompt as administrator.
3. Run the following commands:  
```
// Service should automatically start on next bootup
C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\Windows\System32\InterceptionService.exe
```

### Service
1. Run ./build.sh in service.

## Distribution
- InterceptionService.exe
    - SHA1: `bf5f59e070e2b1708bf774bbe146ad17a0d60ae3`
    - To be loaded on Window VM before mini-competiton

## Solution
Run wireshark and start capturing for at least 10 seconds.

### Flag
`MC{TH#_W4LL_15_D0WN}`

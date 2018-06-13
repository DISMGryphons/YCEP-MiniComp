# Interception

## Question Text

There is a service on port 15000 that makes a connection to an external server. You might find something valuable in the traffic.

## Setup Guide
### Client
1. Place `InterceptionService.exe` in `C:\YCEP\Service`.
2. Open command prompt as administrator.
3. Run the following commands:  
```
// Service should automatically start on next bootup
C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\YCEP\Service\InterceptionService.exe
```

### Service
1. Run ./build.sh in service.

## Distribution
- InterceptionService.exe
    - SHA1: `4a421ccdf1eb89a5c549b4f4945e186301ced403`
    - To be loaded on Window VM before mini-competiton

## Solution
Run Wireshark and start capturing for at least 10 seconds.

### Flag
`MC{M155I0N_1MP0S51BL3}`

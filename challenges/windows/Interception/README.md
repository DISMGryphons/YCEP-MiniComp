# Interception

## Question Text

There is a service on port 15000 that makes a connection to an external device. You might find something valuable by intercepting the transmission.

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
    - SHA1: `950dc237fd0842ca38960c775a4a329f86471e4f`
    - To be loaded on Window VM before mini-competiton

## Solution
Run Wireshark and start capturing for at least 10 seconds.

### Flag
`MC{M155I0N_1MP0S51BL3}`

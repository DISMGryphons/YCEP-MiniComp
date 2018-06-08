# Great Wall

## Question Text

The Great Wall, a formidable barrier that stands between communication channels. I would need your help to allow me to get my messages across to remote ports starting from 5056 to 5060. I also need local ports starting from 8000 to 8005 open. Can you help me accomplish all this?

## Setup Guide
### Client
1. Place `gwservice.exe` in `%SYSTEMROOT%\System32\`.
2. Open command prompt as administrator.
3. Run the following commands:  
```
// Service should automatically start on next bootup
C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\Windows\System32\gwservice.exe
```

### Service
1. Run ./build.sh in service.

## Distribution
- gwservice.exe
    - SHA1: `46ea3fa2a62f8eacc3755a35bb588d3bfde9d0d8`
    - To be loaded on Window VM before mini-competiton

## Solution
Solution to this challenge

### Flag
`MC{TH#_W4LL_15_D0WN}`

# Great Wall

## Question Text

People say the great wall is really effective. It seems so, I can't seem to receive a message. Can you help me?

### Hints (Optional)
1. The event logs might help!

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
1. Yet to write service

## Distribution
- WinLogin.exe
    - SHA1: `ff4df8a096985da1f3389db10ab6e1006fac3d68`
    - To be loaded on Window VM before mini-competiton

## Solution
Solution to this challenge

### Flag
`MC{TH#_W4LL_15_D0WN}`

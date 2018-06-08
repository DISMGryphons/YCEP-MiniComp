# Great Wall

## Question Text

The Great Wall, a formidable barrier that stands between communication channels. I would need your help to allow me to get my messages across to remote ports 9050, 9437 and 9928. I also need same local ports to be open. Finally, ensure that all other ports, from the range 9001 to 10000 are blocked. Can you help me accomplish all this?

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
    - SHA1: `e9180a968f4d2768319274ab4ff50b8629717fd9`
    - To be loaded on Window VM before mini-competiton

## Solution
By default, Windows allows all outgoing port connections. As such, one would need to block specific ranges `9001-9049, 9051-9436, 9438-9927, 9929-10000` to solve the question.

By default, Windows does not allow incoming port connections. As such, the second part requires students to set rules to allow connections on `9050, 9437, 9928`.

### Flag
`MC{TH#_W4LL_15_D0WN}`

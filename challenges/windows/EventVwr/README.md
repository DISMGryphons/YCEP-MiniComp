# EventVwr

## Question Text

As a good sys admin you should always check your logs!

### Hints (Optional)
1. The flag is base64 encoded.

## Setup Guide
1. Place `EventLog.exe` in `C:\Windows\System32\`.
2. Download `TaskScheduling.xml` and place it in the desktop.
3. Modify the following section of `TaskScheduling.xml` as needed to reflect the new location of `EventLog.exe`:
```
<Actions Context="admin">
    <Exec>
      <Command>"C:\Windows\System32\EventLog.exe"</Command>
    </Exec>
  </Actions>
```
4. Place the `start.bat` on the desktop, make necessary changes to the script, then run the script as an administrator.  
5. Delete start.bat and TaskScheduling.xml  


 `EventLog.exe` should now start running everytime the admin user logs on.
## Distribution
- EventLog.exe
    - SHA1: `7c7abe1db5f71a1ae79c5f0022891fa1cfdf2818`
    - Form is hidden when run. It can be ended through task manager.

## Solution
1. WINDOW + R
2. eventvwr
3. Click Window Logs
4. Click Application
5. Look for Source named: MC
6. Details consist of Base64 Encoded. Decode it.

### Flag
`MC{EV3N7_V13W3R}`

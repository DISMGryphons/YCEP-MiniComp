# EventVwr

## Question Text

As a good sys admin you should always check your logs!

### Hints (Optional)
1. The flag is base64 encoded.

## Setup Guide
1. Place `EventLog.exe` in `C:\YCEP\Executables`.
2. Download `TaskScheduling.xml` and place it in the desktop.
3. Place the `start.bat` on the desktop, make necessary changes to the script, then run the script as an administrator.  
4. Delete start.bat and TaskScheduling.xml
5. Open the Task Scheduler program, open the Task Scheduler Library.
6. Open the properties for the task `Start EventLog`.
7. Ensure the task runs regardless of whether the user account admin is logged in or not.

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

# EventVwr

## Question Text

As a good sys admin you should always check your logs!

### Hints (Optional)
1. The flag is hidden in Window Application Logs.

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
    - SHA1: `413c01227319d140bf5d28adc5182126fbd6a438`
    - Form is hidden when run. It can be ended through task manager.

## Solution
1. Go to Event Viewer
2. On the left side, Under Window Logs -> Application
3. Filter for source named: MC FLAG
4. Details consist of gibberish text. Reverse it to get the flag.

### Flag
`MC{EV3N7_V13W3R}`

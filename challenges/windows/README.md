# Windows Challenges
## Setup Guide
This setup guide describes the steps required, including correct permission configurations to correctly load the services into the virtual machine.

Note: Ignore setup instructions listed in the README for the following challenges. Follow this guide instead!

**Services**  
Great Wall: `gwservice.exe`  
Interception: `InterceptionService.exe`  
Listener: `WinLogin.exe`

**--Task Executables--**  
EventVwr: `EventLog.exe`, `TaskScheduling.xml` (copy to desktop)

### Steps
1. Start up the Windows Virtual Machine and login to the admin account.
2. Create a new user named `YCEP` with the password `ycep_participant_2018`.
3. Give the new user administrator privileges.
4. Open `Local Security Policies` manager.
5. Navigate to Local Policies > User Rights Assignment.
6. Under `Take ownserhip of files or other objects`, assign only the admin account with this right.
7. Close the policy manager.
8. Create a new folder in the C: drive, name it `YCEP`
9. In the newly created YCEP folder, create 2 folders named `Service` and `Executables` respectively.
10. Modify the permissions of the YCEP folder.
11. Allow only the SYSTEM and admin to have Full Control to the folder. All other users should NOT be assigned any rights to the folder.
12. Load the Service folder with service executables listed above.
13. Load the Executables folder with task executables listed above.
14. Copy `start.bat` from the windows folder of the Git repository.
15. Run `start.bat` as an administrator. (Right-click and select `Run as admistrator`).

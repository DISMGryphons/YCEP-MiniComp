# ADS

## Question Text

Apparently the flag is hidden in this text file, can you find the flag for me? 

### Hints (Optional)
1. Alternate Data Stream

## Setup Guide
> In Windows VM
1. `cd 'C:\Users\admin\Desktop\'`
2. `'There is a flag here.' > 'flag.txt'`
3. `Add-Content -Path flag.txt -Value 'MC{5n34kY_ALT3RnaTe_D474_STr34mZ}' -Stream 'flagStream'`
4. `Remove-Item (Get-PSReadlineOption).HistorySavePath`

## Solution
```powershell
# get all data streams of flag.txt
> Get-Item -Path .\flag.txt -Stream *

   FileName: C:\Users\admin\Desktop\flag.txt

Stream                   Length
------                   ------
:$DATA                       21
flagStream                   35

# read the flagStream
> Get-Content -Path .\flag.txt -Stream 'flagStream'
MC{5n34kY_ALT3RnaTe_D474_STr34mZ}
```

### Flag
`MC{5n34kY_ALT3RnaTe_D474_STr34mZ}`

## Recommended Reads
* https://blog.malwarebytes.com/101/2015/07/introduction-to-alternate-data-streams/

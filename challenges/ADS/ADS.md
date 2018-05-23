# ADS

## Question Text

Challenge description and how to play (if applicable).

This is another paragraph.

### Hints (Optional)
1. Hint 1
2. Hint 2

## Setup Guide
1. `Add-Content -Path flag.txt -Value 'MC{5n34kY_ALT3RnaTe_D474_STr34mZ}' -Stream 'flagStream'`

## Distribution
- In Win10 VM

## Solution
```powershell
# get all data streams of flag.txt
> Get-Item -Path .\flag.txt -Stream *

   FileName: C:\Users\admin\Desktop\Chal1\flag.txt

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
* https://links.to.good.reads
* https://www.example.com
# It Can Be Worse
## Question Text
> Warning: This is an  Advanced Challenge. Attempt only if you have completed everything else  

I managed to clone our target's usb, I need you to do a forensics analysis on it.

### Hints (Optional)
1. Something is wrong with the png file signature

## Distribution
- itcanbeworse.dd
    - SHA1: `60b812d73e7a21ceaf6d7f004046c1d5663e1a26`
    - dd image

## Solution
1. mount the disk image or extract the files from it.
2. unzip interesting.zip
3. Open the extracted file `secret` with a hex editor, from the file format, we can see that it is a png file.
4. fix the file signature of the png file extracted from the zip file with any hex editor.
```
# invalid png file signature
89 51 4e 47 0d 0a 1a 0a
# Correct PNG file signature
89 50 4e 47 0d 0a 1a 0a
```

### Flag
`MC{is_it_fil5_c4rving_0r_cr4ving}`

## Recommended Reads
* https://www.w3.org/TR/PNG-Structure.html

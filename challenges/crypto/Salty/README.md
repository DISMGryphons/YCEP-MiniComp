# Salty

## Question Text
> Warning: This is an  Advanced Challenge. Attempt only if you have completed everything else  

I found this website that is still under development, can you break into it?  
`http://chal.gryphonctf.com:7000/`  

### Hints (Optional)
1. Ever heard of robots.txt?
2. The password is in rockyou.txt

## Setup Guide
Run `./build.sh`

## Solution
1. Browse to `http://chal.gryphonctf.com:7000/robots.txt`, you will find `WHEOi6NVuu1TsjnBj66u.txt`, inside that is the salt and the salted password hash of the admin account.
2. Use hashcat or any other password cracking tool to crack the salted hash.
```
hashcat -m 10 WHEOi6NVuu1TsjnBj66u.txt rockyou.txt 
```
3. After cracking the password you can use that to login and get the flag.

### Flag
`MC{s4lt_aNd_p5pper_4r3_n0t_jus_f0r_c0oking}`

## Recommended Reads
* https://crackstation.net/hashing-security.htm

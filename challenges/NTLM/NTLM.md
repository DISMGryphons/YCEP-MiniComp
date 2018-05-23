# NTLM

## Question Text

I found some NTLM hashes, can you crack them for me?

Remember to put the flag in `MC{<flag>}` format.

## Distribution
- ntlm.txt
    - SHA1: `e309291481e0fb99dd6682e4c887a4aacdc2531a`
    - File containing 11 ntlm hashes

## Solution

Dump the hashes to

https://hashkiller.co.uk/ntlm-decrypter.aspx

Output:

```
eae53d3a9e5c403dad6d0b05de86d7f2 NTLM : the
10edc21c9aed6a545556cfb34343abc5 NTLM : flag
40e43aee94115e12541624221019423b NTLM : is
eae53d3a9e5c403dad6d0b05de86d7f2 NTLM : the
e1f39b544ba1f95e2e967e5fba8a653a NTLM : first
83eddae8fc5617c636767a95ac26be7c NTLM : letter
3fedd9f4b878e1c305ea42dab4f34130 NTLM : of
94a71606def5870070289fdbaac8357b NTLM : each
e192a35d1e872b6e9b256e5ccab41457 NTLM : word
184d228db180d4f97d6a49836a2732d9 NTLM : chained
02a280e7c46ac9e76a1ac3043ab7f23c NTLM : together
```

### Flag
`MC{tfitfloewct}`

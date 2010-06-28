SYMBOL crc        = w0  ' b0/b1
SYMBOL k          = w1  ' b2/b3
SYMBOL byte       = b4
SYMBOL bit        = b5

SYMBOL POLYNOMIAL = $A001

crc = $FFFF

byte = "A" : GOSUB Crc16Add
byte = "B" : GOSUB Crc16Add
byte = "C" : GOSUB Crc16Add

crc = crc ^ $FFFF

' crc is $7AAF

END

Crc16Add:
    FOR bit = 0 TO 7
      k = byte ^ crc & 1
      IF k = 0 THEN Crc16Add1
      k = POLYNOMIAL
    Crc16Add1:
      crc = crc / 2 ^ k
      byte = byte / 2
    NEXT
    RETURN


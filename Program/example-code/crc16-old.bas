SYMBOL crc        = w0  ' b0/b1
SYMBOL k          = w1  ' b2/b3
SYMBOL byte_       = b4
SYMBOL bit_        = b5

SYMBOL POLYNOMIAL = $A001

crc = $FFFF

byte_ = "A" : GOSUB Crc16Add
byte_ = "B" : GOSUB Crc16Add
byte_ = "C" : GOSUB Crc16Add

crc = crc ^ $FFFF

' crc is $7AAF

END

Crc16Add:
    FOR bit_ = 0 TO 7
      k = byte_ ^ crc & 1
      IF k = 0 THEN Crc16Add1
      k = POLYNOMIAL
    Crc16Add1:
      crc = crc / 2 ^ k
      byte_ = byte_ / 2
    NEXT
    RETURN


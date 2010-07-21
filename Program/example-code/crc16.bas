SYMBOL crc        = w0  ' b0/b1
SYMBOL k          = w1  ' b2/b3
SYMBOL byte_       = b4
SYMBOL bit_        = b5
symbol word2 = w12

SYMBOL POLYNOMIAL = $1021

crc = $FFFF

byte_ = "A" : GOSUB Crc16Add
byte_ = "B" : GOSUB Crc16Add
byte_ = "C" : GOSUB Crc16Add

crc = crc ^ $0000



END

 crc16add2:

word2 = byte_ << 8
crc = crc ^ word2

for byte_ = 0 to 7

	word2 = crc & 0x8000
	if word2 > 0 then
		crc = crc << 1
		crc = crc ^ 0x1021
	else
		crc = crc << 1
	endif
	

next


return


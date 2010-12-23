#slot 0

#define oscFreq64
'#define oscFreq8

symbol rtcCS = b.6
symbol MISO = Pina.3
symbol MOSI = a.4
symbol SCLK = b.7
symbol adcCS = a.2
symbol memCS = d.6

symbol radIn = d.0	'radiation serial in
symbol radOut = d.1	'radiation serial out, can be switched with above pin

symbol lightCS = d.3
symbol lightOut = c.0
symbol lightS0 = c.5
symbol lightS1 = b.7
symbol lightS2 = a.4
symbol lightS3 = a.3


symbol FET1 = b.1		'FET O/Ps
symbol FET2 = d.7

symbol humidityIn = pina.7'	humidity sensor when pin used as input
symbol humidityOut = a.7'	humidity sensor when pin used as ouput

symbol GPSIn1 = b.2		'GPS pins
symbol GPSOut1 = a.6
symbol GPSIn2 = b.3
symbol GPSOut2 = b.4

symbol cam1 = d.2
symbol cam2 = c.2

symbol IOHeader1 = c.3		'unused header	also i2c pins
symbol IOHeader2 = pinc.4

symbol tempOW = b.5	'temperature one wire bus

symbol LED = a.5		'SMD LED

symbol hseroutOP = c.6	'the hersin/out pints
symbol hserinIP = c.7




symbol radioCSTX = d.4	'CS for the radio, one is tx, other rx
symbol radioCSRX = d.5

symbol RSSI = b.0	'adc pin for radio RSSI o/p


symbol PhoneMOSI = a.0	'phone in
symbol PhoneMISO = a.1	'phone out


'#########
'#OPCODES#
'#########

symbol _WREN = 0x06
symbol _WRDI = 0x04
symbol _RDSR = 0x05
symbol _WRSR = 0x01
symbol _READ = 0x03
symbol _FAST_READ = 0x0B
symbol _PP = 0x02
symbol _SE = 0xD8
symbol _BE = 0xC7
symbol _DP = 0xB9
symbol _RDID = 0x9F
symbol _RES = 0xAB

'#########
'#########
'#########



'########
'varibles
'########

symbol CurrentAltitude = w25
symbol CurrentAltitudel = b50
symbol CurrentAltitudeh = b51
symbol RAMptr = b53	'ptrs store the next value to read
symbol phonectr = b54
symbol cycleCount = b34

symbol CamBotBoolROM = 0x4E
symbol CamTopboolRom = 0x4F
symbol PacketPtrlROM = 0x50
symbol PacketPtrhROM = 0x51
symbol MaxAltitudelROM = 0x52
symbol MaxAltitudehROM = 0x53
symbol AboutToLand = 0x54

symbol LGLatStartptr = 0x55			'55
symbol LGLatEnd = LGLatStartptr + 10 	'65
symbol LGLongStartptr = LGLatStartptr + 11'66
symbol LGLongEnd = LGLatStartptr + 22	'77

symbol RAMLatptr = 60
symbol RAMLongptr = 71
symbol RAMLatStart = 61
'symbol RAMlatStartp1 = RAMLatStart + 1
symbol RAMlongStart = 72
'symbol RAMLongStartp1 = RAMlongStart + 1
symbol RAMLatEnd = 70
symbol RAMLongEnd = 82
symbol RAMAltptr = 83
symbol RAMAltStart = 84
symbol RAMAltend = 88


symbol PacketPtrl = b38
symbol PacketPtrh = b39
symbol PacketPtr = w19

'symbol TXBaud = 39999	'8mhz:39999 for 50 baud
symbol TXBauds = 39999
symbol TXBaudf = B300_8
symbol TXMode = %110
symbol RXBaud = 53332	'37.5
symbol RXMode = %111

#ifdef oscFreq8
symbol lightcountT = 10
symbol lightcountTl = 100

symbol temppause = 750
symbol irdBaud = n9600_8
symbol irdWait = 1000

symbol phoneBaud = t9600_8
symbol phonetimeout = 1000
#else
symbol lightcountT = 80
symbol lightcountTl = 800
symbol temppause = 6000
symbol irdBaud = n9600_64
symbol irdWait = 8000
symbol phoneBaud = t9600_64
symbol phonetimeout = 8000
#endif

'########
'########
'########


symbol AltThresholdHigh = 190
symbol AltThresholdLow = 110
symbol AltFallingDistance = 50
symbol AboutToLandCntMax = 6
symbol CameraHyst = 3
symbol AltThresholdLowC = 120
symbol maxcycles = 1


'phone stuff

table 0x00,("07922123456")


'no commands can be stored on or past 0xF8
table 0x80,("PING5TjypQ")	'ping command and pwd
table ("CDWNytB48U")		'cutdown command and pwd
table ("FILMhdERY7")
table ("RESTg3nBhG")
table ("IRDOhyxapr")
table ("IRDFh7wv7k")
table ("SHUTp1cX7W")
table ("TESTN86GhH")
				'blanking

table ("XXXXXXXXXX")
table ("XXXXXXXXXX")
table ("XXXXXXXXXX")
table ("XXXXXXXXXX")


high adccs
high rtccs
high memCS
high radioCSTX
high radioCSRX
high lightcs

DirsB = DirsB AND %11110011	'set GPS input pins as inputs

setfreq em64
b36 = 1


setfreq m8


low cam1
low cam2

'sertxd("Rst")


main:
sertxd("main",cr,lf)
ptr = 0


serin [7000,endgps],GPSIn2,T4800,("GPGGA,"),@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc,@ptrinc

sertxd("blarg",cr,lf)
endgps:

b49 = ptr	'limit of input


'b0 = start of time ptr
'b1 = end of time ptr
'b2 = start of lat pointer
'b3 = end of lat pointer
'b4 = N/S; otherwise no fix
'b5 = start of long pointer
'b6 = end of long pointer
'b7 = E/W; otherwise no fix
'b8 = start of alt pointer
'b9 = end of alt pointer
'b10 = alt valid when 1
'b11 = sats start
'b12 = sats end
b0 = 0
b1 = 0


ptr = 0

if @ptrinc = "," then	'if no time
	b1 = 0
else
	do while b1 = 0
		if @ptr = "," then
			b1 = ptr - 1
		endif			
		ptr = ptr + 1
	loop					'time end pointer found
endif		


b2 = ptr
b3 = 0
if @ptrinc = "," then	'if no lat
	b3 = ptr - 1
	b4 = 0
else
	do while b3 = 0
		if @ptr = "," then
			b3 = ptr - 1
		endif			
		ptr = ptr + 1
	loop					'lat end pointer found
	
	b4 = @ptrinc			'N/S
	ptr = ptr + 1
endif		


b5 = ptr
b6 = 0
if @ptrinc = "," then	'if no long
	b6 = ptr - 1
	b7 = 0
else
	do while b6 = 0
		if @ptr = "," then
			b6 = ptr - 1
		endif			
		ptr = ptr + 1
	loop					'long end pointer found
	
	b7 = @ptrinc			'E/W
	ptr = ptr + 1
endif		


ptr = ptr + 2




b11 = ptr
b12 = 0
if @ptrinc = "," then	'if no sats
	b12 = ptr - 1
else
	do while b12 = 0
		if @ptr = "," then
			b12 = ptr - 1
		endif			
		ptr = ptr + 1
	loop					'sats end pointer found

	ptr = ptr + 1
endif		


do while @ptrinc <> ","
	
loop


b8 = ptr
b9 = 0
b10 = 1
if @ptrinc = "," then	'if no alt
	b9 = ptr - 1
	b10 = 0
else
	do while b9 = 0
		if @ptr = "," then
			b9 = ptr - 1
		endif			
		ptr = ptr + 1
	loop					'sats end pointer found

	ptr = ptr + 1
endif		



ptr=  b0
sertxd("b0: ",#b0,"   b1: ",#b1,cr,lf)
for b20 = b0 to b1
	sertxd(@ptrinc)
next

sertxd(cr,lf)





goto main
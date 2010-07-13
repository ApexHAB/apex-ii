#picaxe14m

symbol IRD1 = 4
symbol IRD2 = 1
symbol dataIn = 2
symbol charge = output2
symbol discharge = output1
symbol dataOut = output5

setfreq m8
main:

serin datain,t9600_8,("C1")
pause 300
serout dataOut,n9600_8,("##",b0,b1,b2,b3)
count ird1,40000,w0
count ird2,40000,w1



goto main
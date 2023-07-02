INCLUDE Variables.ink

{ChapterState == 1:
    {LarujaState == 0: -> state0}
}

{ChapterState == 2:
    {LarujaState == 0: -> state1}
}

{ChapterState == 3:
    {LarujaState == 0: -> state2}
    {LarujaState == 1: -> state3}
    {LarujaState == 2: -> state4}
}

// --- Chapter 1 ---
=== state0 ===
(Masaya silang nagkukwentuhan at kita naman na naaaliw sila sa pagtitipon…) #speaker:G. Laruja
->END

// --- Chapter 2 ---
=== state1 ===
//G. Laruja
Ikaw pala ang anak ni Don Rafael... Nagagalak akong makilala ka.#speaker:G. Laruja #audio:GL_state1_0
//Ibarra
Ako nga ho, iyon Señor #speaker:Ibarra #audio:GL_state1_1
//G. Laruja
Iyo ang gabing ito sana'y maging magalak at maaliw ka sa pagtitipon na ito.#speaker:G. Laruja #audio:GL_state1_2
//Ibarra
Maraming Salamat po sa mainit na pagtanggap! Maging masaya sana ang inyong gabi Señor.#speaker:Ibarra #audio:GL_state1_3

->END

// --- Chapter 3 ---
=== state2 ===
(Nakikipagusap ito sa ibang mga bisita upang hindi mainip sa pag-aantay.) #speaker:G. Laruja
->END
=== state3 ===
//G. Laruja
Senor Ibarra, maitanong ko lang, ilang taon kang nawala sa ating bayan? #speaker:G. Laruja #audio:GL_state3_0
//Ibarra
Nasa pitong taon din po mula nang nilisan ko ang ating bayan, ginoo. #speaker:Ibarra #audio:GL_state3_1
//G. Laruja
Marahil sa loob ng pitong taon na ika’y nasa Europa ay nakalimutan mo na ang ating inang bayan.#speaker:G. Laruja #audio:GL_state3_2
//Ibarra
Nagkakamali po kayo, Ginoo. Sa pakiramdam ko po ay kabaliktaran, ang sarili kong bayan ang tila nakalimot sa akin.#speaker:Ibarra #audio:GL_state3_3
Lagi kong iniisip ang ating bansa dahil sa nandito ang aking pamilya at mga kababayan. #audio:GL_state3_4
//Donya Victorina
Totoo ba iyan, iho? #speaker:Donya Victorina #audio:GL_state3_5
//Ibarra
Opo, hindi ko kailanmang naisip na kalimutan ang aking bayan. #speaker:Ibarra #audio:GL_state3_6
//G. Laruja
Sa mga bansang iyong napuntahan sa Europa, ano ang pinakatumatak at bumighani sa iyong puso? #speaker:G. Laruja #audio:GL_state3_7
//Ibarra
Ipagpaumanhin po ninyo, Ginoo pero mas pipiliin ko pa rin ang ating inang bayan kaysa sa mga bansa sa Europa. #speaker:Ibarra #audio:GL_state3_8
{ DamasoState == 1:
    (Narinig ni Padre Damaso ang usapan nila Ibarra at hindi nakapagtimping magbigay ng komento sa sinabi ng binata.) #speaker:Ibarra #audio:GL_state3_9
    ~ DamasoState = 2
    ~ LarujaState = 2
}
->END

=== state4 ===
(Patuloy na nakipagusap si Ginoong Laruja sa iba’t- ibang mga bisita habang kumakain.) #speaker:Ibarra
->END


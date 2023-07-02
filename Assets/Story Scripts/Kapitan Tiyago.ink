INCLUDE Variables.ink

{ChapterState == 2:
    {TiyagoState == 0: -> state0}
    {TiyagoState == 1: -> state1}
    {TiyagoState == 2: -> state2}
}
{ChapterState == 3:
    {TiyagoState >= 0: -> state3}
}

// --- Chapter 2 ---
=== state0 ===
//Kapitan Tiyago
Maligayang pagdating sa aking tahanan! Kumusta ang naging paglalakbay mo pauwi? #speaker:Kapitan Tiyago #audio:KT_state0_0
//Ibarra
Salamat po sa mainit na pagtanggap, Kapitan Tiago! Naging ligtas naman ang aking paglalakbay at wala naman naging aberya. #speaker:Ibarra #audio:KT_state0_1
Ako’y nagagalak at ako’y nakauwi na sa ating inang bayan. #audio:KT_state0_2
//Kapitan Tiyago
Halika, pasok na tayo. Mayroon akong inihandang salo-salo bilang selebrasyon sa iyong pagbabalik dito sa ating bayan. #speaker:Kapitan Tiyago #audio:KT_state0_3
//Ibara
Nako, dapat hindi na po kayo nag-abala, pero maraming salamat po sa inyong mga naghanda. #speaker:Ibarra #audio:KT_state0_4
(Agad na kami pumunta sa bulwagan kung saan nagkaroon ng panandaliang katahimikan ng maramdaman ang aming presensya.) #audio:null
~TiyagoState = 1
->END

=== state1 ===
//Kapitan Tiyago
Una sa lahat, lubos akong nagpapasalamat sa mga kaibigan at kababayan na nagpaunlak sa aking imbitasyon na dumalo sa aking munting salo salo.#speaker:Kapitan Tiyago #audio:KT_state1_0
Kayo ay aking inimbitahan dito sapagkat mayroon akong isang taong nais ipakilala sa inyo. #audio:KT_state1_1
Siya ang anak ng aking yumaong kaibigan, ang anak ni Don Rafael, si Crisostomo Ibarra. #audio:KT_state1_2
//Ibarra
Magandang Gabi po inyong lahat. #speaker:Ibarra #audio:KT_state1_3
Salamat po sa pagdalo sa salo salong ito at ako po ay nagagalak na maparito. #audio:KT_state1_4
~TiyagoState = 2
->END

=== state2 ===
//Kapitan Tiyago
Ano pang inaantay mo iho? Para sayo ang gabi na ito, iyong sulitin ang gabing ito para magsaya at makuhalubilo sa mga bisita. #speaker:Kapitan Tiyago #audio:KT_state2_0
//Ibarra
Muchas Gracias, Señor. #speaker:Ibarra #audio:KT_state2_1
->END

// --- Chapter 3 ---
=== state3 ===
//Ibarra
Don Tiago, halika na ho, samahan niyo po kami dito sa hapagkainan.#speaker:Ibarra #audio:KT_state3_0
//Kapitan Tiyago
Salamat pero mauna na kayo. Huwag mo na akong alalahanin.#speaker:Kapitan Tiyago #audio:KT_state3_1
{TiyagoState <= 0:
    ~ StoryState = 1
    (Maya’t maya rin ay inihain na ang pagkain. Lalong nagdagdagan ang galit ni Padre nang makita ang inihain sa kanyang Tinola.) #audio:PlacePlate
    ~ TiyagoState = 1
    ~ DamasoState = 1
    ~ TenyenteState = 1
    ~ SibylaState = 1
    ~ VictorinaState = 1
    
}
->END
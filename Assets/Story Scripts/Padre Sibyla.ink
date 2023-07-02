INCLUDE Variables.ink

{ChapterState == 1:
    {SibylaState == 0: -> state0}
}

{ChapterState == 2:
    {SibylaState == 0: -> state1}
}

{ChapterState == 3:
    {SibylaState == 0: -> state2}
    {SibylaState == 1: -> state2}
}


// --- Chapter 1 ---
=== state0 ===
//Padre Sibyla
(Mukhang may pinag-uusapan sila ngunit hindi naman ito maunawaan… Mas mabuti siguro na hayaan na lang sila.)#speaker:Padre Sibyla
->END

// --- Chapter 2 ---
=== state1 ===
//Padre Sibyla
Ako'y nagagalak na makilala ka Señor Ibarra. Ako si Padre Sibyla kura paroko ng Binundok. #speaker:Padre Sibyla #audio:PS_state1_0
//Ibarra
Ikinalulugod ko po kayong makilala Padre Sibylla. Sana'y maaliw po kayo at maaliw sa binuong pagtitipon ni Kapitan Tiago. #speaker:Ibarra #audio:PS_state1_1
//Padre Sibyla
Maraming salamat, Señor Ibarra. #speaker:Padre Sibyla #audio:PS_state1_2
->END

// --- Chapter 3 ---
=== state2 ===
(Kitang kita ang kaibahan ng dalawang Padre… Walang imik at matiyagang inaantay ang ihahandang pagkain.) #speaker:Ibarra
->END

=== state3 ===
(Nakikipagusap ang Padre sa mga ibang mga bisita habang humihigop ito ng mainit na sabaw ng tinola.) #speaker:Ibarra
->END


INCLUDE Variables.ink

{ChapterState == 1:
    {VictorinaState == 0: -> state0}
}

{ChapterState == 2:
    {VictorinaState == 0: -> state1}
}

{ChapterState == 3:
    {VictorinaState == 0: -> state2}
    {VictorinaState == 1: -> state3}
}

// --- Chapter 1 ---
=== state0 ===
//Donya Victorina
Napakagarbo ng salo-salo na ito at karamihan sa mga prominenteng tao sa lungsod ay nandito. Kaya mainam na lang at pinaghandaan ko ang kasuotan ko ngayong gabi.#speaker:Donya Victorina #audio:DV_state0_0
->END

// --- Chapter 2 ---
=== state1 ===
//Donya Victorina
Para naman pala sa isang makisig at matipunong lalaki ang handaang ito. Maligayang pagbabalik sa Las Filipinas.#speaker:Donya Victorina #audio:DV_state1_0
//Ibarra
Hindi pa po ako nakakapagpakilala ng pormal. Ako po si Juan Crisostomo Ibarra at ako po ay nagagalak na makilala kayo.#speaker:Ibarra #audio:DV_state1_1
//Donya Victorina
Ako’y nagagalak din na makilala ang isang edukadong ginoo mula sa Europa. Sulitin mo ang gabing ito na makisaya at makihalubilo sa mga bisita.#speaker:Donya Victorina #audio:DV_state1_2
//Ibarra
Mucahas Gracias, Senora!#speaker:Ibarra #audio:DV_state1_3
->END

// --- Chapter 3 ---
=== state2 ===
 (Tila ba’y naiinip na si Senora pero sa tingin ko naman ay maya’t maya ay ihahain na din ang aming makakain) #speaker:Donya Victorina
->END

=== state3 ===
(Makikitang nawala ang inip sa mukha ni Donya Victorina nang dumating ang inihandang tinola. Tila’y nasarapan ito sa inihaing tinola) #speaker:Ibarra
->END







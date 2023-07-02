INCLUDE Variables.ink

{ChapterState == 1:
    {KasambahayState == 0: -> state0}
}

{ChapterState == 2:
    {talkToTenyente == 1: 
        {talkToDamaso == 1: -> state2}
    }
    {KasambahayState == 0: -> state0}
    {KasambahayState == 1: -> state2}
}

{ChapterState == 3:
    {KasambahayState == 0: -> state3}
}

// --- Chapter 1 ---
=== state0 ===
//Kasambahay
Maligayang pagdating sa tahanan ni Kapitan Tiago! #speaker:Kasambahay #audio:Ksmby_state0_0
Kami ay abala ngunit kung nangangailangan ka ng tulong ay kami ay iyong lapitan upang ika’y paglingkuran. #audio:Ksmby_state0_1
->END

// --- Chapter 2 ---
=== state2 ===
//Kasambahay
Mga minamahal na ginoo't binibini at mga kagalang kagalang na señor at señor, nakahanda na po ang mesa para sa hapunan. #speaker:Kasambahay #audio:Ksmby_state2_0
~ showEndSign = 1
~ KasambahayState = 1
~ talkToTenyente = 5
~ talkToDamaso = 5
->END

// --- Chapter 3 ---
=== state3 ===
(Abala ang mga kasambahay, mas mabuti siguro na wag ko na silang abalahin pa.) #speaker:Ibarra
->END
